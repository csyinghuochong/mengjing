namespace ET.Client
{
    [FriendOf(typeof (ES_ActivityYueKa))]
    [FriendOf(typeof (ES_ActivityMaoXian))]
    [FriendOf(typeof (ES_ActivityToken))]
    [FriendOf(typeof (ES_ActivityTeHui))]
    [FriendOf(typeof (ES_ActivitySingleRecharge))]
    [FriendOf(typeof (DlgActivity))]
    public static class DlgActivitySystem
    {
        public static void RegisterUIEvent(this DlgActivity self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.SingleRecharge, self.Reddot_SingleRecharge);
        }

        public static void ShowWindow(this DlgActivity self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void BeforeUnload(this DlgActivity self)
        {
            ReddotViewComponent redPointComponent = self.Root()?.GetComponent<ReddotViewComponent>();
            redPointComponent?.UnRegisterReddot(ReddotType.SingleRecharge, self.Reddot_SingleRecharge);
        }
        
        public static void Reddot_SingleRecharge(this DlgActivity self, int num)
        {
            self.View.E_Type_4Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void OnFunctionSetBtn(this DlgActivity self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.ES_ActivityYueKa.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.ES_ActivityMaoXian.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.ES_ActivityToken.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.ES_ActivityTeHui.uiTransform.gameObject.SetActive(true);
                    self.ES_ActivityTeHui.OnUpdateUI();
                    break;
                case 4:
                    self.ES_ActivitySingleRecharge.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
