using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MysteryItem))]
    [EntitySystemOf(typeof(Scroll_Item_MysteryItem))]
    public static partial class Scroll_Item_MysteryItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MysteryItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MysteryItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonBuy(this Scroll_Item_MysteryItem self)
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

            using (zstring.Block())
            {
                if (!self.Root().GetComponent<BagComponentC>()
                            .CheckNeedItem(zstring.Format("{0};{1}", mysteryConfig.SellType, mysteryConfig.SellValue)))
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNotEnoughError);
                    return;
                }
            }

            MysteryItemInfo mysteryItemInfo = new() { MysteryId = self.MysteryItemInfo.MysteryId };

            await BagClientNetHelper.RquestMysteryBuy(self.Root(), mysteryItemInfo, self.NpcId);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMystery>().RequestMystery().Coroutine();
        }

        public static void OnUpdateUI(this Scroll_Item_MysteryItem self, MysteryItemInfo mysteryItemInfo, int npcId)
        {
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);

            self.NpcId = npcId;

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryItemInfo.MysteryId);
            self.MysteryItemInfo = mysteryItemInfo;
            using (zstring.Block())
            {
                self.E_Text_NumberText.text = zstring.Format("剩余 {0}件", mysteryItemInfo.ItemNumber);
            }

            self.E_Text_valueText.text = mysteryConfig.SellValue.ToString();

            ItemInfo bagInfoNew = new ItemInfo();
            bagInfoNew.ItemID = self.MysteryItemInfo.ItemID;
            self.ES_CommonItem.UpdateItem(bagInfoNew, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(mysteryConfig.SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_Image_goldImage.sprite = sp;
        }
    }
}