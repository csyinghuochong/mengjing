using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgDungeon : Entity, IAwake, IUILogic
    {
        public DlgDungeonViewComponent View
        {
            get => this.GetComponent<DlgDungeonViewComponent>();
        }

        public long Timer;
        public List<int> ShowChapter = new();
        public Dictionary<int, EntityRef<Scroll_Item_DungeonItem>> ScrollItemDungeonItems;
        public List<KeyValuePair> ShowBoosRefreshTime = new();
        public Dictionary<int, EntityRef<Scroll_Item_BossRefreshTimeItem>> ScrollItemBossRefreshTimeItems;
        public List<int> ShowBossSetting = new();
        public Dictionary<int, EntityRef<Scroll_Item_BossRefreshSettingItem>> ScrollItemBossRefreshSettingItems;
    }
}