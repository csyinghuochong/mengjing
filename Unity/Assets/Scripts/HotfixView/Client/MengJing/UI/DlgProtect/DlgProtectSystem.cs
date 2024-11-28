namespace ET.Client
{
    [FriendOf(typeof (ES_ProtectEquip))]
    [FriendOf(typeof (ES_ProtectPet))]
    [FriendOf(typeof (DlgProtect))]
    public static class DlgProtectSystem
    {
        public static void RegisterUIEvent(this DlgProtect self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgProtect self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgProtect self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ProtectEquip.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ProtectEquip.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_ProtectPet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ProtectPet.OnUpdateUI();
                    break;
            }
        }
    }
}
