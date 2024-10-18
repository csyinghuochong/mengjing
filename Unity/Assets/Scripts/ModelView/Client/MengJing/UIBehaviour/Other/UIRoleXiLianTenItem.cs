using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIRoleXiLianTenItem: Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject ButtonSelect;
        public GameObject Obj_EquipPropertyText;
        public GameObject EquipBaseSetList;

        public ItemXiLianResult ItemXiLianResult;
        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
    }
}