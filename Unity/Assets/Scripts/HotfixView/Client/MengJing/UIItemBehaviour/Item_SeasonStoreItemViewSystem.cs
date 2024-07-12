using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SeasonStoreItem))]
    [EntitySystemOf(typeof(Scroll_Item_SeasonStoreItem))]
    public static partial class Scroll_Item_SeasonStoreItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SeasonStoreItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SeasonStoreItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnBuyBtn(this Scroll_Item_SeasonStoreItem self)
        {
            long glod = self.Root().GetComponent<BagComponentC>()
                    .GetItemNumber(StoreSellConfigCategory.Instance.Get(self.StoreSellConfigId).SellType);
            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(self.StoreSellConfigId);

            if (glod < storeSellConfig.SellValue)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("货币不足！");
                return;
            }

            await BagClientNetHelper.RquestStoreBuy(self.Root(), self.StoreSellConfigId, 1);

            self.GetParent<ES_SeasonStore>().UpdateInfo();
        }

        public static void OnUpdateUI(this Scroll_Item_SeasonStoreItem self, int id)
        {
            self.E_BuyBtnButton.AddListenerAsync(self.OnBuyBtn);

            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(id);
            self.StoreSellConfigId = id;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(storeSellConfig.SellItemID);

            BagInfo bagInfo = BagInfo.Create();
            bagInfo.ItemID = storeSellConfig.SellItemID;
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem.HideItemName();
            self.E_NameTextText.text = $"<color=\"#{CommonHelp.QualityReturnColor(itemConfig.ItemQuality)}\">{itemConfig.ItemName}</color>";
            self.E_ValueTextText.text = storeSellConfig.SellValue.ToString();

            ItemConfig sellTypeItemConfig = ItemConfigCategory.Instance.Get(storeSellConfig.SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, sellTypeItemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_GoldImgImage.sprite = sp;
        }
    }
}