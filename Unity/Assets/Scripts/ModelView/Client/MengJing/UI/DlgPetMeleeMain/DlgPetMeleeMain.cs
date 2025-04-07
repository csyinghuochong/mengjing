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
        
        public int MapTypeEnum { get; set; }

        public int BattleCamp { get; set; }

        public bool IsDisposeCard { get; set; }
        public bool IsCancelCard { get; set; }

        public float OranginScale;

        public bool IsGameOver;
        public long Timer;
        public float BeginTime;
    }
}