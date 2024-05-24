using System;

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
            M2P_PaiMaiAuctionPriceRequest message = new M2P_PaiMaiAuctionPriceRequest()
            {
                Price = request.Price,
                UnitID = unit.Id, 
                Occ = userInfoComponent.UserInfo.Occ,
                AuctionPlayer = userInfoComponent.UserInfo.Name,
            };
            ActorId paimaiserverid = UnitCacheHelper.GetPaiMaiServerId(unit.Zone());
            P2M_PaiMaiAuctionPriceResponse r_GameStatusResponse = (P2M_PaiMaiAuctionPriceResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (paimaiserverid, message);

            response.Error = r_GameStatusResponse.Error;
        }
    }
}
