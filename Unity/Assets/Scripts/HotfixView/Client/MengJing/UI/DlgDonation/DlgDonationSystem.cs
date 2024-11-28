namespace ET.Client
{
    [FriendOf(typeof (ES_DonationShow))]
    [FriendOf(typeof (ES_DonationUnion))]
    [FriendOf(typeof (ES_RankUnion))]
    [FriendOf(typeof (DlgDonation))]
    public static class DlgDonationSystem
    {
        public static void RegisterUIEvent(this DlgDonation self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgDonation self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgDonation self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_DonationShow.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_DonationUnion.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_RankUnion.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
