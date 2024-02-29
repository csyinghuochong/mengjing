using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_RoleProperty))]
    [FriendOf(typeof (ES_RoleBag))]
    [FriendOf(typeof (UserInfoComponentClient))]
    [FriendOf(typeof (DlgRole))]
    public static class DlgRoleSystem
    {
        public static void RegisterUIEvent(this DlgRole self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);

            self.ESEquipItems_1.Add(self.View.ES_EquipItemWuqi_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemYifu_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemFuhu_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemJiezhi_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemShiping1_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemShiping2_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemShiping3_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemXiezi_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemKuzi_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemYaodai_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemShouzhuo_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemToukui_1);
            self.ESEquipItems_1.Add(self.View.ES_EquipItemXianglian_1);

            self.ESEquipItems_2.Add(self.View.ES_EquipItemWuqi_2);
        }

        public static void ShowWindow(this DlgRole self, Entity contextData = null)
        {
            self.View.E_BagToggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);

            self.RefreshPlayerInfo();
        }

        private static void OnFunctionSetBtn(this DlgRole self, int index)
        {
            Log.Debug($"按下Toggle：{index}");
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            UICommonHelper.SetToggleShow(self.View.E_BagToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_PropertyToggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_RoleBag.uiTransform.gameObject.SetActive(true);
                    self.RefreshEquip();
                    break;
                case 1:
                    self.View.ES_RoleProperty.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        private static void OnCloseButton(this DlgRole self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Role);
        }

        private static void RefreshPlayerInfo(this DlgRole self)
        {
            // 假数据
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentClient>().UserInfo;

            self.View.E_RoseLvText.text = userInfo.Lv.ToString();
            self.View.E_RoseNameText.text = userInfo.Name;

            self.View.ES_ModelShow.SetPosition(Vector3.zero, new Vector3(0f, 70f, 150f));
            self.View.ES_ModelShow.ShowPlayerModel(new BagInfo(), userInfo.Occ, 0);
        }

        private static void RefreshEquip(this DlgRole self)
        {
            BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();
            UserInfoComponentClient userInfoComponentClient = self.Root().GetComponent<UserInfoComponentClient>();

            for (int i = 0; i < self.ESEquipItems_1.Count; i++)
            {
                self.ESEquipItems_1[i].InitUI(FunctionUI.GetItemSubtypeByWeizhi(i));
            }

            for (int i = 0; i < self.ESEquipItems_2.Count; i++)
            {
                self.ESEquipItems_2[i].InitUI(FunctionUI.GetItemSubtypeByWeizhi(i));
            }

            self.RefreshEquip_1(bagComponentClient.GetItemsByItem((int)ItemLocType.ItemLocEquip), userInfoComponentClient.UserInfo.Occ,
                ItemOperateEnum.Juese);

            self.RefreshEquip_2(bagComponentClient.GetItemsByItem((int)ItemLocType.ItemLocEquip_2), userInfoComponentClient.UserInfo.Occ,
                ItemOperateEnum.Juese);
        }

        private static void RefreshEquip_1(this DlgRole self, List<BagInfo> equiplist, int occ, ItemOperateEnum itemOperateEnum)
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
                    self.ESEquipItems_1[itemConfig.ItemSubType - 1].Refresh(equiplist[i], occ, itemOperateEnum, equiplist);
                }

                if (itemConfig.ItemSubType == (int)ItemSubTypeEnum.Shiping)
                {
                    self.ESEquipItems_1[itemConfig.ItemSubType + shipingIndex - 1].Refresh(equiplist[i], occ, itemOperateEnum, equiplist);
                    shipingIndex++;
                }

                if (itemConfig.ItemSubType > (int)ItemSubTypeEnum.Shiping)
                {
                    self.ESEquipItems_1[itemConfig.ItemSubType + 1].Refresh(equiplist[i], occ, itemOperateEnum, equiplist);
                }
            }
        }

        private static void RefreshEquip_2(this DlgRole self, List<BagInfo> equiplist, int occ, ItemOperateEnum itemOperateEnum)
        {
            for (int i = 0; i < equiplist.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equiplist[i].ItemID);
                if (itemConfig.EquipType == 101)
                {
                    continue;
                }

                self.ESEquipItems_2[itemConfig.ItemSubType - 1].Refresh(equiplist[i], occ, itemOperateEnum, equiplist);
            }
        }
    }
}