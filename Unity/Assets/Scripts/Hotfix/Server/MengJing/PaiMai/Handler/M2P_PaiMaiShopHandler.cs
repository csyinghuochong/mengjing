using System;

namespace ET.Server
{

    [MessageHandler(SceneType.PaiMai)]
    public class M2P_PaiMaiShopHandler : MessageHandler<Scene, M2P_PaiMaiShopRequest, P2M_PaiMaiShopResponse>
    {

        protected override async ETTask Run(Scene scene, M2P_PaiMaiShopRequest request, P2M_PaiMaiShopResponse response)
        {
            try
            {
                //获取当前的数据
                PaiMaiSceneComponent paimaiCompontent = scene.GetComponent<PaiMaiSceneComponent>();
                response.PaiMaiShopItemInfo = paimaiCompontent.GetPaiMaiShopInfo(request.ItemID);

                long costGold = response.PaiMaiShopItemInfo.Price * request.BuyNum;
                if (request.ActorId < costGold || costGold < 0)
                {
                    response.Error = ErrorCode.ERR_GoldNotEnoughError;
                    return;
                }

                //后面记录购买的数量
                paimaiCompontent.PaiMaiShopInfoAddBuyNum(request.ItemID, request.BuyNum);
               
                //返回消息
                await ETTask.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}
