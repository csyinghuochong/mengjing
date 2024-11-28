namespace ET.Client
{
    [FriendOf(typeof (ES_FenXiangSet))]
    [FriendOf(typeof (ES_Popularize))]
    [FriendOf(typeof (ES_Serial))]
    [FriendOf(typeof (ES_LunTan))]
    [FriendOf(typeof (ES_FenXiangQQAddSet))]
    [FriendOf(typeof (DlgFenXiang))]
    public static class DlgFenXiangSystem
    {
        public static void RegisterUIEvent(this DlgFenXiang self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgFenXiang self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgFenXiang self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_FenXiangSet.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_Popularize.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_Serial.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_LunTan.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.View.ES_FenXiangQQAddSet.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
