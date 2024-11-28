namespace ET.Client
{
    [FriendOf(typeof(ES_JiaYuanMystery_A))]
    [FriendOf(typeof(ES_JiaYuanMystery_B))]
    [FriendOf(typeof(DlgJiaYuanMystery))]
    public static class DlgJiaYuanMysterySystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanMystery self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgJiaYuanMystery self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgJiaYuanMystery self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_JiaYuanMystery_A.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JiaYuanMystery_A.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_JiaYuanMystery_B.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JiaYuanMystery_B.OnUpdateUI();
                    break;
            }
        }
    }
}