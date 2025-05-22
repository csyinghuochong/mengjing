using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWatch))]
    [EntitySystemOf(typeof(ES_WatchEquip))]
    [FriendOfAttribute(typeof(ES_WatchEquip))]
    public static partial class ES_WatchEquipSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WatchEquip self, Transform transform)
        {
            self.uiTransform = transform;
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
            List<ItemInfo> itemInfos = new List<ItemInfo>();
            foreach (ItemInfoProto proto in m2C_WatchPlayerResponse.EquipList)
            {
                ItemInfo itemInfo = new ItemInfo();
                itemInfo.FromMessage(proto);
                itemInfos.Add(itemInfo);
            }

            self.ES_EquipSet_1.PlayerLv(m2C_WatchPlayerResponse.Lv);
            self.ES_EquipSet_1.PlayerName(m2C_WatchPlayerResponse.Name);
            self.ES_EquipSet_1.RefreshEquip(itemInfos, new List<ItemInfo>(), m2C_WatchPlayerResponse.Occ, ItemOperateEnum.Watch);
            ItemInfo bagInfo = ItemHelper.GetEquipByWeizhi(itemInfos, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet_1.ES_ModelShow.SetCameraPosition(new Vector3(0f, 60f, 150f));
            self.ES_EquipSet_1.ES_ModelShow.ShowPlayerModel(bagInfo, m2C_WatchPlayerResponse.Occ, 0, new List<int>());

            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            int selfOcc = userInfoComponentC.UserInfo.Occ;
            self.ES_EquipSet_2.PlayerLv(userInfoComponentC.UserInfo.Lv);
            self.ES_EquipSet_2.PlayerName(userInfoComponentC.UserInfo.Name);
            self.ES_EquipSet_2.RefreshEquip(bagComponentC.GetEquipList(), new List<ItemInfo>(), selfOcc, ItemOperateEnum.Watch);
            ItemInfo bagInfo2 = bagComponentC.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet_2.ES_ModelShow.SetCameraPosition(new Vector3(0f, 60f, 150f));
            self.ES_EquipSet_2.ES_ModelShow.ShowPlayerModel(bagInfo2, selfOcc, 0, new List<int>());
        }
    }
}