using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
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
            Scroll_Item_SeasonStoreItem scrollItemCommonItem = self.ScrollItemSeasonStoreItems[index].BindTrans(transform);
            scrollItemCommonItem.OnUpdateUI(self.ShowItems[index]);
        }

        public static void UpdateInfo(this ES_SeasonStore self)
        {
            int seasonShopid = GlobalValueConfigCategory.Instance.Get(103).Value2;
            self.E_GoldNumTextText.text = self.Root().GetComponent<BagComponentC>()
                    .GetItemNumber(StoreSellConfigCategory.Instance.Get(seasonShopid).SellType).ToString();

            ItemConfig sellTypeItemConfig = ItemConfigCategory.Instance.Get(StoreSellConfigCategory.Instance.Get(seasonShopid).SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, sellTypeItemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_GoldImgImage.sprite = sp;

            self.ShowItems.Clear();
            while (seasonShopid > 0)
            {
                self.ShowItems.Add(seasonShopid);

                StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(seasonShopid);
                seasonShopid = storeSellConfig.NextID;
            }

            self.AddUIScrollItems(ref self.ScrollItemSeasonStoreItems, self.ShowItems.Count);
            self.E_SeasonStoreItemsLoopVerticalScrollRect.SetVisible(true, self.ShowItems.Count);
        }
    }
}