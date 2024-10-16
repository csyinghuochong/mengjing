using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMeleeMain : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeMainViewComponent View { get => this.GetComponent<DlgPetMeleeMainViewComponent>(); }

        public Dictionary<int, EntityRef<Scroll_Item_PetMeleeItem>> ScrollItemPetMeleeItems;
        public List<RolePetInfo> ShowRolePetInfos = new();
        public long PetId;
        public bool IsPlace;
        public long StartTime;
        public long ReadyTime;
        public int MaxMoLi;
        public int MoLi;
        public int CostMoLi;
        public bool GameStart;
        public long Timer;
    }
}