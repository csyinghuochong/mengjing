namespace ET.Server
{

    [MessageHandler(SceneType.PaiMai)]
    public class P2M_PaiMaiAuctionOverHandler : MessageHandler<Unit, P2M_PaiMaiAuctionOverRequest, M2P_PaiMaiAuctionOverResponse>
    {
        protected override async ETTask Run(Unit unit, P2M_PaiMaiAuctionOverRequest request, M2P_PaiMaiAuctionOverResponse response)
        {
            Log.Warning($"PaiMaiAuctionOver:  {unit.Zone()} {unit.Id}");
            
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent.UserInfo.Gold < request.Price)
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Message, "金币不足，竞拍失败！");
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
            }
            else
            {
                userInfoComponent.UpdateRoleMoneySub( UserDataType.Gold, (request.Price * -1).ToString(), true, ItemGetWay.Auction );
                response.Error = ErrorCode.ERR_Success;
                Log.Warning($"扣除竞拍价：{unit.Zone()} {request.Price}");
            }
            await ETTask.CompletedTask;
        }
    }
}
