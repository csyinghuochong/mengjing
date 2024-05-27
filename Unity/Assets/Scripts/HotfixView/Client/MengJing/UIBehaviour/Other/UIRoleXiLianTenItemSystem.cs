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
        }

        public static void OnInitUI(this UIRoleXiLianTenItem self, BagInfo bagInfo, ItemXiLianResult index)
        {
            self.BagInfo = bagInfo;
            self.ItemXiLianResult = index;
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemViewHelp.ShowBaseAttribute(bagComponent.GetEquipList(), bagInfo, self.Obj_EquipPropertyText, self.EquipBaseSetList);
        }

        public static async ETTask OnButtonSelect(this UIRoleXiLianTenItem self)
        {
            int error = await BagClientNetHelper.RquestItemXiLianSelect(self.Root(), self.BagInfo.BagInfoID, self.ItemXiLianResult);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleXiLian>().OnXiLianReturn();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianTen);
        }
    }
}