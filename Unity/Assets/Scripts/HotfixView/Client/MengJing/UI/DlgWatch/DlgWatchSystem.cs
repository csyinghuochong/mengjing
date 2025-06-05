using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ES_WatchEquip))]
    [FriendOf(typeof (ES_PetList))]
    [FriendOf(typeof (ES_WatchPet))]
    [FriendOf(typeof (DlgWatch))]
    public static class DlgWatchSystem
    {
        public static void RegisterUIEvent(this DlgWatch self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgWatch self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgWatch self, int index)
        {
            if (!self.CanClick)
            {
                return;
            }

            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_WatchEquip.uiTransform.gameObject.SetActive(true);
                    self.View.ES_WatchEquip.OnInitUI();
                    break;
                case 1:
                    self.View.ES_WatchPet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_WatchPet.OnUpdateUI();
                    break;
            }
        }

        public static void OnUpdateUI(this DlgWatch self, F2C_WatchPlayerResponse m2C_WatchPlayerResponse)
        {
            self.F2C_WatchPlayerResponse = m2C_WatchPlayerResponse;
            self.CanClick = true;
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }
    }
}