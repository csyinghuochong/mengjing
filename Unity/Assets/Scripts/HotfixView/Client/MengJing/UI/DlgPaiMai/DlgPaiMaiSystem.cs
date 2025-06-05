using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_PaiMaiShop))]
    [FriendOf(typeof(ES_PaiMaiBuy))]
    [FriendOf(typeof(ES_PaiMaiSell))]
    [FriendOf(typeof(ES_PaiMaiDuiHuan))]
    [FriendOf(typeof(ES_StallSell))]
    [FriendOf(typeof(DlgPaiMai))]
    public static class DlgPaiMaiSystem
    {
        public static void RegisterUIEvent(this DlgPaiMai self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgPaiMai self, Entity contextData = null)
        {
            int index = 0;
            if (contextData!= null && contextData is ShowWindowData)
            {
                ShowWindowData showWindowData = (ShowWindowData)contextData;
                index = showWindowData.ParamInfoInt;
            }

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(index);
            contextData = null;
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