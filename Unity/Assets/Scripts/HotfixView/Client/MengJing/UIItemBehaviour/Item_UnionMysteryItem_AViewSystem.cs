using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionMysteryItem_A))]
    [EntitySystemOf(typeof(Scroll_Item_UnionMysteryItem_A))]
    public static partial class Scroll_Item_UnionMysteryItem_ASystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_UnionMysteryItem_A self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_UnionMysteryItem_A self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonBuy(this Scroll_Item_UnionMysteryItem_A self)
        {
            int leftSpace = self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag);
            if (leftSpace < 1)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(self.MysteryItemInfo.MysteryId);
            int sellValue = mysteryConfig.SellValue;

            if (mysteryConfig.SellType == 1 && self.Root().GetComponent<UserInfoComponentC>().UserInfo.Gold < sellValue)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_GoldNotEnoughError);
                return;
            }

            if (mysteryConfig.SellType == 3 && self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond < sellValue)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
                return;
            }

            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem($"{mysteryConfig.SellType};{mysteryConfig.SellValue}"))
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNotEnoughError);
                return;
            }

            await UnionNetHelper.UnionMysteryBuyRequest(self.Root(), self.MysteryItemInfo.MysteryId, 1);

            self.GetParent<ES_UnionMystery_A>()?.RequestMystery().Coroutine();
        }

        public static void OnUpdateUI(this Scroll_Item_UnionMysteryItem_A self, MysteryItemInfo mysteryItemInfo)
        {
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryItemInfo.MysteryId);
            self.MysteryItemInfo = mysteryItemInfo;
            using (zstring.Block())
            {
                self.E_Text_NumberText.text = zstring.Format("剩余 {0}件", mysteryItemInfo.ItemNumber);
            }

            self.E_Text_valueText.text = mysteryConfig.SellValue.ToString();

            self.ES_CommonItem.UseTextColor = true;
            self.ES_CommonItem.UpdateItem(new() { ItemID = self.MysteryItemInfo.ItemID }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemQualityImage.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            self.ES_CommonItem.E_ItemNameText.GetComponent<Outline>().effectColor = FunctionUI.QualityReturnColor(ItemConfigCategory.Instance.Get(self.MysteryItemInfo.ItemID).ItemQuality);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(mysteryConfig.SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_goldImage.sprite = sp;
            
            ItemConfig itemConfig1 = ItemConfigCategory.Instance.Get(mysteryConfig.SellItemID);
            string qualityiconStr = FunctionUI.BigItemQualiytoPath(itemConfig1.ItemQuality);
            string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);
            self.E_Image_bg.sprite = sp1;
        }
    }
}