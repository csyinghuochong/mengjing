namespace ET.Server
{

    [MessageHandler(SceneType.PaiMai)]
    public class M2P_PaiMaiAuctionJoinHandler : MessageHandler<Scene, M2P_PaiMaiAuctionJoinRequest, P2M_PaiMaiAuctionJoinResponse>
    {
        protected override async ETTask Run(Scene scene, M2P_PaiMaiAuctionJoinRequest request, P2M_PaiMaiAuctionJoinResponse response)
        {
            PaiMaiSceneComponent paiMaiSceneComponent = scene.GetComponent<PaiMaiSceneComponent>();
            long returngold = (int)(paiMaiSceneComponent.AuctionStart * 0.1f);
            if (returngold <= 0)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }
            if (request.Gold < returngold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }
            if (paiMaiSceneComponent.AuctionStatus != 1)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }

            if (!paiMaiSceneComponent.AuctionJoinList.Contains(request.UnitID))
            {
                paiMaiSceneComponent.AuctionJoinList.Add(request.UnitID);
                response.CostGold = returngold;
            }
            else
            {
                response.CostGold = 0;
            }

            await ETTask.CompletedTask;
        }
    }
}
