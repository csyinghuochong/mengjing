using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgWatch))]
    [EntitySystemOf(typeof (ES_WatchEquip))]
    [FriendOfAttribute(typeof (ES_WatchEquip))]
    public static partial class ES_WatchEquipSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WatchEquip self, Transform transform)
        {
            self.uiTransform = transform;
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_WatchEquip self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_WatchEquip self)
        {
            DlgWatch dlgWatch = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>();
            F2C_WatchPlayerResponse m2C_WatchPlayerResponse = dlgWatch.F2C_WatchPlayerResponse;
            self.ES_EquipSet1.PlayerLv(m2C_WatchPlayerResponse.Lv);
            self.ES_EquipSet1.PlayerName(m2C_WatchPlayerResponse.Name);
            self.ES_EquipSet1.RefreshEquip(m2C_WatchPlayerResponse.EquipList, new List<BagInfo>(), m2C_WatchPlayerResponse.Occ,
                ItemOperateEnum.Watch);
            BagInfo bagInfo = ItemHelper.GetEquipByWeizhi(m2C_WatchPlayerResponse.EquipList, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet1.ShowPlayerModel(bagInfo, m2C_WatchPlayerResponse.Occ, 0, m2C_WatchPlayerResponse.FashionIds, 4);

            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            int selfOcc = userInfoComponentC.UserInfo.Occ;
            self.ES_EquipSet2.PlayerLv(userInfoComponentC.UserInfo.Lv);
            self.ES_EquipSet2.PlayerName(userInfoComponentC.UserInfo.Name);
            self.ES_EquipSet2.RefreshEquip(bagComponentC.GetEquipList(), new List<BagInfo>(), selfOcc, ItemOperateEnum.Watch);
            BagInfo bagInfo2 = bagComponentC.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet2.ShowPlayerModel(bagInfo2, selfOcc, 0, bagComponentC.FashionEquipList, 5);
        }
    }
}