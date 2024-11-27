namespace ET.Client
{
    [FriendOf(typeof (ES_PetTuJian))]
    [FriendOf(typeof (ES_ChengJiuJingling))]
    [FriendOf(typeof (ES_ChengJiuShow))]
    [FriendOf(typeof (ES_ChengJiuReward))]
    [FriendOf(typeof (DlgChengJiu))]
    public static class DlgChengJiuSystem
    {
        public static void RegisterUIEvent(this DlgChengJiu self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgChengJiu self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgChengJiu self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.ES_ChengJiuReward.uiTransform.gameObject.SetActive(true);
                    self.ES_ChengJiuReward.OnUpdateUI();
                    break;
                case 1:
                    self.ES_ChengJiuShow.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.ES_ChengJiuJingling.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_ChengJiuPetTuJian.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.ES_PetTuJian.uiTransform.gameObject.SetActive(true);
                    self.ES_PetTuJian.OnUpdateUI();
                    break;
            }
        }
    }
}
