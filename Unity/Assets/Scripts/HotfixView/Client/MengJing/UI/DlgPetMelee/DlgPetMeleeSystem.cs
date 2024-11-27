namespace ET.Client
{
    [FriendOf(typeof(ES_PetMeleeSet))]
    [FriendOf(typeof(DlgPetMelee))]
    public static class DlgPetMeleeSystem
    {
        public static void RegisterUIEvent(this DlgPetMelee self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgPetMelee self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgPetMelee self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.ES_PetMeleeSet.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}