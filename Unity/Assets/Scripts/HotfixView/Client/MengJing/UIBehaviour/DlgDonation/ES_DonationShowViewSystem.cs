using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_DonationShowItem))]
    [EntitySystemOf(typeof(ES_DonationShow))]
    [FriendOfAttribute(typeof(ES_DonationShow))]
    public static partial class ES_DonationShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_DonationShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_Donation_2Button.AddListenerAsync(self.OnBtn_Donation_2Button);
            self.E_ImageButtonButton.AddListener(() => { self.EG_UIDonationPriceRectTransform.gameObject.SetActive(false); });
            self.E_BtnCloseButton.AddListener(() => { self.EG_UIDonationPriceRectTransform.gameObject.SetActive(false); });
            self.EG_UIDonationPriceRectTransform.gameObject.SetActive(false);
            self.E_Btn_Donation_1Button.AddListener(self.OnBtn_Donation_1Button);
            self.E_DonationShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDonationShowItemsRefresh);

            self.OnUpdateUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_DonationShow self)
        {
            self.DestroyWidget();
        }

        public static void OnBtn_Donation_1Button(this ES_DonationShow self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.Lv < 12)
            {
                FlyTipComponent.Instance.ShowFlyTip("捐献等级不得小于12级");
                return;
            }

            self.EG_UIDonationPriceRectTransform.gameObject.SetActive(!self.EG_UIDonationPriceRectTransform.gameObject.activeSelf);
        }

        public static async ETTask OnBtn_Donation_2Button(this ES_DonationShow self)
        {
            string text = self.E_InputFieldNumberInputField.text;
            int number = int.Parse(text);
            if (number < 100000)
            {
                FlyTipComponent.Instance.ShowFlyTip("最低捐献10万金币！");
                return;
            }

            long instanceid = self.InstanceId;
            await ActivityNetHelper.DonationRequest(self.Root(), number);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.EG_UIDonationPriceRectTransform.gameObject.SetActive(false);
            self.OnUpdateUI().Coroutine();
        }

        private static void OnDonationShowItemsRefresh(this ES_DonationShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_DonationShowItem item in self.ScrollItemDonationShowItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_DonationShowItem scrollItemDonationShowItem = self.ScrollItemDonationShowItems[index].BindTrans(transform);
            scrollItemDonationShowItem.OnUpdateUI(index + 1, self.ShowRankingInfos[index]);
        }

        public static async ETTask OnUpdateUI(this ES_DonationShow self)
        {
            U2C_DonationRankListResponse response = await UnionNetHelper.DonationRankListRequest(self.Root());

            self.ShowRankingInfos = response.RankList;

            self.AddUIScrollItems(ref self.ScrollItemDonationShowItems, self.ShowRankingInfos.Count);
            self.E_DonationShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankingInfos.Count);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.E_Text_MyDonationText.text =
                        zstring.Format("我已捐献{0}金币", unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.RaceDonationNumber));
                self.E_TextMyDonationText.text =
                        zstring.Format("我已捐献{0}金币", unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.RaceDonationNumber));
            }

            await ETTask.CompletedTask;
        }
    }
}
