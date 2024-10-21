using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgAppraisalSelect : Entity, IAwake, IUILogic
    {
        public DlgAppraisalSelectViewComponent View
        {
            get => this.GetComponent<DlgAppraisalSelectViewComponent>();
        }

        private EntityRef<ItemInfo> bagInfo_Equip;
        public ItemInfo BagInfo_Equip { get => this.bagInfo_Equip; set => this.bagInfo_Equip = value; }

        private EntityRef<ItemInfo> bagInfo_Appri;
        public ItemInfo BagInfo_Appri { get => this.bagInfo_Appri; set => this.bagInfo_Appri = value; }
        public int AppraisalItemConfigId { get; set; }
        public List<EntityRef<ItemInfo>> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}