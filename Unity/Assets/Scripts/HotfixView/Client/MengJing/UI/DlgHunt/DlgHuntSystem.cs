namespace ET.Client
{
    [FriendOf(typeof (ES_HuntRanking))]
    [FriendOf(typeof (ES_HuntTask))]
    [FriendOf(typeof (DlgHunt))]
    public static class DlgHuntSystem
    {
        public static void RegisterUIEvent(this DlgHunt self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgHunt self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgHunt self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_HuntRanking.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_HuntTask.uiTransform.gameObject.SetActive(true);
                    self.View.ES_HuntTask.OnUpdateUI();
                    break;
            }
        }
    }
}
