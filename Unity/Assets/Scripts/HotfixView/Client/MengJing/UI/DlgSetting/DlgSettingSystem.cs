namespace ET.Client
{
    [FriendOf(typeof(ES_SettingGame))]
    [FriendOf(typeof(ES_SettingTitle))]
    [FriendOf(typeof(ES_SettingGuaJi))]
    [FriendOf(typeof(ES_FashionShow))]
    [FriendOf(typeof(DlgSetting))]
    public static class DlgSettingSystem
    {
        public static void RegisterUIEvent(this DlgSetting self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgSetting self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void OnBeforeClose(this DlgSetting self)
        {
            Log.Debug("关闭Setting前保存设置");
            self.ES_SettingGame.OnBeforeClose();
        }

        private static void OnFunctionSetBtn(this DlgSetting self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.ES_SettingGame.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.ES_SettingTitle.uiTransform.gameObject.SetActive(true);
                    self.ES_SettingTitle.OnUpdateUI();
                    break;
                case 2:
                    self.ES_SettingGuaJi.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.ES_FashionShow.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void OnTitleUse(this DlgSetting self)
        {
            self.ES_SettingTitle.OnUpdateUI();
        }
    }
}