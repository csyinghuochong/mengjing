using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetMiningReward: Entity, IAwake, IUILogic
    {
        public DlgPetMiningRewardViewComponent View
        {
            get => this.GetComponent<DlgPetMiningRewardViewComponent>();
        }

        public List<TaskPro> ShowTaskPros = new();
        public Dictionary<int, EntityRef<Scroll_Item_PetMiningRewardItem>> ScrollItemPetMiningRewardItems;
    }
}