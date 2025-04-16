namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
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

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsLong(NumericType.JueXingExp) < occupationJueXingConfig.costExp)
            {
                response.Error = ErrorCode.ERR_ExpNoEnough;
                return;
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent.GetGold() < occupationJueXingConfig.costGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (!bagComponent.CheckCostItem(occupationJueXingConfig.costItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();

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
            numericComponent.ApplyValue(NumericType.JueXingExp, oldvalue + occupationJueXingConfig.costExp * -1, true);

            userInfoComponent.UpdateRoleMoneySub(UserDataType.Gold, (occupationJueXingConfig.costGold * -1).ToString(), true, ItemGetWay.JueXing);

            bagComponent.OnCostItemData(occupationJueXingConfig.costItem);

            //增加技能
            skillSetComponent.OnJueXing(request.JueXingId);
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
        }
    }
}