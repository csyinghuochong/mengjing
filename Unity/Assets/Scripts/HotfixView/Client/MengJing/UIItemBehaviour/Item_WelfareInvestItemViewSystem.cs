namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_WelfareInvestItem))]
    [EntitySystemOf(typeof(Scroll_Item_WelfareInvestItem))]
    public static partial class Scroll_Item_WelfareInvestItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_WelfareInvestItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_WelfareInvestItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_WelfareInvestItem self, int day)
        {
            self.E_InvestBtnButton.AddListenerAsync(self.OnInvestBtn);

            self.Day = day;

            using (zstring.Block())
            {
                self.E_DayTextText.text = zstring.Format("第{0}天", day + 1);
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(ConfigData.WelfareInvestList[day].Value.Split(';')[0]));

            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = itemConfig.Id;
            bagInfo.ItemNum = 1;
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);

            using (zstring.Block())
            {
                self.E_InvestTextText.text = zstring.Format("投资{0}金币", ConfigData.WelfareInvestList[day].KeyId);
            }

            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.WelfareInvestList.Contains(day))
            {
                self.E_InvestBtnButton.gameObject.SetActive(false);
                self.E_InvestedImgImage.gameObject.SetActive(true);
            }
            else
            {
                self.E_InvestBtnButton.gameObject.SetActive(true);
                self.E_InvestedImgImage.gameObject.SetActive(false);
            }
        }

        public static async ETTask OnInvestBtn(this Scroll_Item_WelfareInvestItem self)
        {
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.WelfareInvestList.Contains(self.Day))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经进行了投资!");
                return;
            }

            if (self.Root().GetComponent<UserInfoComponentC>().GetCrateDay() - 1 < self.Day)
            {
                FlyTipComponent.Instance.ShowFlyTip("今天还不能进行该项投资!");
                return;
            }

            M2C_WelfareInvestResponse response = await ActivityNetHelper.WelfareInvest(self.Root(), self.Day);

            if (response.Error == ErrorCode.ERR_Success)
            {
                self.E_InvestBtnButton.gameObject.SetActive(false);
                self.E_InvestedImgImage.gameObject.SetActive(true);

                self.GetParent<ES_WelfareInvest>().UpdateInfo();
            }
        }
    }
}