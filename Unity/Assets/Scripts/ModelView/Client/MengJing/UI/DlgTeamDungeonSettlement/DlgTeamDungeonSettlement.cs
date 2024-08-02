using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTeamDungeonSettlement : Entity, IAwake, IUILogic
    {
        public DlgTeamDungeonSettlementViewComponent View { get => this.GetComponent<DlgTeamDungeonSettlementViewComponent>(); }

        public List<Scroll_Item_TeamDungeonSettlementPlayer> PlayerUIList { get; set; } = new();
        public List<Scroll_Item_SettlementRwardItem> RewardUIList { get; set; } = new();

        public GameObject SettlementRward2;
        public GameObject SettlementRward1;
        public GameObject SettlementItem;

        public int LeftTime;
        public bool IfLingQuStatus;
        public long SendGetTime;
    }
}