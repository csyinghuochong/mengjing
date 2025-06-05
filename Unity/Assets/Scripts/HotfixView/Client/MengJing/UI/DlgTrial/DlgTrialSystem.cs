using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ES_TrialDungeon))]
    [FriendOf(typeof (ES_TrialRank))]
    [FriendOf(typeof (DlgTrial))]
    public static class DlgTrialSystem
    {
        public static void RegisterUIEvent(this DlgTrial self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgTrial self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgTrial self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_TrialDungeon.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_TrialRank.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}