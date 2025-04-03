using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanMenuViewComponent))]
    [FriendOf(typeof(DlgJiaYuanMenu))]
    public static class DlgJiaYuanMenuSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanMenu self)
        {
            self.View.E_ImageBgButton.AddListener(self.OnImageBgButton);
            self.View.E_ImageBg_1Button.AddListener(self.OnImageBgButton);
            self.View.E_Button_PlanButton.AddListener(self.OnButton_PlanButton);
            self.View.E_Button_WatchButton.AddListener(self.OnButton_WatchButton);
            self.View.E_Button_GatherButton.AddListenerAsync(self.OnButton_GatherButton);
            self.View.E_Button_UprootButton.AddListener(self.OnButton_UprootButton);
            self.View.E_Button_SellButton.AddListenerAsync(self.OnButton_SellButton);
            self.View.E_Button_OpenButton.gameObject.SetActive(false);
            self.View.E_Button_CleanButton.AddListenerAsync(self.OnButton_CleanButton);
            self.View.E_Button_CleanButton.gameObject.SetActive(false);
            self.View.E_Button_OpenButton.AddListener(self.OnButton_OpenButton);
        }

        public static void ShowWindow(this DlgJiaYuanMenu self, Entity contextData = null)
        {
        }

        public static void OnUpdateRubsh(this DlgJiaYuanMenu self, Unit unit)
        {
            self.UnitId = unit.Id;
            self.View.E_Button_WatchButton.gameObject.SetActive(false);
            self.View.E_Button_UprootButton.gameObject.SetActive(false);
            self.View.E_Button_PlanButton.gameObject.SetActive(false);
            self.View.E_Button_SellButton.gameObject.SetActive(false);
            self.View.E_Button_GatherButton.gameObject.SetActive(false);
            self.View.E_Button_OpenButton.gameObject.SetActive(false);
            self.View.E_Button_CleanButton.gameObject.SetActive(true);
        }

        public static async ETTask OnButton_CleanButton(this DlgJiaYuanMenu self)
        {
            long masterid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.JiaYuan)
            {
                masterid = self.Root().GetComponent<JiaYuanComponentC>().MasterId;
            }

            await JiaYuanNetHelper.JiaYuanPickRequest(self.Root(), self.UnitId, masterid);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);
        }

        public static void OnUpdatePasture(this DlgJiaYuanMenu self, Unit unit)
        {
            Unit mainunit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            bool ismyJiayuan = self.Root().GetComponent<JiaYuanComponentC>().IsMyJiaYuan(mainunit.Id);

            self.OperateType = ismyJiayuan ? 2 : 4;

            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            Camera mainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            Vector2 OldPosition =
                    WorldPosiToUIPos.WorldPosiToUIPosition(unit.Position, self.View.uiTransform.gameObject, uiCamera, mainCamera, false);
            Vector3 NewPosition = Vector3.zero;
            NewPosition.x = OldPosition.x;
            NewPosition.y = OldPosition.y;
            self.View.EG_PositionSetRectTransform.localPosition = NewPosition;

            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long startTime = numericComponent.GetAsLong(NumericType.StartTime);
            int gatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
            long GatherLastTime = numericComponent.GetAsLong(NumericType.GatherLastTime);
            int getcode = ET.JiaYuanHelper.GetPastureShouHuoItem(unit.ConfigId, startTime, gatherNumber, GatherLastTime);
            self.UnitId = unit.Id;
            self.View.E_Button_WatchButton.gameObject.SetActive(false);
            self.View.E_Button_UprootButton.gameObject.SetActive(false);
            self.View.E_Button_PlanButton.gameObject.SetActive(false);
            self.View.E_Button_SellButton.gameObject.SetActive(true && ismyJiayuan);
            self.View.E_Button_GatherButton.gameObject.SetActive(getcode == ErrorCode.ERR_Success);
        }

        public static void OnUpdatePlan(this DlgJiaYuanMenu self)
        {
            DlgJiaYuanMain jiaYuanViewComponent = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>();
            Unit unit = JiaYuanHelper.GetUnitByCellIndex(self.Root().CurrentScene(), jiaYuanViewComponent.CellIndex);

            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            Camera mainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            Vector2 OldPosition = WorldPosiToUIPos.WorldPosiToUIPosition(ConfigData.PlanPositionList[jiaYuanViewComponent.CellIndex],
                self.View.uiTransform.gameObject, uiCamera, mainCamera, false);
            Vector3 NewPosition = Vector3.zero;
            NewPosition.x = OldPosition.x;
            NewPosition.y = OldPosition.y;

            self.View.EG_PositionSetRectTransform.localPosition = NewPosition;

            Unit mainunit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            bool ismyJiayuan = self.Root().GetComponent<JiaYuanComponentC>().IsMyJiaYuan(mainunit.Id);

            self.OperateType = ismyJiayuan ? 1 : 3;
            self.View.E_Button_WatchButton.gameObject.SetActive(ismyJiayuan && unit != null);
            self.View.E_Button_UprootButton.gameObject.SetActive(ismyJiayuan && unit != null);
            self.View.E_Button_PlanButton.gameObject.SetActive(ismyJiayuan && unit == null);
            self.View.E_Button_SellButton.gameObject.SetActive(false);
            if (unit != null)
            {
                self.UnitId = unit.Id;
                NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
                long startTime = numericComponent.GetAsLong(NumericType.StartTime);
                int gatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
                long gatherLastTime = numericComponent.GetAsLong(NumericType.GatherLastTime);
                self.View.E_Button_GatherButton.gameObject.SetActive(
                    ET.JiaYuanHelper.GetPlanShouHuoItem(unit.ConfigId, startTime, gatherNumber, gatherLastTime) ==
                    ErrorCode.ERR_Success);
            }
            else
            {
                self.UnitId = 0;
                self.View.E_Button_GatherButton.gameObject.SetActive(false);
            }
        }

        public static void OnImageBgButton(this DlgJiaYuanMenu self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);
        }

        public static void OnButton_WatchButton(this DlgJiaYuanMenu self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanPlanWatch).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);
        }

        public static async ETTask OnButton_SellButton(this DlgJiaYuanMenu self)
        {
            M2C_JiaYuanUprootResponse response = await JiaYuanNetHelper.JiaYuanUprootRequest(self.Root(), 0, self.UnitId, 2);

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().JiaYuanPastureList_7 = response.JiaYuanPastureList;

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>().OnUpdatePlanNumber();
        }

        public static void OnButton_UprootButton(this DlgJiaYuanMenu self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "是否移除农作物?", () => { self.RequestUproot().Coroutine(); }, null).Coroutine();
        }

        public static async ETTask RequestUproot(this DlgJiaYuanMenu self)
        {
            DlgJiaYuanMain dlgLogic = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>();
            Unit unit = JiaYuanHelper.GetUnitByCellIndex(self.Root().CurrentScene(), dlgLogic.CellIndex);
            if (unit == null)
            {
                return;
            }

            await JiaYuanNetHelper.JiaYuanUprootRequest(self.Root(), dlgLogic.CellIndex, unit.Id, 1);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);
        }

        public static async ETTask OnButton_GatherButton(this DlgJiaYuanMenu self)
        {
            long masterid = self.Root().GetComponent<JiaYuanComponentC>().MasterId;

            switch (self.OperateType)
            {
                case 1:
                    DlgJiaYuanMain dlgJiaYuanMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>();
                    Unit unit = JiaYuanHelper.GetUnitByCellIndex(self.Root().CurrentScene(), dlgJiaYuanMain.CellIndex);
                    if (unit == null)
                    {
                        return;
                    }

                    await JiaYuanNetHelper.JiaYuanGatherRequest(self.Root(), dlgJiaYuanMain.CellIndex, unit.Id, 1);
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);

                    break;
                case 2:
                    await JiaYuanNetHelper.JiaYuanGatherRequest(self.Root(), 0, self.UnitId, 2);
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);

                    break;
                case 3:
                    dlgJiaYuanMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>();
                    unit = JiaYuanHelper.GetUnitByCellIndex(self.Root().CurrentScene(), dlgJiaYuanMain.CellIndex);
                    if (unit == null)
                    {
                        return;
                    }

                    await JiaYuanNetHelper.JiaYuanGatherOtherRequest(self.Root(), dlgJiaYuanMain.CellIndex, masterid, unit.Id, 1);
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);

                    break;
                case 4:
                    await JiaYuanNetHelper.JiaYuanGatherOtherRequest(self.Root(), 0, masterid, self.UnitId, 2);
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);

                    break;
                default:
                    break;
            }
        }

        public static void OnButton_PlanButton(this DlgJiaYuanMenu self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanBag).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);
        }

        public static void OnButton_OpenButton(this DlgJiaYuanMenu self)
        {
        }
    }
}