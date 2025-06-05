using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ES_TaskGrowUp))]
    [FriendOf(typeof (ES_TaskDetail))]
    [FriendOf(typeof (ES_TaskShop))]
    [FriendOf(typeof (DlgTask))]
    public static class DlgTaskSystem
    {
        public static void RegisterUIEvent(this DlgTask self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgTask self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgTask self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_TaskDetail.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_TaskGrowUp.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_TaskShop.uiTransform.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
