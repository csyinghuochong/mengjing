using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    public class UIRoleXiLianTenItem: Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject ButtonSelect;
        public GameObject Obj_EquipPropertyText;
        public GameObject EquipBaseSetList;
        public GameObject E_CombatDown;
        public GameObject E_CombatUp;
        public Text E_BattleAdd;

        public ItemXiLianResult ItemXiLianResult;

        public ItemInfo OldItemInfo { get; set; }
        public ItemInfo ItemInfo { get; set; }
    }
}