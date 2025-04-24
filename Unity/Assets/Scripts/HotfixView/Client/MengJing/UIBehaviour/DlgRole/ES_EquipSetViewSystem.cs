using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_EquipItem))]
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(ES_EquipSet))]
    [FriendOfAttribute(typeof(ES_EquipSet))]
    public static partial class ES_EquipSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.ESEquipItems_1.Add(self.ES_EquipItemWuqi_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemYifu_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemFuhu_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemJiezhi_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemShiping1_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemShiping2_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemShiping3_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemShiping4_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemXiezi_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemKuzi_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemYaodai_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemShouzhuo_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemToukui_1);
            self.ESEquipItems_1.Add(self.ES_EquipItemXianglian_1);

            self.ESEquipItems_2.Add(self.ES_EquipItemWuqi_2);
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            self.ES_EquipItemWuqi_2.uiTransform.gameObject.SetActive(occ == 3);
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipSet self)
        {
            self.DestroyWidget();
        }

        public static void SetCallBack(this ES_EquipSet self, Action<ItemInfo> action)
        {
            foreach (ES_EquipItem item in self.ESEquipItems_1)
            {
                item.OnClickAction = action;
            }

            foreach (ES_EquipItem item in self.ESEquipItems_2)
            {
                item.OnClickAction = action;
            }
        }

        public static void PlayerLv(this ES_EquipSet self, int lv)
        {
            self.E_RoseLvText.text = lv.ToString();
        }

        public static void PlayerName(this ES_EquipSet self, string playerName)
        {
            self.E_RoseNameText.text = playerName;
        }

        public static void PlayerCombat(this ES_EquipSet self, int combat)
        {
            self.E_CombatText.text = combat.ToString();
        }

        public static void ShowPlayerModel(this ES_EquipSet self, ItemInfo bagInfo, int occ, int equipIndex, List<int> fashonids, int position = 0)
        {
            if (SettingData.ModelShow == 0)
            {
                self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 70f, 150f));
                self.ES_ModelShow.ShowPlayerModel(bagInfo, occ, equipIndex, fashonids);
            }
        }

        public static void RefreshEquip(this ES_EquipSet self, List<ItemInfo> equiplist_1, List<ItemInfo> equiplist_2, int occ,
        ItemOperateEnum itemOperateEnum)
        {
            for (int i = 0; i < self.ESEquipItems_1.Count; i++)
            {
                ES_EquipItem equipItem = self.ESEquipItems_1[i];
                equipItem.InitUI(FunctionUI.GetItemSubtypeByWeizhi(i));
            }

            for (int i = 0; i < self.ESEquipItems_2.Count; i++)
            {
                ES_EquipItem equipItem = self.ESEquipItems_2[i];
                equipItem.InitUI(FunctionUI.GetItemSubtypeByWeizhi(i));
            }

            self.RefreshEquip_1(equiplist_1, occ, itemOperateEnum);
            self.RefreshEquip_2(equiplist_2, occ, itemOperateEnum);
        }

        public static void EquipSetHide(this ES_EquipSet self, bool value)
        {
            self.EG_EquipSetHideRectTransform.gameObject.SetActive(value);
        }

        public static void PlayShowIdelAnimate(this ES_EquipSet self, BagInfo bagInfo)
        {
            self.ES_ModelShow.PlayShowIdelAnimate();
        }

        public static void ChangeWeapon(this ES_EquipSet self, ItemInfo bagInfo, int occ)
        {
            self.ES_ModelShow.ChangeWeapon(bagInfo, occ);
        }

        private static void RefreshEquip_1(this ES_EquipSet self, List<ItemInfo> equiplist, int occ, ItemOperateEnum itemOperateEnum)
        {
            int shipingIndex = 0;
            self.Occ = occ;
            self.EquipInfoList = equiplist;
            self.ItemOperateEnum = itemOperateEnum;
            for (int i = 0; i < equiplist.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equiplist[i].ItemID);
                if (itemConfig.EquipType == 101 || itemConfig.EquipType == 201)
                {
                    continue;
                }

                if (itemConfig.ItemType == 4)
                {
                    continue;
                }

                if (itemConfig.ItemSubType < (int)ItemSubTypeEnum.Shiping)
                {
                    ES_EquipItem esEquipItem = self.ESEquipItems_1[itemConfig.ItemSubType - 1];
                    esEquipItem.Refresh(equiplist[i], occ, itemOperateEnum, equiplist);
                }

                if (itemConfig.ItemSubType == (int)ItemSubTypeEnum.Shiping)
                {
                    ES_EquipItem esEquipItem = self.ESEquipItems_1[itemConfig.ItemSubType + shipingIndex - 1];
                    esEquipItem.Refresh(equiplist[i], occ, itemOperateEnum, equiplist, 1);
                    shipingIndex++;
                }

                if (itemConfig.ItemSubType > (int)ItemSubTypeEnum.Shiping)
                {
                    ES_EquipItem esEquipItem = self.ESEquipItems_1[itemConfig.ItemSubType + (ConfigData.EquipShiPingMax - 2)];
                    esEquipItem.Refresh(equiplist[i], occ, itemOperateEnum, equiplist);
                }
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.OnUpdateRoleZodiac();
        }

        private static void RefreshEquip_2(this ES_EquipSet self, List<ItemInfo> equiplist, int occ, ItemOperateEnum itemOperateEnum)
        {
            for (int i = 0; i < equiplist.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equiplist[i].ItemID);
                if (itemConfig.EquipType == 101)
                {
                    continue;
                }

                ES_EquipItem esEquipItem = self.ESEquipItems_2[itemConfig.ItemSubType - 1];
                esEquipItem.Refresh(equiplist[i], occ, itemOperateEnum, equiplist);
            }
        }
    }
}
