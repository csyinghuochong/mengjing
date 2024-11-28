namespace ET.Client
{
    [FriendOf(typeof (ES_BattleEnter))]
    [FriendOf(typeof (ES_BattleTask))]
    [FriendOf(typeof (ES_BattleShop))]
    [FriendOf(typeof (DlgBattle))]
    public static class DlgBattleSystem
    {
        public static void RegisterUIEvent(this DlgBattle self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgBattle self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgBattle self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_BattleEnter.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_BattleTask.uiTransform.gameObject.SetActive(true);
                    self.View.ES_BattleTask.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_BattleShop.uiTransform.gameObject.SetActive(true);
                    self.View.ES_BattleShop.OnUpdateUI();
                    break;
            }
        }
    }
}
