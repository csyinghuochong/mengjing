namespace ET.Server
{
    [MessageHandler(SceneType.PaiMai)]
    public class M2P_StallSellHandler: MessageHandler<Scene, M2P_StallSellRequest, P2M_StallSellResponse>
    {
        protected override async ETTask Run(Scene scene, M2P_StallSellRequest request, P2M_StallSellResponse response)
        {
            //判定出售价格最低不能低于快捷拍卖列表的50%
            PaiMaiShopItemInfo shopinfo = scene.GetComponent<PaiMaiSceneComponent>().GetPaiMaiShopInfo(request.PaiMaiItemInfo.BagInfo.ItemID);
            if (shopinfo != null)
            {
                int nowPrice = (int)((float)request.PaiMaiItemInfo.Price);
                if (nowPrice < shopinfo.Price * 0.5f)
                {
                    response.Error = ErrorCode.Err_PaiMaiPriceLow;

                    return;
                }
            }
            scene.GetComponent<PaiMaiSceneComponent>().dBPaiMainInfo_Stall.StallItemInfos.Add(request.PaiMaiItemInfo);
            await ETTask.CompletedTask;
        }
    }
}