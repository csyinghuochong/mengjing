using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgDungeonLevel: Entity, IAwake, IUILogic
    {
        public DlgDungeonLevelViewComponent View
        {
            get => this.GetComponent<DlgDungeonLevelViewComponent>();
        }

        public int Difficulty { get; set; }
        public int ChapterId;
        public List<int> ShowLevel = new();
        public Dictionary<int, EntityRef<Scroll_Item_DungeonLevelItem>> ScrollItemDungeonLevelItems;
        public DungeonSectionConfig DungeonSectionConfig;
    }
}