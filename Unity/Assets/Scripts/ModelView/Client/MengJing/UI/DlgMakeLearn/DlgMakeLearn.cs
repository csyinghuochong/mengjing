using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgMakeLearn: Entity, IAwake, IUILogic
    {
        public DlgMakeLearnViewComponent View
        {
            get => this.GetComponent<DlgMakeLearnViewComponent>();
        }

        public int MakeType;
        public int MakeId;
        public int Plan { get; set; } = 1;
        public List<int> ShowMakeLearns = new();
        public Dictionary<int, EntityRef<Scroll_Item_MakeLearnItem>> ScrollItemMakeLearnItems;
    }
}