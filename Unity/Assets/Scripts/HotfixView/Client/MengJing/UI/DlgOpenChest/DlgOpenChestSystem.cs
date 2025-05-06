namespace ET.Client
{
    [FriendOf(typeof (DlgOpenChest))]
    public static class DlgOpenChestSystem
    {
        public static void RegisterUIEvent(this DlgOpenChest self)
        {
            self.View.E_OpenBtnButton.AddListener(self.OnOpenBtnButton);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
        }

        public static void ShowWindow(this DlgOpenChest self, Entity contextData = null)
        {
        }

        public static void OnBtn_CloseButton(this DlgOpenChest self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_OpenChest);
        }
        
        public static void UpdateInfo(this DlgOpenChest self, Unit Box)
        {
            self.Box = Box;
            int monsterid = Box.ConfigId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);
            self.View.ES_CommonItem.UpdateItem(new() { ItemID = monsterConfig.Parameter[0], ItemNum = monsterConfig.Parameter[1] },
                ItemOperateEnum.None);
        }

        public static void OnOpenBtnButton(this DlgOpenChest self)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_OpenBox.OnOpenBox(self.Box);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_OpenChest);
        }
    }
}
