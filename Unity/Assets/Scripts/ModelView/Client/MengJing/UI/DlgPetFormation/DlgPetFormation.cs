using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetFormation: Entity, IAwake, IUILogic
    {
        public DlgPetFormationViewComponent View
        {
            get => this.GetComponent<DlgPetFormationViewComponent>();
        }

        
        public List<long> PetTeamList = new();
        public Action SetHandler = null;
        public int SceneTypeEnum;
        public int PetNumberLimit;
        public List<RolePetInfo> ShowRolePetInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_PetFormationItem>> ScrollItemPetFormationItems;
    }
}