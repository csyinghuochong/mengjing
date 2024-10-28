using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetQuickFight : Entity, IAwake, IUILogic
    {
        public DlgPetQuickFightViewComponent View { get => this.GetComponent<DlgPetQuickFightViewComponent>(); }

        public int FightIndex;
        public long Timer;
        public List<RolePetInfo> ShowRolePetInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_PetQuickFightItem>> ScrollItemPetQuickFightItems;
    }
}