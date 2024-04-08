﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_PetItemSelect_Refresh: AEvent<Scene, DataUpdate_PetItemSelect>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_PetItemSelect args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.PetItemSelect(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_PetHeChengUpdate_Refresh: AEvent<Scene, DataUpdate_PetHeChengUpdate>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_PetHeChengUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.OnHeChengReturn();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DDataUpdate_PetXiLianUpdate_Refresh: AEvent<Scene, DataUpdate_PetXiLianUpdate>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_PetXiLianUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.OnXiLianUpdate();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (ES_PetList))]
    [FriendOf(typeof (ES_PetHeCheng))]
    [FriendOf(typeof (ES_PetXiLian))]
    [FriendOf(typeof (ES_PetShouHu))]
    [FriendOf(typeof (DlgPet))]
    public static class DlgPetSystem
    {
        public static void RegisterUIEvent(this DlgPet self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgPet self, Entity contextData = null)
        {
            self.View.E_PetToggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnFunctionSetBtn(this DlgPet self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_PetToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_HeChengToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_XiLianToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_ShouHuToggle.gameObject, index == 3);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_PetList.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetList.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_PetHeCheng.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetHeCheng.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_PetXiLian.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetXiLian.OnUpdateUI();
                    break;
                case 3:
                    self.View.ES_PetShouHu.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetShouHu.OnUpdateUI();
                    break;
            }
        }

        public static void PetItemSelect(this DlgPet self, string dataParams)
        {
            string[] paramsList = dataParams.Split('@');
            long petId = long.Parse(paramsList[1]);
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId);
            if (paramsList[0] == PetOperationType.XiLian.ToString())
            {
                self.View.ES_PetXiLian.OnXiLianSelect(rolePetInfo);
            }
            else if (paramsList[0] == PetOperationType.HeCheng.ToString())
            {
                self.View.ES_PetHeCheng.OnHeChengSelect(rolePetInfo);
            }
            else if (paramsList[0] == PetOperationType.UpStar_Main.ToString())
            {
                // self.UIPageView.UISubViewList[(int)PetPageEnum.PetUpStar].GetComponent<UIPetUpStarComponent>().PetMainSelect(rolePetInfo);
            }
            else if (paramsList[0] == PetOperationType.UpStar_FuZh.ToString())
            {
                // self.UIPageView.UISubViewList[(int)PetPageEnum.PetUpStar].GetComponent<UIPetUpStarComponent>().PetItemSelect(rolePetInfo);
            }
        }

        public static void OnHeChengReturn(this DlgPet self)
        {
            if (self.View.ES_PetHeCheng.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_PetHeCheng.OnHeChengReturn();
            }
        }

        private static void OnCloseButton(this DlgPet self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Pet);
        }

        public static async ETTask RequestPetHeXinSelect(this DlgPet self)
        {
            if (self.View.ES_PetList.uiTransform.gameObject.activeSelf)
            {
                await self.View.ES_PetList.OnButtonEquipHeXin();
            }
        }

        public static void OnEquipPetHeXin(this DlgPet self)
        {
            if (self.View.ES_PetList.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_PetList.OnEquipPetHeXin();
            }
        }

        public static void OnXiLianUpdate(this DlgPet self)
        {
            if (self.View.ES_PetXiLian.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_PetXiLian.OnXiLianUpdate();
            }
        }
    }
}