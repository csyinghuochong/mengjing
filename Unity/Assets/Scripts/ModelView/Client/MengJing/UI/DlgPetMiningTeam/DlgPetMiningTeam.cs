using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetMiningTeam: Entity, IAwake, IUILogic
    {
        public DlgPetMiningTeamViewComponent View
        {
            get => this.GetComponent<DlgPetMiningTeamViewComponent>();
        }

        public List<Scroll_Item_PetMiningTeamItem> MiningTeamList = new();
        public List<RolePetInfo> ShowRolePetInfos = new();
        public Dictionary<int, Scroll_Item_PetFormationItem> ScrollItemPetFormationItems;
        public List<long> PetTeamList = new();
        public List<long> PetMingPosition { get; set; } = new();

        public Action UpdateTeam { get; set; }
    }
}