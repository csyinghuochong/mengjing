using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ES_ShouJiList))]
    [FriendOf(typeof (ES_ShouJiTreasure))]
    [FriendOf(typeof (DlgShouJi))]
    public static class DlgShouJiSystem
    {
        public static void RegisterUIEvent(this DlgShouJi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgShouJi self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgShouJi self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ShouJiList.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_ShouJiTreasure.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void OnShouJiTreasure(this DlgShouJi self)
        {
            self.View.ES_ShouJiTreasure.OnShouJiTreasure();
        }
    }
}
