namespace ET.Client
{
    [FriendOf(typeof(ES_ZhanQuLevel))]
    [FriendOf(typeof(ES_ZhanQuCombat))]
    [FriendOf(typeof(ES_FirstWin))]
    [FriendOf(typeof(DlgZhanQu))]
    public static class DlgZhanQuSystem
    {
        public static void RegisterUIEvent(this DlgZhanQu self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgZhanQu self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgZhanQu self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.ES_ZhanQuLevel.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.ES_ZhanQuCombat.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.ES_FirstWin.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void OnClickGoToFirstWin(this DlgZhanQu self, int bossId)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(2);
            self.ES_FirstWin.BossId = bossId;
        }
    }
}