namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SkillOperationHandler : MessageLocationHandler<Unit, C2M_SkillOperation, M2C_SkillOperation>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillOperation request, M2C_SkillOperation response)
        {
            await ETTask.CompletedTask;
            UserInfoComponentServer userInfoComponent = unit.GetComponent<UserInfoComponentServer>();
            int level = userInfoComponent.GetUserLv();
            int sp = userInfoComponent.GetSp();
            switch (request.OperationType)
            {
                case 1:
                    GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(20);
                    int needGold = int.Parse(globalValueConfig.Value);
                    userInfoComponent = unit.GetComponent<UserInfoComponentServer>();
                    if (userInfoComponent.GetGold() < needGold)
                    {
                        response.Error = ErrorCode.ERR_GoldNotEnoughError;
                        return;
                    }

                    userInfoComponent.UpdateRoleMoneySub(UserDataType.Gold, (needGold * -1).ToString());
                    userInfoComponent.UpdateRoleData(UserDataType.Sp, (level - sp - 1).ToString());
                    unit.GetComponent<SkillSetComponentServer>().OnSkillReset();
                    break;
                case 2:
                    globalValueConfig = GlobalValueConfigCategory.Instance.Get(29);
                    needGold = int.Parse(globalValueConfig.Value);
        
                    if (userInfoComponent.GetDiamond() < needGold)
                    {
                        response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                        return;
                    }

                    sp = unit.GetComponent<SkillSetComponentServer>().OnOccReset();
                    userInfoComponent.UpdateRoleData(UserDataType.Sp, sp.ToString());
                    break;
                case 3:
                    unit.GetComponent<NumericComponentServer>().SetEvent(NumericType.SkillMakePlan2, 1, false);
                    break;
                case 4:
                    unit.GetComponent<NumericComponentServer>().SetEvent(NumericType.GemWarehouseOpen, 1, false);
                    break;
            }
        }
    }
}