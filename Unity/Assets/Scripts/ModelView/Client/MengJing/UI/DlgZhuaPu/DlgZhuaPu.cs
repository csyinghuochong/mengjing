using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgZhuaPu: Entity, IAwake, IUILogic
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

        public List<BagInfo> ShowBagInfos = new();
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
    }
}