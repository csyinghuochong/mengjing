namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_HuiShouSelect_DlgJiaYuanFoodRefresh : AEvent<Scene, HuiShouSelect>
    {
        protected override async ETTask Run(Scene scene, HuiShouSelect args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanFood>()?.View.ES_JiaYuanCooking.OnHuiShouSelect(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_JiaYuanPurchase))]
    [FriendOf(typeof(ES_JiaYuanCooking))]
    [FriendOf(typeof(ES_JiaYuanCookbook))]
    [FriendOf(typeof(DlgJiaYuanFood))]
    public static class DlgJiaYuanFoodSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanFood self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgJiaYuanFood self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgJiaYuanFood self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_JiaYuanPurchase.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_JiaYuanCooking.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_JiaYuanCookbook.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JiaYuanCookbook.OnUpdateUI();
                    break;
            }
        }
    }
}