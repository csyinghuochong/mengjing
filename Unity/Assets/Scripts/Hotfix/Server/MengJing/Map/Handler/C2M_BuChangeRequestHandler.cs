using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_BuChangeRequestHandler : MessageLocationHandler<Unit, C2M_BuChangeRequest, M2C_BuChangeResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_BuChangeRequest request, M2C_BuChangeResponse response)
        {
            Log.Error($"C2M_BuChangeRequest: {unit.Id}  {request.BuChangId}");
            ActorId accountZone = UnitCacheHelper.GetAccountCenter();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            Center2M_BuChangeResponse centerAccount = (Center2M_BuChangeResponse)await unit.Root().GetComponent<MessageSender>().Call(accountZone, new M2Center_BuChangeRequest()
            { 
                BuChangId = request.BuChangId,
                UserId = userInfoComponent.Id,
                AccountId = userInfoComponent.UserInfo.AccInfoID
            });
 
            unit.GetComponent<NumericComponentS>().ApplyChange(null, NumericType.RechargeNumber, centerAccount.BuChangRecharge, 0,true);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd( UserDataType.Diamond, centerAccount.BuChangDiamond.ToString(), true, ItemGetWay.BuChang);
            response.PlayerInfo = centerAccount.PlayerInfo;

            await ETTask.CompletedTask;
        }
    }
}
