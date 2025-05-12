using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 查找装备所在拍卖行那一页(待实现)
    /// </summary>
    [MessageHandler(SceneType.PaiMai)]
    public class C2P_PaiMaiFindHandler: MessageHandler<Scene, C2P_PaiMaiFindRequest, P2C_PaiMaiFindResponse>
    {
        protected override async ETTask Run(Scene scene, C2P_PaiMaiFindRequest request, P2C_PaiMaiFindResponse response)
        {
            if (request.ItemType == 0)
            {
                response.Page = 0;
                return;
            }
            PaiMaiSceneComponent paiMaiComponent = scene.GetComponent<PaiMaiSceneComponent>();
            DBPaiMainInfo dBPaiMainInfo = paiMaiComponent.GetPaiMaiDBByType(request.ItemType);
            if (dBPaiMainInfo == null)
            {
                response.Page = 0;
                return;
            }

            List<PaiMaiItemInfo> PaiMaiItemInfo = dBPaiMainInfo.PaiMaiItemInfos;

            PaiMaiItemInfo paiMaiItemInfo = null;
            for (int i = 0; i < PaiMaiItemInfo.Count; i++)
            {
                if (PaiMaiItemInfo[i].Id == request.PaiMaiItemInfoId)
                {
                    paiMaiItemInfo = PaiMaiItemInfo[i];
                    break;
                }
            }

            if (paiMaiItemInfo == null)
            {
                response.Page = 0;
                return;
            }

            int pagenum = GlobalValueConfigCategory.Instance.PaiMaiPageNum; //每页的数量
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
            for (int i = 0; i < PaiMaiItemInfo.Count; i++)
            {
                if (PaiMaiItemInfo[i].Id == paiMaiItemInfo.Id)
                {
                    response.Page = i / pagenum + 1;
                    return;
                }
            }
            response.Page = 0;
            await ETTask.CompletedTask;
        }
    }
}