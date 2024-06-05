using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRoleZodiac: Entity, IAwake, IUILogic
    {
        public DlgRoleZodiacViewComponent View
        {
            get => this.GetComponent<DlgRoleZodiacViewComponent>();
        }

        public int CurrentItemType;
        public List<ES_EquipItem> EquipList = new();
        public List<BagInfo> EquipInfoList = new();
        public ItemOperateEnum ItemOperateEnum;
        public int Occ;
    }
}