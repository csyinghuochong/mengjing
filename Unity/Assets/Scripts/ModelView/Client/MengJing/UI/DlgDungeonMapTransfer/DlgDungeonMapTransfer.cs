using System.Collections.Generic;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgDungeonMapTransfer: Entity, IAwake, IUILogic
    {
        public DlgDungeonMapTransferViewComponent View
        {
            get => this.GetComponent<DlgDungeonMapTransferViewComponent>();
        }

        public int ChapterId;
        public DungeonSectionConfig DungeonSectionConfig;
        public List<int> ShowLevel = new();
        public Dictionary<int, EntityRef<Scroll_Item_DungeonLevelItem>> ScrollItemDungeonLevelItems;
        public List<KeyValuePair> ShowBoosRefreshTime = new();
        public Dictionary<int, EntityRef<Scroll_Item_BossRefreshTimeItem>> ScrollItemBossRefreshTimeItems;
        public List<int> ShowBossSetting = new();
        public Dictionary<int, EntityRef<Scroll_Item_BossRefreshSettingItem>> ScrollItemBossRefreshSettingItems;

        public Dictionary<int, Text> BossRefreshObjs = new();
        public Dictionary<int, long> BossRefreshTime = new();
        public long Timer;
    }
}