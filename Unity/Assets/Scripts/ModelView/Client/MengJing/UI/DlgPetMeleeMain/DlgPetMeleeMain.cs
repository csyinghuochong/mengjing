using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMeleeMain : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeMainViewComponent View { get => this.GetComponent<DlgPetMeleeMainViewComponent>(); }

        public List<EntityRef<ES_PetMeleeCard>> PetMeleeCardInHand = new();
        public List<EntityRef<ES_PetMeleeCard>> PetMeleeCardPool = new();

        public Vector2 PreviousPressPosition;

        public Dictionary<int, EntityRef<Scroll_Item_PetMeleeItem>> ScrollItemPetMeleeItems;
        public List<RolePetInfo> ShowRolePetInfos = new();
        public long PetId;
        public bool CanPlace;
        public long StartTime;
        public long ReadyTime;
        public int MaxMoLi;
        public int MoLi;
        public int MoLiRegenRate;
        public long LastMoLiRegenTime;
        public int CostMoLi;
        public bool GameStart;
        public long Timer;
    }
}