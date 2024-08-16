namespace ET.Client
{
    [FriendOf(typeof(ES_JueXingShow))]
    [FriendOf(typeof(DlgJueXing))]
    public static class DlgJueXingSystem
    {
        public static void RegisterUIEvent(this DlgJueXing self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgJueXing self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgJueXing self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewNodeRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_JueXingShow.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
