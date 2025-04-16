namespace ET.Client
{
    [FriendOf(typeof (DlgRoleBagSplit))]
    public static class DlgRoleBagSplitSystem
    {
        public static void RegisterUIEvent(this DlgRoleBagSplit self)
        {
            self.View.E_Btn_AddNumButton.AddListener(self.OnBtn_AddNumButton);
            self.View.E_InputFieldInputField.onValueChanged.AddListener(self.OnOnNumInputField);
            self.View.E_Btn_CostNumButton.AddListener(self.OnBtn_CostNumButton);
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
            self.View.E_Btn_SplitButton.AddListenerAsync(self.OnBtn_SplitButton);
        }

        public static void ShowWindow(this DlgRoleBagSplit self, Entity contextData = null)
        {
        }

        public static void Init(this DlgRoleBagSplit self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            self.Num = 1;
            // self.View.ES_CommonItem.UseTextColor = true;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.View.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            self.View.E_InputFieldInputField.text = self.Num.ToString();
        }

        private static void OnBtn_AddNumButton(this DlgRoleBagSplit self)
        {
            if (self.Num >= self.BagInfo.ItemNum)
            {
                return;
            }

            self.Num++;
            self.View.E_InputFieldInputField.text = self.Num.ToString();
        }

        private static void OnOnNumInputField(this DlgRoleBagSplit self, string text)
        {
            long num = 0;
            if (long.TryParse(text, out num))
            {
                if (num > 0 && num <= self.BagInfo.ItemNum)
                {
                    self.Num = num;
                }
            }
        }

        private static void OnBtn_CostNumButton(this DlgRoleBagSplit self)
        {
            if (self.Num <= 1)
            {
                return;
            }

            self.Num--;
            self.View.E_InputFieldInputField.text = self.Num.ToString();
        }

        private static void OnButtonCloseButton(this DlgRoleBagSplit self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleBagSplit);
        }

        private static async ETTask OnBtn_SplitButton(this DlgRoleBagSplit self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            int errorCode = await BagClientNetHelper.RequestSplitItem(self.Root(), self.BagInfo, (int)self.Num);
            if (errorCode == ErrorCode.ERR_Success)
            {
                flyTipComponent.ShowFlyTip("拆分完成!");
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleBagSplit);
        }
    }
}
