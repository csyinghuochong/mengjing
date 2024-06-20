using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_DonationShow))]
    [FriendOfAttribute(typeof (ES_DonationShow))]
    public static partial class ES_DonationShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_DonationShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_Donation_2Button.AddListenerAsync(self.OnButton_Donation2);
            self.E_ImageButtonButton.AddListener(() => { self.EG_UIDonationPriceRectTransform.gameObject.SetActive(false); });
            self.E_BtnCloseButton.AddListener(() => { self.EG_UIDonationPriceRectTransform.gameObject.SetActive(false); });
            self.EG_UIDonationPriceRectTransform.gameObject.SetActive(false);
            self.E_Btn_Donation_1Button.AddListener(self.On_Button_Donation);
            self.E_DonationShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDonationShowItemsRefresh);

            self.OnUpdateUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_DonationShow self)
        {
            self.DestroyWidget();
        }

        public static void On_Button_Donation(this ES_DonationShow self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.Lv < 12)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("捐献等级不得小于12级");
                return;
            }

            self.EG_UIDonationPriceRectTransform.gameObject.SetActive(!self.EG_UIDonationPriceRectTransform.gameObject.activeSelf);
        }

        public static async ETTask OnButton_Donation2(this ES_DonationShow self)
        {
            string text = self.E_InputFieldNumberInputField.text;
            int number = int.Parse(text);
            if (number < 100000)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("最低捐献10万金币！");
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
            Scroll_Item_DonationShowItem scrollItemDonationShowItem = self.ScrollItemDonationShowItems[index].BindTrans(transform);
            scrollItemDonationShowItem.OnUpdateUI(index + 1, self.ShowRankingInfos[index]);
        }

        public static async ETTask OnUpdateUI(this ES_DonationShow self)
        {
            // U2C_DonationRankListResponse response = await UnionNetHelper.DonationRankListRequest(self.Root());

            // 测试数据
            U2C_DonationRankListResponse response = new();
            response.RankList.Add(new RankingInfo() { Combat = 300, PlayerLv = 40, PlayerName = "测试角色1", Occ = 1 });
            response.RankList.Add(new RankingInfo() { Combat = 200, PlayerLv = 40, PlayerName = "测试角色2", Occ = 2 });
            response.RankList.Add(new RankingInfo() { Combat = 100, PlayerLv = 40, PlayerName = "测试角色3", Occ = 1 });

            self.ShowRankingInfos = response.RankList;

            self.AddUIScrollItems(ref self.ScrollItemDonationShowItems, self.ShowRankingInfos.Count);
            self.E_DonationShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankingInfos.Count);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.E_Text_MyDonationText.text =
                    $"我已捐献{unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.RaceDonationNumber)}金币";
            self.E_TextMyDonationText.text =
                    $"我已捐献{unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.RaceDonationNumber)}金币";
        }
    }
}