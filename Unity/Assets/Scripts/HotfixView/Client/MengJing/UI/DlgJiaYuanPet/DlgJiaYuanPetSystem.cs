namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_PetItemSelect_DlgJiaYuanPetRefresh : AEvent<Scene, PetItemSelect>
    {
        protected override async ETTask Run(Scene scene, PetItemSelect args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanPet>()?.ES_JiaYuanPetWalk.PetItemSelect(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_JiaYuanPetWalk))]
    [FriendOf(typeof(ES_PetCangKu))]
    [FriendOf(typeof(DlgJiaYuanPet))]
    public static class DlgJiaYuanPetSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanPet self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgJiaYuanPet self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgJiaYuanPet self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.ES_JiaYuanPetWalk.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.ES_PetCangKu.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}