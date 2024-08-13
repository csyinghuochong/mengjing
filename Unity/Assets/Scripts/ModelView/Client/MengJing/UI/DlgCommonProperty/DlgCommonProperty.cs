using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCommonProperty : Entity, IAwake, IUILogic
    {
        public DlgCommonPropertyViewComponent View { get => this.GetComponent<DlgCommonPropertyViewComponent>(); }

        public List<ShowPropertyList> ShowPropertyList = new();
        
        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
        public List<int> ShowPetSkills = new();
    }
}