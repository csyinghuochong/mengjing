using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UIRoleXiLianTenItem))]
    [EntitySystemOf(typeof (UIRoleXiLianTenItem))]
    public static partial class UIRoleXiLianTenItemSystem
    {
        [EntitySystem]
        private static void Awake(this UIRoleXiLianTenItem self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.ButtonSelect = rc.Get<GameObject>("ButtonSelect");
            self.ButtonSelect.GetComponent<Button>().AddListenerAsync(self.OnButtonSelect);
            
            self.Obj_EquipPropertyText = rc.Get<GameObject>("Obj_EquipPropertyText");
            self.Obj_EquipPropertyText.SetActive(false);
            self.EquipBaseSetList = rc.Get<GameObject>("EquipBaseSetList");
        
            self.E_CombatDown = rc.Get<GameObject>("E_CombatDown");
            self.E_CombatUp = rc.Get<GameObject>("E_CombatUp");
            self.E_BattleAdd = rc.Get<GameObject>("E_BattleAdd").GetComponent<Text>();
        }

        public static void OnInitUI(this UIRoleXiLianTenItem self, ItemInfo oldItemInfo, ItemInfo itemInfo, ItemXiLianResult index)
        {
            self.OldItemInfo = oldItemInfo;
            self.ItemInfo = itemInfo;
            self.ItemXiLianResult = index;
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemViewHelp.ShowBaseAttribute(bagComponent.GetEquipList(), itemInfo, self.Obj_EquipPropertyText, self.EquipBaseSetList);

            self.E_BattleAdd.text = $"预计战力增长:{index.ChangeCombat}";
            self.E_CombatDown.gameObject.SetActive(index.ChangeCombat < 0);
            self.E_CombatUp.gameObject.SetActive(index.ChangeCombat > 0);
        }

        public static async ETTask OnButtonSelect(this UIRoleXiLianTenItem self)
        {
            int error = await BagClientNetHelper.RquestItemXiLianSelect(self.Root(), self.ItemInfo.BagInfoID, self.ItemXiLianResult);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleXiLian>().OnXiLianReturn(self.OldItemInfo, self.ItemXiLianResult.ChangeCombat);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianTen);
        }
    }
}