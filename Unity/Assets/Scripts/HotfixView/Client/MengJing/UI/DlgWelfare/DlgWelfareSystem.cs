namespace ET.Client
{
    [FriendOf(typeof(ES_ActivityLogin))]
    [FriendOf(typeof(ES_WelfareTask))]
    [FriendOf(typeof(ES_WelfareDraw))]
    [FriendOf(typeof(ES_WelfareInvest))]
    [FriendOf(typeof(ES_WelfareDraw2))]
    [FriendOf(typeof(DlgWelfare))]
    public static class DlgWelfareSystem
    {
        public static void RegisterUIEvent(this DlgWelfare self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.WelfareTask, self.Reddot_WelfareTask);
            redPointComponent.RegisterReddot(ReddotType.WelfareDraw, self.Reddot_WelfareDraw);
        }

        public static void ShowWindow(this DlgWelfare self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgWelfare self)
        {
            ReddotViewComponent redPointComponent = self.Root()?.GetComponent<ReddotViewComponent>();
            redPointComponent?.UnRegisterReddot(ReddotType.WelfareTask, self.Reddot_WelfareTask);
            redPointComponent?.UnRegisterReddot(ReddotType.WelfareDraw, self.Reddot_WelfareDraw);
        }

        public static void Reddot_WelfareTask(this DlgWelfare self, int num)
        {
            self.View.E_Type_1Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_WelfareDraw(this DlgWelfare self, int num)
        {
            self.View.E_Type_2Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void OnFunctionSetBtn(this DlgWelfare self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_WelfareTask.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_WelfareDraw.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_WelfareInvest.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_WelfareDraw2.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}