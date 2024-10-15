using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMeleeMain : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeMainViewComponent View { get => this.GetComponent<DlgPetMeleeMainViewComponent>(); }

        public Dictionary<int, EntityRef<Scroll_Item_PetMeleeItem>> ScrollItemPetMeleeItems;
    }
}