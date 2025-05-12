using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_DragonDungeonShopItem))]
    [FriendOf(typeof(Scroll_Item_BattleShopItem))]
    [EntitySystemOf(typeof(ES_DragonDungeonShop))]
    [FriendOfAttribute(typeof(ES_DragonDungeonShop))]
    public static partial class ES_DragonDungeonShopSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_DragonDungeonShop self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;

            self.E_DragonDungeonShopItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDragonDungeonShopItemsRefresh);
            
            self.UpdateInfo();
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ES_DragonDungeonShop self)
        {
            self.DestroyWidget();
        }

        public static void UpdateInfo(this ES_DragonDungeonShop self)
        {
            int shopid = GlobalValueConfigCategory.Instance.TeamDungeonShopId;
            self.E_ItemNumText.text = self.Root().GetComponent<BagComponentC>().GetItemNumber(StoreSellConfigCategory.Instance.Get(shopid).SellType).ToString();
            int playLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            
            ItemConfig sellTypeItemConfig = ItemConfigCategory.Instance.Get(StoreSellConfigCategory.Instance.Get(shopid).SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, sellTypeItemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconShowImage.sprite = sp;

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

            self.AddUIScrollItems(ref self.ScrollItemDragonDungeonShopItems, self.ShowItems.Count);
            self.E_DragonDungeonShopItemsLoopVerticalScrollRect.SetVisible(true, self.ShowItems.Count);
        }

        private static void OnDragonDungeonShopItemsRefresh(this ES_DragonDungeonShop self, Transform transform, int index)
        {
            foreach (Scroll_Item_DragonDungeonShopItem item in self.ScrollItemDragonDungeonShopItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_DragonDungeonShopItem scrollItemDragonDungeonShopItem = self.ScrollItemDragonDungeonShopItems[index].BindTrans(transform);
            scrollItemDragonDungeonShopItem.OnUpdateUI(self.ShowItems[index]);
        }
    }
}