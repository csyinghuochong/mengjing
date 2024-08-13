namespace ET.Client
{
    [FriendOf(typeof (DlgPetEggLucklyExplain))]
    public static class DlgPetEggLucklyExplainSystem
    {
        public static void RegisterUIEvent(this DlgPetEggLucklyExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
        }

        public static void ShowWindow(this DlgPetEggLucklyExplain self, Entity contextData = null)
        {
        }

        public static void OnBtn_CloseButton(this DlgPetEggLucklyExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggLucklyExplain);
        }
    }
}
