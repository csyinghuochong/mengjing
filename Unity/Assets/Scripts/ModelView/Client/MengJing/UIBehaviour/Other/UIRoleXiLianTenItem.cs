using UnityEngine;

namespace ET.Client
{
    public class UIRoleXiLianTenItem: Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject ButtonSelect;
        public GameObject Obj_EquipPropertyText;
        public GameObject EquipBaseSetList;

        public ItemXiLianResult ItemXiLianResult;
        public BagInfo BagInfo;
    }
}