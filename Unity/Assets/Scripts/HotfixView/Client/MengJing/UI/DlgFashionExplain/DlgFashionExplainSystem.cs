namespace ET.Client
{
    [FriendOf(typeof (DlgFashionExplain))]
    public static class DlgFashionExplainSystem
    {
        public static void RegisterUIEvent(this DlgFashionExplain self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
        }

        public static void ShowWindow(this DlgFashionExplain self, Entity contextData = null)
        {
        }

        public static void OnBtn_CloseButton(this DlgFashionExplain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_FashionExplain);
        }

        public static void OnInitData(this DlgFashionExplain self, int fashionid)
        {
            FashionConfig fashionConfig = FashionConfigCategory.Instance.Get(fashionid);
            // self.View.E_TextExplainText.text = fashionConfig.PropertyDes;
            self.View.E_TextExplainText.text = "氪金大佬的衣服";
        }
    }
}
