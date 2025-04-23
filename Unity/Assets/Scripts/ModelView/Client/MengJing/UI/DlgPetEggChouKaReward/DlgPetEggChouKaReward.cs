using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetEggChouKaReward : Entity, IAwake, IUILogic
    {
        public DlgPetEggChouKaRewardViewComponent View
        {
            get => this.GetComponent<DlgPetEggChouKaRewardViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_PetEggChouKaRewardItem>> ScrollItemPetEggChouKaRewardItems = new();
        public List<int> ShowInfo = new();
        public List<string> AssetList { get; set; } = new();
    }
}