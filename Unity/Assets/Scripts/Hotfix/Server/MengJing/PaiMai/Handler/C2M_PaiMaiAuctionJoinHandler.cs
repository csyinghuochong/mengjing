using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_PaiMaiAuctionJoinHandler : MessageHandler<Unit, C2M_PaiMaiAuctionJoinRequest, M2C_PaiMaiAuctionJoinResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PaiMaiAuctionJoinRequest request, M2C_PaiMaiAuctionJoinResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {
                ActorId paimaiserverid = UnitCacheHelper.GetPaiMaiServerId(unit.Zone());
                P2M_PaiMaiAuctionJoinResponse r_GameStatusResponse = (P2M_PaiMaiAuctionJoinResponse)await unit.Root().GetComponent<MessageSender>().Call
                        (paimaiserverid, new M2P_PaiMaiAuctionJoinRequest()
                        {
                            UnitID = unit.Id,
                            Gold = unit.GetComponent<UserInfoComponentS>().UserInfo.Gold
                        });

                if (r_GameStatusResponse.Error == ErrorCode.ERR_Success)
                {
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, (-1 * r_GameStatusResponse.CostGold).ToString(), true, ItemGetWay.AuctionJoin);
                }
                response.Error = r_GameStatusResponse.Error;
            }
            await ETTask.CompletedTask;
        }
    }
}
