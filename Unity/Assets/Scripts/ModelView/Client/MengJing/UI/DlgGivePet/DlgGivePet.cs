using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgGivePet : Entity, IAwake, IUILogic
    {
        public DlgGivePetViewComponent View { get => this.GetComponent<DlgGivePetViewComponent>(); }

        public int TaskId;

        public int PetSkinId;
        public RolePetInfo LastSelectItem;

        public Action OnGiveAction { get; set; }

        public Dictionary<int, EntityRef<Scroll_Item_PetListItem>> ScrollItemPetListItems;
        public List<RolePetInfo> ShowRolePetInfos = new();
    }
}