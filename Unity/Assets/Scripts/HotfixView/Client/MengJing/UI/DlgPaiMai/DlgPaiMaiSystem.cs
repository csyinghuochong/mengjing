namespace ET.Client
{
    [FriendOf(typeof(ES_PaiMaiShop))]
    [FriendOf(typeof(ES_PaiMaiBuy))]
    [FriendOf(typeof(ES_PaiMaiSell))]
    [FriendOf(typeof(ES_PaiMaiDuiHuan))]
    [FriendOf(typeof(DlgPaiMai))]
    public static class DlgPaiMaiSystem
    {
        public static void RegisterUIEvent(this DlgPaiMai self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgPaiMai self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgPaiMai self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_PaiMaiShop.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_PaiMaiBuy.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_PaiMaiSell.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PaiMaiSell.OnUpdateUI();
                    break;
                case 3:
                    self.View.ES_PaiMaiDuiHuan.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.View.ES_StallSell.uiTransform.gameObject.SetActive(true);
                    self.View.ES_StallSell.OnUpdateUI();
                    break;
            }
        }

        public static void OnClickGoToPaiMai(this DlgPaiMai self, int itemType, long paimaiItemId)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(1);
            self.View.ES_PaiMaiBuy.OnClickGoToPaiMai(itemType, paimaiItemId).Coroutine();
        }
    }
}