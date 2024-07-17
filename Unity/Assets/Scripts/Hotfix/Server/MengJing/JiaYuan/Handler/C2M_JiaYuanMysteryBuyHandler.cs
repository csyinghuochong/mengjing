using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanMysteryBuyHandler : MessageLocationHandler<Unit, C2M_JiaYuanMysteryBuyRequest, M2C_JiaYuanMysteryBuyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanMysteryBuyRequest request, M2C_JiaYuanMysteryBuyResponse response)
        {
            int mysteryId = request.MysteryId;

            if (!MysteryConfigCategory.Instance.Contain(mysteryId))
            {
                Log.Error($"C2M_JiaYuanMysteryBuyRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryId);
            if (mysteryConfig == null)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }

            if (!unit.GetComponent<BagComponentS>().CheckCostItem($"{mysteryConfig.SellType};{mysteryConfig.SellValue}"))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            if (request.ProductId != -1)
            {
                List<MysteryItemInfo> jiayuanList = new List<MysteryItemInfo>();
                if (unit.GetComponent<JiaYuanComponentS>().NowOpenNpcId == 30000001)
                {
                    jiayuanList = unit.GetComponent<JiaYuanComponentS>().PlantGoods_7;
                }

                if (unit.GetComponent<JiaYuanComponentS>().NowOpenNpcId == 30000013)
                {
                    jiayuanList = unit.GetComponent<JiaYuanComponentS>().JiaYuanStore;
                }

                int errorCode = unit.GetComponent<JiaYuanComponentS>().OnMysteryBuyRequest(request.ProductId, jiayuanList);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    response.Error = errorCode;
                    return;
                }
                response.MysteryItemInfos = jiayuanList;
            }
            //unit.GetComponent<UserInfoComponent>().OnMysteryBuy(mysteryId);
            //扣除货币添加对应道具
            unit.GetComponent<BagComponentS>().OnCostItemData($"{mysteryConfig.SellType};{mysteryConfig.SellValue}");
            unit.GetComponent<BagComponentS>().OnAddItemData($"{mysteryConfig.SellItemID};1",
                $"{ItemGetWay.MysteryBuy}_{TimeHelper.ServerNow()}");
            
            await ETTask.CompletedTask;
        }
    }
}
