using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ES_ActivityYueKa))]
    [FriendOf(typeof (ES_ActivityMaoXian))]
    [FriendOf(typeof (ES_ActivityToken))]
    [FriendOf(typeof (ES_ActivityTeHui))]
    [FriendOf(typeof (ES_ActivitySingleRecharge))]
    [FriendOf(typeof (DlgActivity))]
    public static class DlgActivitySystem
    {
        public static void RegisterUIEvent(this DlgActivity self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(200f, 0f));
            
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.SingleRecharge, self.Reddot_SingleRecharge);
        }

        public static void ShowWindow(this DlgActivity self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void BeforeUnload(this DlgActivity self)
        {
            ReddotViewComponent redPointComponent = self.Root()?.GetComponent<ReddotViewComponent>();
            redPointComponent?.UnRegisterReddot(ReddotType.SingleRecharge, self.Reddot_SingleRecharge);
        }
        
        public static void Reddot_SingleRecharge(this DlgActivity self, int num)
        {
            self.View.E_Type_4Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
            if (num > 0)
            {
                self.View.ES_ActivitySingleRecharge.InitInfo();
            }
        }

        private static void OnFunctionSetBtn(this DlgActivity self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ActivityYueKa.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_ActivityMaoXian.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_ActivityToken.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_ActivityTeHui.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ActivityTeHui.OnUpdateUI();
                    break;
                case 4:
                    self.View.ES_ActivitySingleRecharge.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
