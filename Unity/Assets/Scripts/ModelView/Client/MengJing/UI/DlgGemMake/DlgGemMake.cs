using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgGemMake: Entity, IAwake, IUILogic
    {
        public DlgGemMakeViewComponent View
        {
            get => this.GetComponent<DlgGemMakeViewComponent>();
        }

        public int MakeId;
        public long Timer;
        public Dictionary<int, Scroll_Item_MakeItem> ScrollItemMakeItems;
        public List<int> ShowMake = new();
    }
}