using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_MainChatItem))]
    [FriendOf(typeof (ChatComponent))]
    [FriendOf(typeof (TaskComponentC))]
    [FriendOf(typeof (UserInfoComponentC))]
    [FriendOf(typeof (DlgMain))]
    public static class DlgMainSystem
    {
        [Event(SceneType.Demo)]
        public class DataUpdate_TaskTrace_Refresh: AEvent<Scene, DataUpdate_TaskTrace>
        {
            protected override async ETTask Run(Scene scene, DataUpdate_TaskTrace args)
            {
                scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskTrace();
                await ETTask.CompletedTask;
            }
        }

        [Event(SceneType.Demo)]
        public class DataUpdate_OnRecvChat_MainChatItemsRefresh: AEvent<Scene, DataUpdate_OnRecvChat>
        {
            protected override async ETTask Run(Scene root, DataUpdate_OnRecvChat args)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvChat();
                await ETTask.CompletedTask;
            }
        }

        [Event(SceneType.Demo)]
        public class DataUpdate_MainHeroMove_MainChatItemsRefresh: AEvent<Scene, DataUpdate_MainHeroMove>
        {
            protected override async ETTask Run(Scene root, DataUpdate_MainHeroMove args)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnMainHeroMove();
                await ETTask.CompletedTask;
            }
        }

        [Event(SceneType.Demo)]
        public class DataUpdate_BeforeMove_Refresh: AEvent<Scene, DataUpdate_BeforeMove>
        {
            protected override async ETTask Run(Scene root, DataUpdate_BeforeMove args)
            {
                if (args.DataParamString == "1")
                {
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.AutoHorse();
                }

                root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnMoveStart();

                await ETTask.CompletedTask;
            }
        }

        [Invoke(TimerInvokeType.JoystickTimer)]
        public class JoystickTimer: ATimer<DlgMain>
        {
            protected override void Run(DlgMain self)
            {
                try
                {
                    self.OnUpdate();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [Invoke(TimerInvokeType.MapMiniTimer)]
        public class MapMiniTimer: ATimer<DlgMain>
        {
            protected override void Run(DlgMain self)
            {
                try
                {
                    self.OnUpdateMiniMap();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.E_ShrinkButton.AddListener(self.OnShrinkButton);
            self.View.E_RoseEquipButton.AddListenerAsync(self.OnRoseEquipButton);
            self.View.E_PetButton.AddListenerAsync(self.OnPetButton);
            self.View.E_RoseSkillButton.AddListenerAsync(self.OnRoseSkillButton);
            self.View.E_TaskButton.AddListenerAsync(self.OnTaskButton);
            self.View.E_FriendButton.AddListener(self.OnFriendButton);
            self.View.E_ChengJiuButton.AddListener(self.OnChengJiuButton);

            self.View.E_AdventureButton.AddListener(self.OnAdventureButton);
            self.View.E_PetFormationButton.AddListener(self.OnPetFormationButton);
            self.View.E_CityHorseButton.AddListener(self.OnCityHorseButton);
            self.View.E_TeamDungeonButton.AddListener(self.OnTeamDungeonButton);
            self.View.E_JiaYuanButton.AddListener(self.OnJiaYuanButton);
            self.View.E_NpcDuiHuaButton.AddListener(self.OnNpcDuiHuaButton);
            self.View.E_UnionButton.AddListener(self.OnUnionButton);
            self.View.E_OpenChatButton.AddListener(self.OnOpenChat);
            self.View.E_Button_ZhanKai.AddListener(self.OnButtonZhanKai);
            self.View.E_Btn_RerurnBuilding.AddListener(self.OnClickReturnButton);

            self.View.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Move(pdata as PointerEventData); });
            self.View.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.View.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.View.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.View.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.View.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Fix(pdata as PointerEventData); });
            self.View.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.View.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.View.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.View.E_SetButton.AddListener(self.OnSetButton);

            self.View.E_MainTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMainTaskItemsRefresh);
            self.View.E_MainChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMainChatItemsRefresh);
            self.View.E_RoseTaskButton.AddListener(self.OnRoseTaskButton);
            self.RefreshMainTaskItems();

            self.View.E_MiniMapButtonButton.AddListener(self.OnOpenMap);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            self.ObstructLayer = 1 << LayerMask.NameToLayer(LayerEnum.Obstruct.ToString());
            self.BuildingLayer = 1 << LayerMask.NameToLayer(LayerEnum.Building.ToString());

            self.ResetJoystick();
            self.RefreshLeftUp();

            // IOS适配
            IPHoneHelper.SetPosition(self.View.EG_PhoneLeftRectTransform.gameObject, new Vector2(120f, 0f));
        }

        public static void BeforeUnload(this DlgMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.MapMiniTimer);
        }

        public static void AutoHorse(this DlgMain self)
        {
            NumericComponentC numericComponent = self.MainUnit.GetComponent<NumericComponentC>();
            if (numericComponent.GetAsInt(NumericType.HorseRide) == 0 && numericComponent.GetAsInt(NumericType.HorseFightID) > 0)
            {
                self.OnButton_Horse(false);
            }
        }

        public static void OnButton_Horse(this DlgMain self, bool showtip)
        {
            // Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // int now_horse = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseRide);
            // if (now_horse == 0 && !self.Root().GetComponent<BattleMessageComponent>().IsCanRideHorse())
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("战斗状态不能骑马!");
            //     return;
            // }
            //
            // MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            // if (SceneConfigHelper.UseSceneConfig(mapComponent.SceneType))
            // {
            //     int sceneid = mapComponent.SceneId;
            //     SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
            //     if (sceneConfig.IfMount == 1)
            //     {
            //         if (showtip)
            //         {
            //             FlyTipComponent.Instance.SpawnFlyTipDi("该场景不能骑马!");
            //         }
            //
            //         return;
            //     }
            // }
            //
            // C2M_HorseRideRequest request = new C2M_HorseRideRequest() { };
            // self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request).Coroutine();
        }

        public static void OnMoveStart(this DlgMain self)
        {
            // if (self.UIOpenBoxComponent != null && self.UIOpenBoxComponent.BoxUnitId > 0)
            // {
            //     self.UIOpenBoxComponent.OnOpenBox(null);
            // }
            //
            // self.UIMainSkillComponent.UIAttackGrid.OnMoveStart();
            //
            // self.MainUnit.GetComponent<SingingComponent>()?.BeginMove();
        }

        public static void OnMainHeroMove(this DlgMain self)
        {
            self.OnMainHeroMoveMiniMap();
            // self.LockTargetComponent.OnMainHeroMove();
            // self.SkillIndicatorComponent.OnMainHeroMove();
            //
            // if (self.TianQiEffectObj != null)
            // {
            //     self.TianQiEffectObj.transform.localPosition = self.MainUnit.Position;
            // }
        }

        #region 左边

        public static void OnRecvTaskTrace(this DlgMain self)
        {
            self.RefreshMainTaskItems();
        }

        private static void OnMainTaskItemsRefresh(this DlgMain self, Transform transform, int index)
        {
            Scroll_Item_MainTask scrollItemMainTask = self.ScrollItemMainTasks[index].BindTrans(transform);
            scrollItemMainTask.Refresh(self.ShowTaskPros[index]);
        }

        private static void RefreshMainTaskItems(this DlgMain self)
        {
            self.ShowTaskPros.Clear();
            foreach (TaskPro taskPro in self.Root().GetComponent<TaskComponentC>().RoleTaskList)
            {
                if (taskPro.TrackStatus == 0)
                {
                    continue;
                }

                self.ShowTaskPros.Add(taskPro);
            }

            self.View.E_RoseTaskButton.gameObject.SetActive(self.ShowTaskPros.Count == 0);

            self.AddUIScrollItems(ref self.ScrollItemMainTasks, self.ShowTaskPros.Count);
            self.View.E_MainTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);
        }

        private static void OnRoseTaskButton(this DlgMain self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();

            int nextTask = taskComponent.GetNextMainTask();
            if (nextTask == 0)
            {
                self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Task);
                return;
            }

            int getNpc = TaskConfigCategory.Instance.Get(nextTask).GetNpcID;
            int fubenId = TaskViewHelp.GetFubenByNpc(getNpc);
            if (fubenId == 0)
            {
                return;
            }

            string fubenName = $"请前往{DungeonConfigCategory.Instance.Get(fubenId).ChapterName} {NpcConfigCategory.Instance.Get(getNpc).Name} 出接取任务";
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (mapComponent.SceneType != SceneTypeEnum.LocalDungeon)
            {
                flyTipComponent.SpawnFlyTipDi(fubenName);
                return;
            }

            int curdungeonid = mapComponent.SceneId;
            if (curdungeonid == fubenId)
            {
                TaskViewHelp.MoveToNpc(self.Root(), getNpc).Coroutine();
                return;
            }

            if (TaskViewHelp.GeToOtherFuben(self.Root(), fubenId, mapComponent.SceneId))
            {
                return;
            }

            flyTipComponent.SpawnFlyTipDi(fubenName);
        }

        #endregion

        #region 左上角信息

        private static void OnSetButton(this DlgMain self)
        {
            self.Root().GetComponent<FlyTipComponent>().SpawnFlyTipDi("打开设置界面");
        }

        private static void RefreshLeftUp(this DlgMain self)
        {
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();

            self.View.E_PlayerHeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, userInfoComponentC.UserInfo.Occ.ToString()));

            self.View.E_RoleNameText.text = userInfoComponentC.UserInfo.Name;
            self.View.E_RoleLvText.text = "等级:" + userInfoComponentC.UserInfo.Lv;

            int maxPiLao = int.Parse(GlobalValueConfigCategory.Instance
                    .Get(numericComponentC.GetAsInt(NumericType.YueKaRemainTimes) > 0? 26 : 10).Value);
            self.View.E_RolePiLaoText.text = "体力:" + userInfoComponentC.UserInfo.PiLao + "/" + maxPiLao;
            self.View.E_RolePiLaoImgImage.fillAmount = 1f * userInfoComponentC.UserInfo.PiLao / maxPiLao;

            int skillNumber = 1 + numericComponentC.GetAsInt(NumericType.MakeType_2) > 0? 1 : 0;
            int maxHuoLi = unit.GetMaxHuoLi(skillNumber);
            self.View.E_RoleHuoLiText.text = "活力:" + userInfoComponentC.UserInfo.Vitality + "/" + maxHuoLi;
            self.View.E_RoleHuoLiImgImage.fillAmount = 1f * userInfoComponentC.UserInfo.Vitality / maxHuoLi;

            // self.View.E_ServerNameText.text = ServerHelper.GetGetServerItem(!GlobalHelp.IsOutNetMode, accountInfoComponent.ServerId).ServerName;
            self.View.E_CombatText.text = $"战力: {userInfoComponentC.UserInfo.Combat}";
        }

        #endregion

        #region 左下角

        private static void OnShrinkButton(this DlgMain self)
        {
            bool isShow = !self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf;
            self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(isShow);
        }

        private static async ETTask OnRoseEquipButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role);
        }

        private static async ETTask OnPetButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Pet);
        }

        private static async ETTask OnRoseSkillButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Skill);
        }

        private static async ETTask OnTaskButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task);
        }

        private static void OnFriendButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Friend);
        }

        private static void OnChengJiuButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ChengJiu);
        }

        private static void OnAdventureButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Dungeon);
        }

        private static void OnPetFormationButton(this DlgMain self)
        {
            Log.Debug("进入宠物探险！！！");
        }

        private static void OnCityHorseButton(this DlgMain self)
        {
            Log.Debug("骑乘！！！");
        }

        private static void OnTeamDungeonButton(this DlgMain self)
        {
            Log.Debug("组队副本！！！");
        }

        private static void OnJiaYuanButton(this DlgMain self)
        {
            Log.Debug("家园！！！");
        }

        private static void OnNpcDuiHuaButton(this DlgMain self)
        {
            Log.Debug("对话！！！");
        }

        private static void OnUnionButton(this DlgMain self)
        {
            Log.Debug("家族！！！");
        }

        #endregion

        # region 摇杆

        private static void UpdateOperateMode(this DlgMain self, int operateMode)
        {
            self.OperateMode = operateMode;

            // 0固定 1移动
            self.View.E_YaoGanDiFixImage.gameObject.SetActive(operateMode == 0);
            self.View.E_YaoGanDiMoveImage.gameObject.SetActive(operateMode == 1);

            //self.YaoGanDiFix.transform.localPosition = new Vector3 (434, 376, 0 );

            self.View.E_CenterShowImage.transform.SetParent(operateMode == 0? self.View.E_YaoGanDiFixImage.transform
                    : self.View.E_YaoGanDiMoveImage.transform);
            self.View.E_CenterShowImage.transform.SetParent(operateMode == 0? self.View.E_YaoGanDiFixImage.transform
                    : self.View.E_YaoGanDiMoveImage.transform);

            self.View.E_CenterShowImage.gameObject.SetActive(self.OperateMode == 0);
            self.View.E_ThumbImage.gameObject.SetActive(self.OperateMode == 0);

            self.SetAlpha(0.3f);

            self.View.E_CenterShowImage.transform.localPosition = Vector3.zero;
            self.View.E_ThumbImage.transform.localPosition = Vector3.zero;
        }

        private static void SetAlpha(this DlgMain self, float value)
        {
            Color color_1 = new Color(1f, 1f, 1f);
            color_1.a = value;
            self.View.E_CenterShowImage.color = color_1;
            self.View.E_ThumbImage.color = color_1;
        }

        private static void PointerDown_Move(this DlgMain self, PointerEventData pdata)
        {
            RectTransform canvas = self.GetYaoGanDi().GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, self.UICamera, out self.OldPoint);
            self.SetAlpha(1f);
            if (self.OperateMode == 0)
            {
                self.View.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.View.E_CenterShowImage.transform.localPosition = Vector3.zero;
                self.View.E_ThumbImage.transform.localPosition = Vector3.zero;
                self.OldPoint = Vector2.zero;
            }
            else
            {
                self.View.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.View.E_CenterShowImage.gameObject.SetActive(true);
                self.View.E_ThumbImage.gameObject.SetActive(true);
                self.View.E_CenterShowImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
                self.View.E_ThumbImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
            }

            //MapHelper.LogMoveInfo($"移动摇杆按下: {TimeHelper.ServerNow()}");
        }

        /// <summary>
        /// 按下就移动
        /// </summary>
        /// <param name="self"></param>
        /// <param name="pdata"></param>
        private static void PointerDown_Fix(this DlgMain self, PointerEventData pdata)
        {
            RectTransform canvas = self.GetYaoGanDi().GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, self.UICamera, out self.OldPoint);
            self.SetAlpha(1f);
            if (self.OperateMode == 0)
            {
                self.View.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.View.E_CenterShowImage.transform.localPosition = Vector3.zero;
                self.View.E_ThumbImage.transform.localPosition = Vector3.zero;
                self.OldPoint = Vector2.zero;
            }
            else
            {
                self.View.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.View.E_CenterShowImage.gameObject.SetActive(true);
                self.View.E_ThumbImage.gameObject.SetActive(true);
                self.View.E_CenterShowImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
                self.View.E_ThumbImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
            }

            //MapHelper.LogMoveInfo($"移动摇杆按下: {TimeHelper.ServerNow()}");
            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            self.BeginDrag(pdata);
        }

        private static void BeginDrag(this DlgMain self, PointerEventData pdata)
        {
            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            //MapHelper.LogMoveInfo($"移动摇杆拖动: {TimeHelper.ServerNow()}");
            self.lastSendTime = 0;
            self.direction = self.GetDirection(pdata);
            self.SendMove(self.direction);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            self.JoystickTimer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.JoystickTimer, self);
        }

        private static GameObject GetYaoGanDi(this DlgMain self)
        {
            return self.OperateMode == 0? self.View.E_YaoGanDiFixImage.gameObject : self.View.E_YaoGanDiMoveImage.gameObject;
        }

        private static int GetDirection(this DlgMain self, PointerEventData pdata)
        {
            RectTransform canvas = self.GetYaoGanDi().GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, self.UICamera, out self.NewPoint);

            Vector3 vector3 = new Vector3(self.NewPoint.x, self.NewPoint.y, 0f);
            float maxDistance = Vector2.Distance(self.OldPoint, self.NewPoint);
            if (maxDistance < self.Distance)
            {
                self.View.E_ThumbImage.transform.localPosition = vector3;
            }
            else
            {
                self.NewPoint = self.OldPoint + (self.NewPoint - self.OldPoint).normalized * self.Distance;
                vector3.x = self.NewPoint.x;
                vector3.y = self.NewPoint.y;
                self.View.E_ThumbImage.transform.localPosition = vector3;
            }

            Vector2 indicator = self.NewPoint - self.OldPoint;
            int angle = 90 - (int)(Mathf.Atan2(indicator.y, indicator.x) * Mathf.Rad2Deg) + (int)self.MainCamera.transform.eulerAngles.y;
            return angle;
        }

        private static void Draging(this DlgMain self, PointerEventData pdata)
        {
            self.direction = self.GetDirection(pdata);
        }

        private static void OnUpdate(this DlgMain self)
        {
            self.SendMove(self.direction);
        }

        private static void OnMainHeroMoveYaoGan(this DlgMain self)
        {
            Unit unit = self.MainUnit;
            Vector3 unitPosition = unit.Position;
            Quaternion unitQuaternion = unit.Rotation;
            Vector3 newv3 = unitPosition + unitQuaternion * Vector3.forward * 3f;
            int obstruct = self.CheckObstruct(unit, newv3);
            if (obstruct == 0)
            {
                return;
            }

            if (unit.GetComponent<MoveComponent>().IsArrived())
            {
                return;
            }

            self.Root().GetComponent<ClientSenderCompnent>().Send(new C2M_Stop());
        }

        private static void SendMove(this DlgMain self, int direction)
        {
            long clientNow = TimeHelper.ClientNow();

            if (clientNow - self.lastSendTime < 30)
            {
                return;
            }

            // if (clientNow - self.AttackComponent.MoveAttackTime < 200)
            // {
            //     return;
            // }

            if (self.lastDirection == direction && clientNow - self.lastSendTime < self.checkTime)
            {
                return;
            }

            Unit unit = self.MainUnit;
            Quaternion rotation = Quaternion.Euler(0, direction, 0);
            float distance = self.CanMoveDistance(unit, rotation);
            distance = Mathf.Max(distance, 2f);
            float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            speed = Mathf.Max(speed, 4f);
            float needTime = distance / speed;
            self.checkTime = (int)(1000 * needTime) - 200;

            //Debug.Log("checkTime..." + distance / speed + " distance:" + distance + " speed:" + speed + " checkTime:" + self.checkTime);
            //移动速度最低发送间隔

            Vector3 unitPosition = unit.Position;

            //检测光墙
            int obstruct = self.CheckObstruct(unit, unitPosition + rotation * Vector3.forward * 2f);
            if (obstruct != 0)
            {
                // unit.GetComponent<StateComponent>().ObstructStatus = 1;
                self.ShowObstructTip(obstruct);
                return;
            }

            // EventType.DataUpdate.Instance.DataType = DataType.BeforeMove;
            // EventType.DataUpdate.Instance.DataParamString = string.Empty;
            // Game.EventSystem.PublishClass(EventType.DataUpdate.Instance);
            Vector3 newv3 = unitPosition + rotation * Vector3.forward * distance;

            //MapHelper.LogMoveInfo($"移动发送请求: {TimeHelper.ServerNow()}");

            C2M_PathfindingResult c2MPathfindingResult = new();
            c2MPathfindingResult.Position = newv3;
            self.Root().GetComponent<ClientSenderCompnent>().Send(c2MPathfindingResult);
            // unit.MoveByYaoGan(newv3, direction, distance, null).Coroutine();

            self.lastSendTime = clientNow;
            self.lastDirection = direction;
        }

        private static void ShowObstructTip(this DlgMain self, int monsterId)
        {
            if (Time.time - self.LastShowTip < 1f)
            {
                return;
            }

            self.LastShowTip = Time.time;
            string monsterName = MonsterConfigCategory.Instance.Get(monsterId).MonsterName;
            // FloatTipManager.Instance.ShowFloatTip($"请先消灭{monsterName}");
        }

        /// <summary>
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unit"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private static float CanMoveDistance(this DlgMain self, Unit unit, Quaternion rotation)
        {
            float intveral = 1f; //每次寻的长度
            int distance = 2;
            int maxnumber = 5; //最多寻多少次
            for (int i = distance; i <= maxnumber; i++)
            {
                Vector3 unitPosi = unit.Position;
                Vector3 target = unitPosi + rotation * Vector3.forward * i * intveral;
                RaycastHit hit;
                //Physics.Raycast(target + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, self.ObstructLayer);
                //if (mapComponent.SceneTypeEnum == SceneTypeEnum.TeamDungeon && i <= 3 && hit.collider != null)
                //{
                //    return -1;
                //}
                distance = i;
                Physics.Raycast(target + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, self.BuildingLayer);
                if (hit.collider != null)
                {
                    Log.Debug($" hit.collider != null: i : {i}   x: {target.x}  z:{target.z} ");
                    break;
                }
            }

            return distance * intveral;
        }

        private static int CheckObstruct(this DlgMain self, Unit unit, Vector3 target)
        {
            RaycastHit hit;
            Physics.Raycast(target + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, self.ObstructLayer);
            if (hit.collider == null)
            {
                return 0;
            }

            int monsterid = int.Parse(hit.collider.gameObject.name);
            List<Unit> units = UnitHelper.GetUnitsByType(unit.Root(), UnitType.Monster);
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].ConfigId == monsterid)
                {
                    return monsterid;
                }
            }

            return 0;
        }

        private static Vector3 GetCanReachPath(this DlgMain self, Vector3 start, Vector3 target)
        {
            Vector3 dir = (target - start).normalized;

            while (true)
            {
                RaycastHit hit;
                int mapMask = (1 << LayerMask.NameToLayer(LayerEnum.Map.ToString()));
                Physics.Raycast(start + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, mapMask);

                if (hit.collider == null)
                {
                    break;
                }

                if (Vector3.Distance(start, target) < 0.2f)
                {
                    break;
                }

                start = start + (0.2f * dir);
            }

            return start;
        }

        private static void ResetJoystick(this DlgMain self)
        {
            self.SetAlpha(0.3f);
            if (self.OperateMode == 0)
            {
                self.View.E_CenterShowImage.transform.localPosition = Vector3.zero;
                self.View.E_ThumbImage.transform.localPosition = Vector3.zero;
            }
            else
            {
                self.View.E_CenterShowImage.gameObject.SetActive(false);
                self.View.E_ThumbImage.gameObject.SetActive(false);
                self.View.E_YaoGanDiFixImage.gameObject.SetActive(false);
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
        }

        private static void ShowUI(this DlgMain self)
        {
        }

        private static void EndDrag(this DlgMain self, PointerEventData pdata)
        {
            long lastTimer = self.JoystickTimer;
            self.ResetJoystick();
            if (lastTimer == 0)
            {
                return;
            }

            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            // if (ErrorCode.ERR_Success != unit.GetComponent<StateComponent>().CanMove())
            // {
            //     return;
            // }

            //MapHelper.LogMoveInfo($"移动摇杆停止: {TimeHelper.ServerNow()}");
            self.Root().GetComponent<ClientSenderCompnent>().Send(new C2M_Stop());
        }

        private static void EndDrag_Old(this DlgMain self, PointerEventData pdata)
        {
            if (!self.View.E_YaoGanDiFixImage.gameObject.activeSelf)
            {
                return;
            }

            self.ResetJoystick();
            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            // if (ErrorCode.ERR_Success != unit.GetComponent<StateComponent>().CanMove())
            // {
            //     return;
            // }

            // if (unit.GetComponent<MoveComponent>().IsArrived())
            // {
            //     return;
            // }

            //MapHelper.LogMoveInfo($"移动摇杆停止: {TimeHelper.ServerNow()}");
            // self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_Stop());
        }

        #endregion

        #region 小地图

        public static void OnOpenMap(this DlgMain self)
        {
            // 测试
            self.Root().GetComponent<MapComponent>().SceneType = (int)SceneTypeEnum.MainCityScene;
            self.Root().GetComponent<MapComponent>().SceneId = 101;

            int sceneType = self.Root().GetComponent<MapComponent>().SceneType;
            int sceneId = self.Root().GetComponent<MapComponent>().SceneId;
            switch (sceneType)
            {
                case (int)SceneTypeEnum.MainCityScene:
                case (int)SceneTypeEnum.LocalDungeon:
                    self.OnOpenBigMap(); //打开主城
                    break;
                case (int)SceneTypeEnum.CellDungeon:
                    // self.OnShowFubenIndex(); //打开副本小地图
                    break;
                default:
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
                    if (sceneConfig.ifShowMinMap == 0)
                    {
                        FlyTipComponent.Instance.SpawnFlyTipDi(GameSettingLanguge.LoadLocalization("当前场景不支持查看小地图"));
                    }
                    else
                    {
                        self.OnOpenBigMap(); //打开主城
                    }

                    break;
            }
        }

        public static void OnOpenBigMap(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MapBig);
        }

        private static void UpdateTianQi(this DlgMain self, string tianqi)
        {
            switch (tianqi)
            {
                case "1":
                    self.View.E_TianQiText.text = "晴天";
                    break;
                case "2":
                    self.View.E_TianQiText.text = "雨天";
                    break;
                default:
                    self.View.E_TianQiText.text = "晴天";
                    break;
            }
        }

        private static void OnMainHeroMoveMiniMap(this DlgMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null || self.MapCamera == null)
            {
                return;
            }

            Vector3 vector3 = unit.Position;
            Vector3 vector31 = new Vector3(vector3.x, vector3.z, 0f);
            Vector2 localPosition = self.GetWordToUIPositon(vector31);
            self.View.E_RawImageRawImage.transform.localPosition = new Vector2(localPosition.x * -1, localPosition.y * -1);
            self.View.EG_HeadListRectTransform.localPosition = new Vector2(localPosition.x * -1, localPosition.y * -1);
        }

        private static void OnUpdateMiniMap(this DlgMain self)
        {
            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());
            List<Unit> allUnit = main.GetParent<UnitComponent>().GetAll();

            int teamNumber = 0;
            // int selfCamp_1 = main.GetBattleCamp();
            for (int i = 0; i < allUnit.Count; i++)
            {
                Unit unit = allUnit[i];
                if (unit.Type != UnitType.Player && unit.Type != UnitType.Monster)
                {
                    continue;
                }

                Vector3 vector31 = new Vector3(unit.Position.x, unit.Position.z, 0f);
                Vector3 vector32 = self.GetWordToUIPositon(vector31);
                GameObject headItem = self.GetTeamPointObj(teamNumber);

                //1自己 2敌对 3队友  4主城
                string showType = "4";
                // if (self.SceneTypeEnum != SceneTypeEnum.MainCityScene && main.IsCanAttackUnit(unit))
                // {
                //     showType = "2";
                // }
                //
                // if (main.IsSameTeam(unit))
                // {
                //     showType = "3";
                // }
                //
                // if (unit.MainHero)
                // {
                //     showType = "1";
                // }

                if (unit.Type == UnitType.Monster)
                {
                    if (unit.ConfigId > 0)
                    {
                        MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                        if (monsterCof.MonsterType == 5)
                        {
                            //6 宝箱
                            if (monsterCof.MonsterSonType == 55)
                            {
                                showType = "6";
                            }

                            //5 精灵 宠物 宠灵书
                            if (monsterCof.MonsterSonType == 57 || monsterCof.MonsterSonType == 58 || monsterCof.MonsterSonType == 59)
                            {
                                showType = "5";
                            }
                        }
                    }
                }

                teamNumber++;
                headItem.transform.Find("1").gameObject.SetActive(showType == "1");
                headItem.transform.Find("2").gameObject.SetActive(showType == "2");
                headItem.transform.Find("3").gameObject.SetActive(showType == "3");
                headItem.transform.Find("4").gameObject.SetActive(showType == "4");
                headItem.transform.Find("5").gameObject.SetActive(showType == "5");
                headItem.transform.Find("6").gameObject.SetActive(showType == "6");
                headItem.transform.localPosition = new Vector2(vector32.x, vector32.y);
            }

            for (int i = teamNumber; i < self.AllPointList.Count; i++)
            {
                self.AllPointList[i].transform.localPosition = self.NoVector3;
            }

            self.Lab_TimeIndex++;
            if (self.Lab_TimeIndex >= 300)
            {
                self.Lab_TimeIndex = 0;
                DateTime serverTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                self.View.E_TimeText.text = $"{serverTime.Hour}:{serverTime.Minute}";
            }
        }

        private static GameObject GetTeamPointObj(this DlgMain self, int index)
        {
            if (self.AllPointList.Count > index)
            {
                return self.AllPointList[index];
            }

            GameObject go = UnityEngine.Object.Instantiate(self.View.EG_HeadItemRectTransform.gameObject, self.View.EG_HeadItemRectTransform.parent,
                true);
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
            self.AllPointList.Add(go);
            return go;
        }

        private static Vector3 GetWordToUIPositon(this DlgMain self, Vector3 vector3)
        {
            GameObject mapCamera = self.MapCamera;
            vector3.x -= mapCamera.transform.position.x;
            vector3.y -= mapCamera.transform.position.z;

            Quaternion rotation = Quaternion.Euler(0, 0, 1 * mapCamera.transform.eulerAngles.y);
            vector3 = rotation * vector3;

            vector3.x *= self.ScaleRateX;
            vector3.y *= self.ScaleRateY;
            return vector3;
        }

        private static async ETTask LoadMapCamera(this DlgMain self)
        {
            GameObject mapCamera = GameObject.Find("MapCamera");
            if (mapCamera == null)
            {
                var path = ABPathHelper.GetUnitPath("Component/MapCamera");
                GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                mapCamera = GameObject.Instantiate(prefab);
                mapCamera.name = "MapCamera";
            }

            Camera camera = mapCamera.GetComponent<Camera>();
            camera.enabled = true;

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.SceneType == (int)SceneTypeEnum.LocalDungeon)
            {
                DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(mapComponent.SceneId);
                mapCamera.transform.position = new Vector3((float)dungeonConfig.CameraPos[0], (float)dungeonConfig.CameraPos[1],
                    (float)dungeonConfig.CameraPos[2]);
                mapCamera.transform.eulerAngles = new Vector3(90, 0, (float)dungeonConfig.CameraPos[3]);
                camera.orthographicSize = (float)dungeonConfig.CameraPos[4];
            }

            if (SceneConfigHelper.UseSceneConfig(mapComponent.SceneType)
                && SceneConfigHelper.ShowMiniMap(mapComponent.SceneType, mapComponent.SceneId))
            {
                SceneConfig dungeonConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
                mapCamera.transform.position = new Vector3((float)dungeonConfig.CameraPos[0], (float)dungeonConfig.CameraPos[1],
                    (float)dungeonConfig.CameraPos[2]);
                mapCamera.transform.eulerAngles = new Vector3(90, 0, (float)dungeonConfig.CameraPos[3]);
                camera.orthographicSize = (float)dungeonConfig.CameraPos[4];
            }

            self.MapCamera = mapCamera;

            self.SceneTypeEnum = self.Root().GetComponent<MapComponent>().SceneType;
            self.ScaleRateX = self.View.E_RawImageRawImage.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);
            self.ScaleRateY = self.View.E_RawImageRawImage.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);
            self.View.E_RawImageRawImage.transform.localPosition = Vector2.zero;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            camera.enabled = false;

            self.OnMainHeroMoveMiniMap();
            await ETTask.CompletedTask;
        }

        private static void BeginChangeScene(this DlgMain self, int lastScene)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.MapMiniTimer);
        }

        private static void ShowMapName(this DlgMain self, string mapname)
        {
            self.View.E_MapNameText.text = mapname;
        }

        private static void OnEnterScene(this DlgMain self)
        {
            self.LoadMapCamera().Coroutine();

            int sceneTypeEnum = self.Root().GetComponent<MapComponent>().SceneType;
            int difficulty = self.Root().GetComponent<MapComponent>().FubenDifficulty;
            int sceneId = self.Root().GetComponent<MapComponent>().SceneId;
            self.View.E_MainCityShowImage.gameObject.SetActive(true);

            //显示地图名称
            switch (sceneTypeEnum)
            {
                case (int)SceneTypeEnum.CellDungeon:
                    self.View.E_MapNameText.text = ChapterConfigCategory.Instance.Get(sceneId).ChapterName;
                    break;
                case (int)SceneTypeEnum.LocalDungeon:
                    string str = string.Empty;
                    if (difficulty == FubenDifficulty.Normal)
                    {
                        str = "(普通)";
                    }

                    if (difficulty == FubenDifficulty.TiaoZhan)
                    {
                        str = "(挑战)";
                    }

                    if (difficulty == FubenDifficulty.DiYu)
                    {
                        str = "(地狱)";
                    }

                    if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(sceneId))
                    {
                        str = string.Empty;
                    }

                    self.View.E_MapNameText.text = DungeonConfigCategory.Instance.Get(sceneId).ChapterName + str;
                    break;
                case (int)SceneTypeEnum.TeamDungeon:
                    str = "";
                    if (difficulty == TeamFubenType.XieZhu)
                    {
                        str = "(协助)";
                    }

                    if (difficulty == TeamFubenType.ShenYuan)
                    {
                        str = "(深渊)";
                    }

                    self.View.E_MapNameText.text = SceneConfigCategory.Instance.Get(sceneId).Name + str;
                    break;
                case SceneTypeEnum.Union:
                    UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                    self.View.E_MapNameText.text = $"{userInfoComponent.UserInfo.UnionName} 家族地图";
                    break;
                default:
                    //显示地图名称
                    self.View.E_MapNameText.text = SceneConfigCategory.Instance.Get(sceneId).Name;
                    break;
            }

            self.View.EG_HeadListRectTransform.gameObject.SetActive(true);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.MapMiniTimer);
            self.MapMiniTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(200, TimerInvokeType.MapMiniTimer, self);

            DateTime serverTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
            self.View.E_TimeText.text = $"{serverTime.Hour}:{serverTime.Minute}";
        }

        #endregion

        #region 聊天

        private static void OnOpenChat(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Chat).Coroutine();
        }

        private static void OnButtonZhanKai(this DlgMain self)
        {
            bool active = self.View.E_Btn_TopRight_1.gameObject.activeSelf;
            self.View.E_Btn_TopRight_1.gameObject.SetActive(!active);
            self.View.E_Btn_TopRight_2.gameObject.SetActive(!active);
            self.View.E_Btn_TopRight_3.gameObject.SetActive(!active);

            self.View.E_Button_ZhanKai.transform.localScale = active ? new Vector3(1f, 1f, 1f) :  new Vector3(-1f, 1f, 1f);
        }
        
        public static void OnClickReturnButton(this DlgMain self)
        {
            Scene zoneScene = self.Root();
            MapComponent mapComponent = zoneScene.GetComponent<MapComponent>();
           
            string tipStr = "确定返回主城？";
            if (mapComponent.SceneType == SceneTypeEnum.Battle)
            {
                tipStr = "现在离开战场,将不会获得战场胜利的奖励哦";
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "", GameSettingLanguge.LoadLocalization(tipStr),
                () =>
                {
                    EnterMapHelper.RequestQuitFuben(self.Root());
                },
                null).Coroutine();
        }

        public static void OnRecvChat(this DlgMain self)
        {
            self.RefreshMainChatItems();
        }

        private static void OnMainChatItemsRefresh(this DlgMain self, Transform transform, int index)
        {
            Scroll_Item_MainChatItem scrollItemMainChatItem = self.ScrollItemMainChatItems[index].BindTrans(transform);
            scrollItemMainChatItem.Refresh(self.ShowChatInfos[index]);
        }

        private static void RefreshMainChatItems(this DlgMain self)
        {
            ChatComponent chatComponent = self.Root().GetComponent<ChatComponent>();
            self.ShowChatInfos.Insert(0, chatComponent.LastChatInfo);

            self.AddUIScrollItems(ref self.ScrollItemMainChatItems, self.ShowChatInfos.Count);
            self.View.E_MainChatItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChatInfos.Count);
            self.UpdatePosition().Coroutine();
        }

        private static async ETTask UpdatePosition(this DlgMain self)
        {
            long instanceid = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(100);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            foreach (Scroll_Item_MainChatItem scrollItemMainChatItem in self.ScrollItemMainChatItems.Values)
            {
                if (scrollItemMainChatItem == null)
                {
                    continue;
                }

                if (scrollItemMainChatItem.uiTransform == null)
                {
                    continue;
                }

                scrollItemMainChatItem.UpdateHeight();
            }

            await timerComponent.WaitAsync(100);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            // 无效。。。
            self.View.E_MainChatItemsLoopVerticalScrollRect.verticalNormalizedPosition = 0f;
        }

        #endregion
        
        public static void OnUpdateHP(this DlgMain self, int sceneType, Unit defend, Unit attack, long hurtvalue)
        {
            // int unitType = defend.Type;
            // if (unitType == UnitType.Player && sceneType == SceneTypeEnum.TeamDungeon)
            // {
            //     self.UIMainTeam.OnUpdateHP(defend);
            // }
            // if (unitType == UnitType.Monster)
            // {
            //     self.UIMainHpBar.OnUpdateHP(defend);
            //     self.UIMainHpBar.OnUpdateHP(defend, attack, hurtvalue);
            // }
            // if (unitType == UnitType.Pet)
            // {
            //     self.UIRoleHead.OnUpdatePetHP(defend);
            // }
        }
        
        public static void BeginEnterScene(this DlgMain self, int lastScene)
        {
            self.View.ES_MainTeam.ResetUI();
            self.View.ES_MainSkill.ResetUI();
            // self.UIMainBuffComponent.ResetUI();
            // self.UIJoystickMoveComponent.ResetUI();

            // self.UIMapMini.BeginChangeScene(lastScene);
            // self.UISingingComponent.GameObject.SetActive(false);
            // self.UIMainHpBar.BeginEnterScene();
            // self.ZoneScene().GetComponent<SkillIndicatorComponent>().BeginEnterScene();
            // self.ZoneScene().GetComponent<LockTargetComponent>().BeginEnterScene();
            // self.ZoneScene().GetComponent<BattleMessageComponent>().CancelRideTargetUnit(0);
            // self.ZoneScene().GetComponent<BattleMessageComponent>().AttackSelfPlayer.Clear();
        }
    }
}