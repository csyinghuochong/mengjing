namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_BagItemUpdate_DlgEquipmentIncreaseRefresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene root, BagItemUpdate args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipmentIncrease>()?.View.ES_EquipmentIncreaseShow.OnUpdateUI();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_EquipmentIncreaseShow))]
    [FriendOf(typeof(ES_EquipmentIncreaseTransfer))]
    [FriendOf(typeof(DlgEquipmentIncrease))]
    public static class DlgEquipmentIncreaseSystem
    {
        public static void RegisterUIEvent(this DlgEquipmentIncrease self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgEquipmentIncrease self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgEquipmentIncrease self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_EquipmentIncreaseShow.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_EquipmentIncreaseTransfer.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipmentIncreaseTransfer.OnUpdateUI();
                    break;
            }
        }
    }
}