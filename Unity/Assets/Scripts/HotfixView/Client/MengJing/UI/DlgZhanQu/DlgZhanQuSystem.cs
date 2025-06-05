using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_ActivityLogin))]
    [FriendOf(typeof(ES_ZhanQuLevel))]
    [FriendOf(typeof(ES_ZhanQuCombat))]
    [FriendOf(typeof(ES_FirstWin))]
    [FriendOf(typeof(DlgZhanQu))]
    public static class DlgZhanQuSystem
    {
        public static void RegisterUIEvent(this DlgZhanQu self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgZhanQu self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.WelfareLogin, self.Reddot_WelfareLogin);
        }

        public static void BeforeUnload(this DlgZhanQu self)
        {
            ReddotViewComponent redPointComponent = self.Root()?.GetComponent<ReddotViewComponent>();
            redPointComponent?.UnRegisterReddot(ReddotType.WelfareLogin, self.Reddot_WelfareLogin);
        }
        
        private static void Reddot_WelfareLogin(this DlgZhanQu self, int num)
        {
            self.View.E_Type_3Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }
        
        private static void OnFunctionSetBtn(this DlgZhanQu self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ZhanQuLevel.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_ZhanQuCombat.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_FirstWin.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_ActivityLogin.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ActivityLogin.OnUpdateUI();
                    break;
            }
        }

        public static void OnClickGoToFirstWin(this DlgZhanQu self, int bossId)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(2);
            self.View.ES_FirstWin.BossId = bossId;
        }
    }
}