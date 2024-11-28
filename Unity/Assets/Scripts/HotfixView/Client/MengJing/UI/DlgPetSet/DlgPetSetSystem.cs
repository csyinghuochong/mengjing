namespace ET.Client
{
    [FriendOf(typeof(DlgPetSet))]
    [FriendOf(typeof(ES_PetMining))]
    [FriendOf(typeof(ES_PetChallenge))]
    public static class DlgPetSetSystem
    {
        public static void RegisterUIEvent(this DlgPetSet self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.PetMine, self.Reddot_PetMine);
        }

        public static void ShowWindow(this DlgPetSet self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgPetSet self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.PetMine, self.Reddot_PetMine);
        }

        public static void Reddot_PetMine(this DlgPetSet self, int num)
        {
            self.View.E_Type_1Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void OnFunctionSetBtn(this DlgPetSet self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_PetChallenge.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_PetMining.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetMining.OnUpdateUI();
                    break;
            }
        }
    }
}