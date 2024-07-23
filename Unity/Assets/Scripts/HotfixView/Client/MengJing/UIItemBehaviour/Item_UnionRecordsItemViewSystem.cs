namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_UnionRecordsItem))]
    public static partial class Scroll_Item_UnionRecordsItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_UnionRecordsItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_UnionRecordsItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_UnionRecordsItem self, string record)
        {
            string[] strs = record.Split('_');
            using (zstring.Block())
            {
                self.E_TextContentText.text = zstring.Format("<color=#{0}>{1}</color> 通过{2} 增加了<color=#{3}>{4}</color>{5}",
                    CommonHelp.QualityReturnColor(4), strs[0], ConfigData.ItemGetWayNameList[int.Parse(strs[1])],
                    CommonHelp.QualityReturnColor(2), strs[3], ItemConfigCategory.Instance.Get(int.Parse(strs[2])).ItemName);
            }
        }
    }
}