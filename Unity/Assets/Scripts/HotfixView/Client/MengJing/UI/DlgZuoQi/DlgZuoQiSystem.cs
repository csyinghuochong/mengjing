using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_ZuoQiShow))]
    [FriendOf(typeof(DlgZuoQi))]
    public static class DlgZuoQiSystem
    {
        public static void RegisterUIEvent(this DlgZuoQi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgZuoQi self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgZuoQi self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ZuoQiShow.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}