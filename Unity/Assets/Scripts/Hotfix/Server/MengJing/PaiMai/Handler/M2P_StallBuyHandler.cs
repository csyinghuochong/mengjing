using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.PaiMai)]
    public class M2P_StallBuyHandler: MessageHandler<Scene, M2P_StallBuyRequest, P2M_StallBuyResponse>
    {
        protected override async ETTask Run(Scene scene, M2P_StallBuyRequest request, P2M_StallBuyResponse response)
        {
            long needGold = 0;
            PaiMaiItemInfo paiMaiItemInfo = null;
            List<PaiMaiItemInfo> stallItemInfos = scene.GetComponent<PaiMaiSceneComponent>().dBPaiMainInfo_Stall.StallItemInfos;
            for (int i = stallItemInfos.Count - 1; i >= 0; i--)
            {
                if (stallItemInfos[i].Id == request.PaiMaiItemInfo.Id)
                {
                    paiMaiItemInfo = stallItemInfos[i];
                    break;
                }
            }

            if (paiMaiItemInfo == null)
            {
                return;
            }

            needGold = (long)paiMaiItemInfo.Price * paiMaiItemInfo.BagInfo.ItemNum;
            if (request.ActorId < needGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            response.PaiMaiItemInfo = paiMaiItemInfo;
            stallItemInfos.Remove(paiMaiItemInfo);
            await ETTask.CompletedTask;
        }
    }
}