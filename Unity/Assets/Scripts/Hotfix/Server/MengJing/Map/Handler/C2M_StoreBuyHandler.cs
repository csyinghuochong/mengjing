using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_StoreBuyHandler : MessageLocationHandler<Unit, C2M_StoreBuyRequest, M2C_StoreBuyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_StoreBuyRequest request, M2C_StoreBuyResponse response)
        {
            if (!StoreSellConfigCategory.Instance.Contain(request.SellItemID))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(request.SellItemID);
            if (storeSellConfig == null)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
                return;
            }

            int buynumber =  unit.GetComponent<UserInfoComponentS>().GetStoreBuy(storeSellConfig.Id);
            // if (storeSellConfig.LimitNumber >0 && request.SellItemNum +  buynumber > storeSellConfig.LimitNumber)
            // {
            //     response.Error = ErrorCode.ERR_BuyMaxLimit;
            //     reply();
            //     return;
            // }

            int needCell = ItemHelper.GetNeedCell($"{storeSellConfig.SellItemID};{storeSellConfig.SellItemNum * request.SellItemNum}");
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < needCell)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            //购买限制
            if (request.SellItemNum <= 0) {
                request.SellItemNum = 1;
            }

            if (request.SellItemNum >= 100)
            {
                request.SellItemNum = 100;
            }

            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            List<RewardItem> rewardItems = new List<RewardItem>();
            rewardItems.Add(new RewardItem() { ItemID = storeSellConfig.SellItemID, ItemNum = storeSellConfig.SellItemNum * request.SellItemNum });

            int costType = storeSellConfig.SellType;
            string costValue = (-1 * storeSellConfig.SellValue * request.SellItemNum).ToString();

            switch (costType)
            {
                case 1:
                    if (userInfo.Gold < storeSellConfig.SellValue * request.SellItemNum)
                    {
                        response.Error = ErrorCode.ERR_GoldNotEnoughError;
                    }
                    else
                    {
                        unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, costValue);
                        unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.StoreBuy}_{TimeHelper.ServerNow()}");
                        response.Error = ErrorCode.ERR_Success;
                    }
                    break;
                case 3:
                    if (userInfo.Diamond < storeSellConfig.SellValue * request.SellItemNum)
                    {
                        response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                    }
                    else
                    {
                        unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, costValue, true, ItemGetWay.CostItem);
                        unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.StoreBuy}_{TimeHelper.ServerNow()}");
                        response.Error = ErrorCode.ERR_Success;
                    }
                    break;
                default:
                    if (unit.GetComponent<BagComponentS>().GetItemNumber(costType) < storeSellConfig.SellValue * request.SellItemNum)
                    {
                        response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    }
                    else
                    {
                        unit.GetComponent<BagComponentS>().OnCostItemData($"{costType};{storeSellConfig.SellValue * request.SellItemNum}");
                        unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.StoreBuy}_{TimeHelper.ServerNow()}");
                    }
                    break;
            }

            // if (response.Error == ErrorCode.ERR_Success && storeSellConfig.LimitNumber > 0)
            // {
            //     unit.GetComponent<UserInfoComponent>().OnStoreBuy( storeSellConfig.Id );
            // }
            await ETTask.CompletedTask;
        }
    }
}
