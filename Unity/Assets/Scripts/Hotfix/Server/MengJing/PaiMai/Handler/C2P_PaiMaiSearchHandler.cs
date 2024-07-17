namespace ET.Server
{
    [MessageHandler(SceneType.PaiMai)]
    public class C2P_PaiMaiSearchHandler: MessageHandler<Scene, C2P_PaiMaiSearchRequest, P2C_PaiMaiSearchResponse>
    {
        protected override async ETTask Run(Scene scene, C2P_PaiMaiSearchRequest request, P2C_PaiMaiSearchResponse response)
        {
            if (request.FindTypeList.Count <= 0)
            {
                return;
            }

            if (request.FindItemIdList.Count <= 0)
            {
                return;
            }

            PaiMaiSceneComponent paiMaiComponent = scene.GetComponent<PaiMaiSceneComponent>();
            foreach (int type in request.FindTypeList)
            {
                DBPaiMainInfo dBPaiMainInfo = paiMaiComponent.GetPaiMaiDBByType(type);
                if (dBPaiMainInfo == null)
                {
                    return;
                }

                foreach (PaiMaiItemInfo paiMaiItemInfo in dBPaiMainInfo.PaiMaiItemInfos)
                {
                    if (request.FindItemIdList.Contains(paiMaiItemInfo.BagInfo.ItemID))
                    {
                        response.PaiMaiItemInfos.Add(paiMaiItemInfo);

                        if (response.PaiMaiItemInfos.Count > 200)
                        {
                            break;
                        }
                    }
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}