namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_BuChangeRequestHandler : MessageLocationHandler<Unit, C2M_BuChangeRequest, M2C_BuChangeResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_BuChangeRequest request, M2C_BuChangeResponse response)
        {
            Log.Error($"C2M_BuChangeRequest: {unit.Id}  {request.BuChangId}");
            ActorId accountZone = UnitCacheHelper.GetLoginCenterId();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            M2L_BuChangeRequest M2Center_BuChangeRequest = M2L_BuChangeRequest.Create();
            M2Center_BuChangeRequest.BuChangId = request.BuChangId;
            M2Center_BuChangeRequest.UserId = userInfoComponent.Id;
            M2Center_BuChangeRequest.AccountId = userInfoComponent.UserInfo.AccInfoID;
            L2M_BuChangeResponse centerAccount = (L2M_BuChangeResponse)await unit.Root().GetComponent<MessageSender>().Call(accountZone, M2Center_BuChangeRequest);
 
            unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.RechargeNumber, centerAccount.BuChangRecharge);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd( UserDataType.Diamond, centerAccount.BuChangDiamond.ToString(), true, ItemGetWay.BuChang);
            response.PlayerInfo = centerAccount.PlayerInfo;

            await ETTask.CompletedTask;
        }
    }
}
