using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRole: Entity, IAwake, IUILogic
    {
        public DlgRoleViewComponent View
        {
            get => this.GetComponent<DlgRoleViewComponent>();
        }

        public List<ES_EquipItem> ESEquipItems_1 = new();
        public List<ES_EquipItem> ESEquipItems_2 = new();

        public List<BagInfo> EquipInfoList = new();
        public ItemOperateEnum ItemOperateEnum;
        public int Position;
        public int Index;
        public int Occ;
    }
}