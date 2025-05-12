using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SeasonStoreItem))]
    [EntitySystemOf(typeof (ES_SeasonStore))]
    [FriendOfAttribute(typeof (ES_SeasonStore))]
    public static partial class ES_SeasonStoreSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SeasonStore self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SeasonStoreItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSeasonStoreItemsRefresh);

            self.UpdateInfo();
        }

        [EntitySystem]
        private static void Destroy(this ES_SeasonStore self)
        {
            self.DestroyWidget();
        }

        private static void OnSeasonStoreItemsRefresh(this ES_SeasonStore self, Transform transform, int index)
        {
            foreach (Scroll_Item_SeasonStoreItem item in self.ScrollItemSeasonStoreItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SeasonStoreItem scrollItemCommonItem = self.ScrollItemSeasonStoreItems[index].BindTrans(transform);
            scrollItemCommonItem.OnUpdateUI(self.ShowItems[index]);
        }

        public static void UpdateInfo(this ES_SeasonStore self)
        {
            int shopid =  GlobalValueConfigCategory.Instance.SeasonStoreId;
            self.E_GoldNumTextText.text = self.Root().GetComponent<BagComponentC>().GetItemNumber(StoreSellConfigCategory.Instance.Get(shopid).SellType).ToString();
            int playLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            
            ItemConfig sellTypeItemConfig = ItemConfigCategory.Instance.Get(StoreSellConfigCategory.Instance.Get(shopid).SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, sellTypeItemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_GoldImgImage.sprite = sp;

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

            self.AddUIScrollItems(ref self.ScrollItemSeasonStoreItems, self.ShowItems.Count);
            self.E_SeasonStoreItemsLoopVerticalScrollRect.SetVisible(true, self.ShowItems.Count);
        }
    }
}
