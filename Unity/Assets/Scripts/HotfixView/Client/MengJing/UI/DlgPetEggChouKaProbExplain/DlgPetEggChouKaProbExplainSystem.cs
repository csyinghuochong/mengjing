namespace ET.Client
{
    [FriendOf(typeof (DlgPetEggChouKaProbExplain))]
    public static class DlgPetEggChouKaProbExplainSystem
    {
        public static void RegisterUIEvent(this DlgPetEggChouKaProbExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
        }

        public static void ShowWindow(this DlgPetEggChouKaProbExplain self, Entity contextData = null)
        {
        }

        public static void OnBtn_CloseButton(this DlgPetEggChouKaProbExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggChouKaProbExplain);
        }
    }
}
