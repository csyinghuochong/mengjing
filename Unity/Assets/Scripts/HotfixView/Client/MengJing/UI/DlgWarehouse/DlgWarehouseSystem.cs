using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemUpdate_DlgWarehouseRefresh: AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgWarehouse>()?.View.ES_WarehouseRole?.Refresh();
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgWarehouse>()?.View.ES_WarehouseGem?.Refresh();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_OnAccountWarehous_DlgWarehouseRefresh: AEvent<Scene, DataUpdate_OnAccountWarehous>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_OnAccountWarehous args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgWarehouse>()?.View.ES_WarehouseAccount
                    ?.OnAccountWarehous(args.DataParamString, args.baginfoId);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (ES_WarehouseRole))]
    [FriendOf(typeof (ES_WarehouseAccount))]
    [FriendOf(typeof (ES_WarehouseGem))]
    [FriendOf(typeof (DlgWarehouse))]
    public static class DlgWarehouseSystem
    {
        public static void RegisterUIEvent(this DlgWarehouse self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgWarehouse self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgWarehouse self, int index)
        {
            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_WarehouseRole.uiTransform.gameObject.SetActive(true);
                    self.View.ES_WarehouseRole.Refresh();
                    break;
                case 1:
                    self.View.ES_WarehouseAccount.uiTransform.gameObject.SetActive(true);
                    self.View.ES_WarehouseAccount.RefreshBagItems();
                    break;
                case 2:
                    self.View.ES_WarehouseGem.uiTransform.gameObject.SetActive(true);
                    self.View.ES_WarehouseGem.Refresh();
                    break;
            }
        }
    }
}