namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_WelfareInvestRewardHandler : MessageLocationHandler<Unit, C2M_WelfareInvestRewardRequest, M2C_WelfareInvestRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareInvestRewardRequest request, M2C_WelfareInvestRewardResponse response)
        {
            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.InvestReward) == 1)
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            int total = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.InvestTotal);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Gold, total.ToString(), true, ItemGetWay.Welfare);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.InvestReward, 1);
            await ETTask.CompletedTask;
        }
    }
}
