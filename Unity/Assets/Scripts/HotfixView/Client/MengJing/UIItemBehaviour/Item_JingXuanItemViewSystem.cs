namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_JingXuanItem))]
    public static partial class Scroll_Item_JingXuanItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JingXuanItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JingXuanItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_JingXuanItem self, int index, UnionPlayerInfo unionPlayerInfo)
        {
            self.E_Lab_IndexText.text = (index + 1).ToString();
            self.E_Lab_NameText.text = unionPlayerInfo.PlayerName;
        }
    }
}