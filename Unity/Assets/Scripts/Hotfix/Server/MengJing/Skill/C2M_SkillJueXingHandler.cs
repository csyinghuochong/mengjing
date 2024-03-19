namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SkillJueXingHandler : MessageLocationHandler<Unit, C2M_SkillJueXingRequest, M2C_SkillJueXingResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillJueXingRequest request, M2C_SkillJueXingResponse response)
        {
            await ETTask.CompletedTask;
            
            //判断条件
            OccupationJueXingConfig occupationJueXingConfig = OccupationJueXingConfigCategory.Instance.Get(request.JueXingId);
            if (occupationJueXingConfig == null)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            NumericComponentServer numericComponent = unit.GetComponent<NumericComponentServer>();
            if (numericComponent.GetAsLong(NumericType.JueXingExp) < occupationJueXingConfig.costExp)
            {
                response.Error = ErrorCode.ERR_ExpNoEnough;
                return;
            }

            UserInfoComponentServer userInfoComponent = unit.GetComponent<UserInfoComponentServer>();
            if (userInfoComponent.GetGold() < occupationJueXingConfig.costGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            if (!bagComponent.CheckCostItem(occupationJueXingConfig.costItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            SkillSetComponentServer skillSetComponent = unit.GetComponent<SkillSetComponentServer>();

            bool preerror = false;
            if (occupationJueXingConfig.Pre_Condition != null)
            {
                for (int i = 0; i < occupationJueXingConfig.Pre_Condition.Length; i++)
                {
                    SkillPro skillPro = skillSetComponent.GetBySkillID(occupationJueXingConfig.Pre_Condition[i]);
                    if (skillPro == null)
                    {
                        preerror = true;
                        break;
                    }
                }
            }
            if (preerror)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }

            int oldvalue = numericComponent.GetAsInt(occupationJueXingConfig.costExp);
            numericComponent.SetEvent(NumericType.JueXingExp, oldvalue + occupationJueXingConfig.costExp * -1, true);

            userInfoComponent.UpdateRoleMoneySub(UserDataType.Gold, (occupationJueXingConfig.costGold * -1).ToString(), true, ItemGetWay.JueXing);

            bagComponent.OnCostItemData(occupationJueXingConfig.costItem);

            //增加技能
            skillSetComponent.OnJueXing(request.JueXingId);
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
        }
    }
}