namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanExchangeHandler : MessageLocationHandler<Unit, C2M_JiaYuanExchangeRequest, M2C_JiaYuanExchangeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanExchangeRequest request, M2C_JiaYuanExchangeResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            UserInfoComponentS userInfoComponent=unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = userInfoComponent.UserInfo;
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(userInfo.JiaYuanLv);
            switch (request.ExchangeType)
            {
                case 1: //金币兑换资金
                    if (numericComponent.GetAsInt(NumericType.JiaYuanExchangeZiJin) >= 10)
                    {
                        response.Error = ErrorCode.ERR_TimesIsNot;
                        return;
                    }
                   
                    if (userInfo.Gold < jiaYuanConfig.ExchangeZiJinCostGold)
                    {
                        response.Error = ErrorCode.ERR_ItemNotEnoughError;
                        return;
                    }

                    userInfoComponent.UpdateRoleMoneySub(UserDataType.Gold, (jiaYuanConfig.ExchangeZiJinCostGold * -1).ToString(), true, ItemGetWay.JiaYuanCost);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.JiaYuanFund, (jiaYuanConfig.ExchangeZiJin).ToString(), true, ItemGetWay.JiaYuanExchange);
                    numericComponent.ApplyChange(NumericType.JiaYuanExchangeZiJin, 1);
                    break;
                case 2: //资金兑换经验
                    if (numericComponent.GetAsInt(NumericType.JiaYuanExchangeExp) >= 10)
                    {
                        response.Error = ErrorCode.ERR_TimesIsNot;
                        return;
                    }
                   
                    if (userInfo.JiaYuanFund < jiaYuanConfig.ExchangeExpCostZiJin)
                    {
                        response.Error = ErrorCode.ERR_ItemNotEnoughError;
                        return;
                    }

                    userInfoComponent.UpdateRoleMoneySub(UserDataType.JiaYuanFund, (jiaYuanConfig.ExchangeExpCostZiJin * -1).ToString(), true, ItemGetWay.JiaYuanCost);
                    userInfoComponent.UpdateRoleMoneyAdd(UserDataType.JiaYuanExp, (jiaYuanConfig.ExchangeExp).ToString(), true, ItemGetWay.JiaYuanExchange);
                    numericComponent.ApplyChange(NumericType.JiaYuanExchangeExp, 1);
                    break;
                default:
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}
