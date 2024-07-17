using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static class PaiMaiHelper
    {
        public static List<int> GetChaptersByType(PaiMaiTypeEnum pype)
        {
            return PaiMaiData.PaiMaiTypeData[(int)pype].PaiMaiIDItemList.Keys.ToList();
        }

        public static List<int> GetItemsByChapter(int typeid, int chapterId)
        {
            return PaiMaiData.PaiMaiTypeData[typeid].PaiMaiIDItemList[chapterId];
        }

        public static long GetPaiMaiId(int itemType)
        {
            return 1000 + (int)itemType;
        }

        public static void InitPaiMaiData()
        {
            for (int i = 0; i < (int)PaiMaiTypeEnum.Number + 1; i++)
            {
                PaiMaiData.PaiMaiTypeData.Add(new PaiMaiTypeData());
            }

            Dictionary<int, PaiMaiSellConfig> allPaiMaiData = PaiMaiSellConfigCategory.Instance.GetAll();
            foreach (var item in allPaiMaiData)
            {
                PaiMaiSellConfig paiMaiSellConfig = item.Value;
                int paiMaiType = paiMaiSellConfig.PaiMaiType;
                int chapterId = paiMaiSellConfig.ChapterId;
                PaiMaiTypeData paiMaiTypeDatas = PaiMaiData.PaiMaiTypeData[paiMaiType];
                if (!paiMaiTypeDatas.PaiMaiIDItemList.ContainsKey(chapterId))
                {
                    paiMaiTypeDatas.PaiMaiIDItemList.Add(chapterId, new List<int>());
                }

                paiMaiTypeDatas.PaiMaiIDItemList[chapterId].Add(item.Key);
            }
        }

        //初始化拍卖行快捷购买数据
        public static List<PaiMaiShopItemInfo> InitPaiMaiShopItemList(List<PaiMaiShopItemInfo> shopItemList = null)
        {
            Dictionary<int, PaiMaiSellConfig> allPaiMaiData = PaiMaiSellConfigCategory.Instance.GetAll();

            List<PaiMaiShopItemInfo> shopListInfos = new List<PaiMaiShopItemInfo>();

            //写入缓存
            Dictionary<long, PaiMaiShopItemInfo> dicInfos = new Dictionary<long, PaiMaiShopItemInfo>();
            if (shopItemList != null)
            {
                //如果列表一样，则直接返回数据
                if (allPaiMaiData.Count == shopItemList.Count)
                {
                    return shopItemList;
                }

                foreach (PaiMaiShopItemInfo info in shopItemList)
                {
                    if (dicInfos.ContainsKey(info.Id) == false)
                    {
                        dicInfos.Add(info.Id, info);
                    }
                }
            }

            foreach (var item in allPaiMaiData)
            {
                PaiMaiShopItemInfo shopList = PaiMaiShopItemInfo.Create();
                if (item.Value.Price.Length < 2)
                {
                    Log.Debug($"item.Value.Price: {item.Value.Id} {item.Value.Price.Length}");
                }

                if (dicInfos.ContainsKey(item.Value.Id) == false)
                {
                    shopList.ItemNumber = 999;
                    shopList.Id = item.Value.ItemID;
                    shopList.PriceType = item.Value.Price[0];
                    shopList.Price = item.Value.Price[1];
                    shopList.PricePro = 1;
                    shopListInfos.Add(shopList);
                }
            }

            return shopListInfos;
        }

        public static int GetPaiMaiSellId(int itemid)
        {
            int sellid = 0;
            foreach (var item in PaiMaiSellConfigCategory.Instance.GetAll())
            {
                if (item.Value.ItemID == itemid)
                {
                    return item.Key;
                }
            }

            return sellid;
        }
    }
}