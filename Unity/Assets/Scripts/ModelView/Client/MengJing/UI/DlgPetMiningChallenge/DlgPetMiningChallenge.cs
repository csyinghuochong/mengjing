using System.Collections.Generic;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetMiningChallenge: Entity, IAwake, IUILogic
    {
        public DlgPetMiningChallengeViewComponent View
        {
            get => this.GetComponent<DlgPetMiningChallengeViewComponent>();
        }

        public PetMingPlayerInfo PetMingPlayerInfo;

        public List<Image> PetIconList = new();
        public List<EntityRef<Scroll_Item_PetMiningChallengeItem>> ChallengeTeamList = new();

        public int MineTpe;
        public int Position;
        public int TeamId;
    }
}