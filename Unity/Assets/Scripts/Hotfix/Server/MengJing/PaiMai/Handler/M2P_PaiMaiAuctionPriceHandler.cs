namespace ET.Server
{
    [MessageHandler(SceneType.PaiMai)]
    public class M2P_PaiMaiAuctionPriceHandler : MessageHandler<Scene, M2P_PaiMaiAuctionPriceRequest, P2M_PaiMaiAuctionPriceResponse>
    {
        protected override async ETTask Run(Scene scene, M2P_PaiMaiAuctionPriceRequest message, P2M_PaiMaiAuctionPriceResponse response)
        {
            PaiMaiSceneComponent paiMaiSceneComponent = scene.GetComponent<PaiMaiSceneComponent>();
            if (paiMaiSceneComponent.AuctionStatus != 1)
            {
                response.Error = ErrorCode.Err_Auction_Finish;
                return;
            }
            if (paiMaiSceneComponent.AuctionPrice >= message.Price)
            {
                response.Error = ErrorCode.Err_Auction_Low;
                return;
            }

            paiMaiSceneComponent.AuctionPrice = message.Price;
            paiMaiSceneComponent.AuctioUnitId = message.UnitID;
            paiMaiSceneComponent.AuctionPlayer = message.AuctionPlayer;

            PaiMaiAuctionRecord keyValuePair = PaiMaiAuctionRecord.Create();
            keyValuePair.UnionId = message.UnitID;
            keyValuePair.Price = message.Price;
            keyValuePair.Time = TimeHelper.ServerNow();
            keyValuePair.Occ = message.Occ;
            keyValuePair.PlayerName = message.AuctionPlayer;
            paiMaiSceneComponent.AuctionRecords.Add(keyValuePair);
            BroadCastHelper.SendServerMessage(scene.Root(), UnitCacheHelper.GetChatServerId(scene.Zone()), NoticeType.PaiMaiAuction,
                $"{paiMaiSceneComponent.AuctionItem}_{paiMaiSceneComponent.AuctionItemNum}_{message.Price}_{paiMaiSceneComponent.AuctionPlayer}_1").Coroutine();

            await ETTask.CompletedTask;
        }
    }
}
