namespace ET.Client
{
    [FriendOf(typeof (DlgPetHeChengExplain))]
    public static class DlgPetHeChengExplainSystem
    {
        public static void RegisterUIEvent(this DlgPetHeChengExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetHeChengExplain);
            });
        }

        public static void ShowWindow(this DlgPetHeChengExplain self, Entity contextData = null)
        {
        }
    }
}
