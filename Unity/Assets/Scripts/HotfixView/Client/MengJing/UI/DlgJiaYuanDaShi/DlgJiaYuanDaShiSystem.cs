namespace ET.Client
{
    [FriendOf(typeof(ES_JiaYuanDaShiPro))]
    [FriendOf(typeof(ES_JiaYuanDaShiShow))]
    [FriendOf(typeof(DlgJiaYuanDaShi))]
    public static class DlgJiaYuanDaShiSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanDaShi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgJiaYuanDaShi self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgJiaYuanDaShi self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_JiaYuanDaShiPro.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JiaYuanDaShiPro.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_JiaYuanDaShiShow.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JiaYuanDaShiShow.OnUpdateUI();
                    break;
            }
        }
    }
}