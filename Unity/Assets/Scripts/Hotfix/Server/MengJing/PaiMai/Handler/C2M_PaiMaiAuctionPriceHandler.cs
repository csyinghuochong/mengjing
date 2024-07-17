namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_PaiMaiAuctionPriceHandler : MessageLocationHandler<Unit, C2M_PaiMaiAuctionPriceRequest, M2C_PaiMaiAuctionPriceResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PaiMaiAuctionPriceRequest request, M2C_PaiMaiAuctionPriceResponse response)
        {
            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            if (userInfo.Gold < request.Price)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            M2P_PaiMaiAuctionPriceRequest message = M2P_PaiMaiAuctionPriceRequest.Create();
            message.Price = request.Price;
            message.UnitID = unit.Id;
            message.Occ = userInfoComponent.UserInfo.Occ;
            message.AuctionPlayer = userInfoComponent.UserInfo.Name;
            ActorId paimaiserverid = UnitCacheHelper.GetPaiMaiServerId(unit.Zone());
            P2M_PaiMaiAuctionPriceResponse r_GameStatusResponse = (P2M_PaiMaiAuctionPriceResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (paimaiserverid, message);

            response.Error = r_GameStatusResponse.Error;
        }
    }
}
