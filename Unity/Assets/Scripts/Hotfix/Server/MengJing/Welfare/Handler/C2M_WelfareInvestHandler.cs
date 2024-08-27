namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_WelfareInvestHandler : MessageLocationHandler<Unit, C2M_WelfareInvestRequest, M2C_WelfareInvestResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareInvestRequest request, M2C_WelfareInvestResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            if (request.Index < 0 || request.Index >= ConfigData.WelfareInvestList.Count)
            {
                Log.Error($"C2M_WelfareInvestRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.WelfareInvestList.Contains(request.Index))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            int ment = ConfigData.WelfareInvestList[request.Index].KeyId;
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Gold <= ment)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }
            string reward = ConfigData.WelfareInvestList[request.Index].Value;
            unit.GetComponent<BagComponentS>().OnAddItemData(reward, $"{ItemGetWay.Welfare}_{TimeHelper.ServerNow()}");
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub( UserDataType.Gold,(ment * -1).ToString(), true, ItemGetWay.Welfare );
            unit.GetComponent<NumericComponentS>().ApplyChange( NumericType.InvestMent, ment);
            unit.GetComponent<NumericComponentS>().ApplyChange( NumericType.InvestTotal, ment);
            unit.GetComponent<UserInfoComponentS>().UserInfo.WelfareInvestList.Add(request.Index);
            await ETTask.CompletedTask;
        }
    }
}
