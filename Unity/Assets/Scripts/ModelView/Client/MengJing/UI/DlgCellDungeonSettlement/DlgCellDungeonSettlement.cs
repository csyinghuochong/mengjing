using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCellDungeonSettlement : Entity, IAwake, IUILogic
    {
        public DlgCellDungeonSettlementViewComponent View { get => this.GetComponent<DlgCellDungeonSettlementViewComponent>(); }

        public M2C_FubenSettlement m2C_FubenSettlement;

        public long OpenTime;
    }
}