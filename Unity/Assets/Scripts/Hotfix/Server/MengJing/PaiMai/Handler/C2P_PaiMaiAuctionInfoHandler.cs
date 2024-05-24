﻿using System;

namespace ET
{

    [ActorMessageHandler]
    public class C2P_PaiMaiAuctionInfoHandler : AMActorRpcHandler<Scene, C2P_PaiMaiAuctionInfoRequest, P2C_PaiMaiAuctionInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2P_PaiMaiAuctionInfoRequest request, P2C_PaiMaiAuctionInfoResponse response, Action reply)
        {
            PaiMaiSceneComponent paiMaiSceneComponent = scene.GetComponent<PaiMaiSceneComponent>();
            response.AuctionStatus  = paiMaiSceneComponent.AuctionStatus;
            response.AuctionPrice   = paiMaiSceneComponent.AuctionPrice;
            response.AuctionItem    = paiMaiSceneComponent.AuctionItem;
            response.AuctionNumber = paiMaiSceneComponent.AuctionItemNum;
            response.AuctionPlayer = paiMaiSceneComponent.AuctionPlayer;
            response.AuctionStart = paiMaiSceneComponent.AuctionStart;
            response.AuctionJoin = paiMaiSceneComponent.AuctionJoinList.Contains(request.UnitId);

            reply();
            await ETTask.CompletedTask;
        }
    }
}
