using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCellDungeonSettlement : Entity, IAwake, IUILogic
    {
        public DlgCellDungeonSettlementViewComponent View { get => this.GetComponent<DlgCellDungeonSettlementViewComponent>(); }

        public List<ES_SettlementReward> RewardUIList { get; set; } = new();

        public int LeftTime;
        public float Time;

        public int GetPassTime = 0;

        public bool topSelect = false;
        public bool bottomSelect = false;
        public long Timer;
    }
}