using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgZhuaPu : Entity, IAwake, IUILogic
    {
        public DlgZhuaPuViewComponent View
        {
            get => this.GetComponent<DlgZhuaPuViewComponent>();
        }

        public float PassTime = 0f;
        public float MoveSpeed = 150f;
        public int ItemId;
        public long Timer;
        public int MonsterId;
        public long MonsterUnitid;
        public int ZhuaBuType = 0; //1旧的抓捕   2新的抓捕
        public int BabyType;

        public List<EntityRef<ItemInfo>> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}