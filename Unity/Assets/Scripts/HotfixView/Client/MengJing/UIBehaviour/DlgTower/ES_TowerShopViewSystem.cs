using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TowerShopItem))]
    [FriendOf(typeof(Scroll_Item_WeiJingShopItem))]
    [EntitySystemOf(typeof(ES_TowerShop))]
    [FriendOfAttribute(typeof(ES_TowerShop))]
    public static partial class ES_TowerShopSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TowerShop self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_TowerShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTowerShopItemsRefresh);

            self.UpdateInfo();
        }

        [EntitySystem]
        private static void Destroy(this ES_TowerShop self)
        {
            self.DestroyWidget();
        }

        private static void OnTowerShopItemsRefresh(this ES_TowerShop self, Transform transform, int index)
        {
            foreach (Scroll_Item_TowerShopItem item in self.ScrollItemTowerShopItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_TowerShopItem scrollItemTowerShopItem = self.ScrollItemTowerShopItems[index].BindTrans(transform);
            scrollItemTowerShopItem.OnUpdateUI(self.ShowItems[index]);
        }

        public static void UpdateInfo(this ES_TowerShop self)
        {
            int shopid = GlobalValueConfigCategory.Instance.TowerShopId;
            int playLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            using (zstring.Block())
            {
                self.E_Lab_NumText.text = zstring.Format("当前拥有数量:{0}",
                    self.Root().GetComponent<BagComponentC>().GetItemNumber(StoreSellConfigCategory.Instance.Get(shopid).SellType).ToString());
            }

            self.ShowItems.Clear();
            while (shopid > 0)
            {
                StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(shopid);

                if (playLv < storeSellConfig.ShowRoleLvMin || playLv > storeSellConfig.ShowRoleLvMax)
                {
                    shopid = storeSellConfig.NextID;
                    continue;
                }

                self.ShowItems.Add(shopid);
                shopid = storeSellConfig.NextID;
            }

            self.AddUIScrollItems(ref self.ScrollItemTowerShopItems, self.ShowItems.Count);
            self.E_TowerShopItemsLoopVerticalScrollRect.SetVisible(true, self.ShowItems.Count);
        }
    }
}