using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMatchRankShow : Entity, IAwake, IUILogic
    {
        public DlgPetMatchRankShowViewComponent View { get => this.GetComponent<DlgPetMatchRankShowViewComponent>(); }

        public List<PetMatchPlayerInfo> ShowRankingInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_PetMatchRankShowItem>> ScrollItemRankShowItems;
        public int CurrentItemType;
        private EntityRef<Scroll_Item_PetMatchRankShowItem> myRankShowItem;
        public Scroll_Item_PetMatchRankShowItem MyRankShowItem { get => this.myRankShowItem; set => this.myRankShowItem = value; }
    }
}