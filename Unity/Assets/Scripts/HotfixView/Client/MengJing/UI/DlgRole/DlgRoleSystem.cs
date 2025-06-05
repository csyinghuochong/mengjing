using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemUpdate_DlgRoleAndBagRefresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.Refresh();
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.View.ES_RoleBag?.RefreshBagItems();
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.View.ES_RoleGem?.RefreshBagItems();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_EquipWear_RefreshEquip : AEvent<Scene, EquipWear>
    {
        protected override async ETTask Run(Scene scene, EquipWear args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.OnEquipWear();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_HuiShouSelect_Refreshitem : AEvent<Scene, HuiShouSelect>
    {
        protected override async ETTask Run(Scene scene, HuiShouSelect args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.OnHuiShouSelect(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_EquipHuiShow_Refreshitem : AEvent<Scene, EquipHuiShow>
    {
        protected override async ETTask Run(Scene scene, EquipHuiShow args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.OnEquipHuiShow();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_UpdateRoleProper_Refresh : AEvent<Scene, DataUpdate_UpdateRoleProper>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_UpdateRoleProper args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.View.ES_RoleProperty.RefreshRoleProperty();
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Demo)]
    public class ItemOperateGem_Refresh : AEvent<Scene, ItemOperateGem>
    {
        protected override async ETTask Run(Scene scene, ItemOperateGem args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.OnUpdateLastItem();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_RoleZodiac))]
    [FriendOf(typeof(ES_RoleQiangHua))]
    [FriendOf(typeof(ES_RoleHuiShou))]
    [FriendOf(typeof(ES_EquipSet))]
    [FriendOf(typeof(ES_RoleGem))]
    [FriendOf(typeof(ES_RoleProperty))]
    [FriendOf(typeof(ES_RoleBag))]
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(DlgRole))]
    public static class DlgRoleSystem
    {
        public static void RegisterUIEvent(this DlgRole self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_ZodiacButton.AddListenerAsync(self.OnZodiacButton);

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);

            ReddotComponentC reddotComponent = self.Root().GetComponent<ReddotComponentC>();
            reddotComponent.UpdateReddont(ReddotType.RolePoint);

            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgRole self, Entity contextData = null)
        {
            self.ShowGuide().Coroutine();
        }
        
        public static void BeforeUnload(this DlgRole self)
        {
            if (SettingData.ModelShow == 1)
            {
                self.Root().CurrentScene().GetComponent<MJCameraComponent>().SetBuildExit();
            }

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
        }

        public static async ETTask ShowGuide(this DlgRole self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIRole");
        }
        
        public static void Reddot_RolePoint(this DlgRole self, int num)
        {
            self.View.E_Type_PropertyToggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        private static void OnFunctionSetBtn(this DlgRole self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_RoleBag.uiTransform.gameObject.SetActive(true);
                    // self.View.E_ZodiacButton.gameObject.SetActive(true);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
                case 1:
                    self.View.ES_RoleProperty.uiTransform.gameObject.SetActive(true);
                    // self.View.E_ZodiacButton.gameObject.SetActive(true);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
                case 2:
                    self.View.ES_RoleGem.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleGem.OnUpdateUI();
                    // self.View.E_ZodiacButton.gameObject.SetActive(false);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.View.ES_EquipSet.EquipSetHide(false);
                    break;
                case 3:
                    self.View.ES_RoleHuiShou.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleHuiShou.OnUpdateUI();
                    // self.View.E_ZodiacButton.gameObject.SetActive(false);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(false);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
                case 4:
                    self.View.ES_RoleQiangHua.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleQiangHua.OnUpdateUI();
                    // self.View.E_ZodiacButton.gameObject.SetActive(false);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(false);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
                case 5:
                    self.View.ES_RoleZodiac.uiTransform.gameObject.SetActive(true);
                    self.View.ES_EquipSet.uiTransform.gameObject.SetActive(false);
                    self.View.ES_EquipSet.EquipSetHide(true);
                    break;
            }

            self.Refresh();
        }

        public static void OnEquipWear(this DlgRole self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            ItemInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.View.ES_EquipSet.ChangeWeapon(bagInfo, userInfoComponent.UserInfo.Occ);
        }

        public static void Refresh(this DlgRole self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.View.ES_EquipSet.PlayerLv(userInfo.Lv);
            self.View.ES_EquipSet.PlayerName(userInfo.Name);
            self.View.ES_EquipSet.PlayerCombat(userInfo.Combat);
            self.View.ES_EquipSet.ShowPlayerModel(new ItemInfo(), userInfo.Occ, 0, new List<int>());

            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
            self.View.ES_EquipSet.RefreshEquip(bagComponentC.GetItemsByLoc(ItemLocType.ItemLocEquip),
                bagComponentC.GetItemsByLoc(ItemLocType.ItemLocEquip_2), userInfoComponentC.UserInfo.Occ, ItemOperateEnum.Juese);
        }

        public static bool OnClickXiangQianItem(this DlgRole self, ItemInfo bagInfo)
        {
            if (self.View.ES_RoleGem.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_RoleGem.OnClickXiangQianItem(bagInfo);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static void OnUpdateLastItem(this DlgRole self)
        {
            if (self.View.ES_RoleGem.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_RoleGem.OnUpdateLastItem();
            }
        }

        public static void OnHuiShouSelect(this DlgRole self, string param_1)
        {
            if (self.View.ES_RoleHuiShou.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_RoleHuiShou.OnHuiShouSelect(param_1);
            }
        }

        public static void OnEquipHuiShow(this DlgRole self)
        {
            if (self.View.ES_RoleHuiShou.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_RoleHuiShou.OnEquipHuiShow();
            }
        }

        public static async ETTask OnZodiacButton(this DlgRole self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Lv < 30)
            {
                FlyTipComponent.Instance.ShowFlyTip("30级开启生肖系统喔！");
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleZodiac);
            DlgRoleZodiac dlgRoleZodiac = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleZodiac>();
            dlgRoleZodiac.OnInitUI(self.View.ES_EquipSet.EquipInfoList, self.View.ES_EquipSet.Occ, self.View.ES_EquipSet.ItemOperateEnum);

            self.View.E_ZodiacButton.gameObject.SetActive(false);
            self.View.ES_EquipSet.uiTransform.gameObject.SetActive(false);
        }

        public static void OnCloseRoleZodiac(this DlgRole self)
        {
            self.View.E_ZodiacButton.gameObject.SetActive(true);
            self.View.ES_EquipSet.uiTransform.gameObject.SetActive(true);
        }

        public static void OnUpdateRoleZodiac(this DlgRole self)
        {
            if (self.View.ES_RoleZodiac.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_RoleZodiac.OnUpdate();
            }
        }
    }
}