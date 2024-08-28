using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgDungeonMapLevel : Entity, IAwake, IUILogic
    {
        public DlgDungeonMapLevelViewComponent View { get => this.GetComponent<DlgDungeonMapLevelViewComponent>(); }

        public int Difficulty;
        public int ChapterId;
        public int LevelId;
        public List<int> ShowLevel = new();
        public Dictionary<int, EntityRef<Scroll_Item_DungeonMapLevelItem>> ScrollItemDungeonMapLevelItems;
        public DungeonSectionConfig DungeonSectionConfig;
    }
}