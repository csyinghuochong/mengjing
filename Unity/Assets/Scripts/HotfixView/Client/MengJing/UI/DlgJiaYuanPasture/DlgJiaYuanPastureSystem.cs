namespace ET.Client
{
    [FriendOf(typeof (ES_JiaYuanPasture_A))]
    [FriendOf(typeof (ES_JiaYuanPasture_B))]
    [FriendOf(typeof (DlgJiaYuanPasture))]
    public static class DlgJiaYuanPastureSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanPasture self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgJiaYuanPasture self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgJiaYuanPasture self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_JiaYuanPasture_A.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JiaYuanPasture_A.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_JiaYuanPasture_B.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
