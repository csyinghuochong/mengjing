using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    public enum LayerEnum
    {
        Drop,
        NPC,
        Terrain,
        Monster,
        Player,
        Map,
        RenderTexture,
        Box,
        Obstruct,
        Building,
    }

    [EntitySystemOf(typeof(OperaComponent))]
    [FriendOf(typeof(OperaComponent))]
    public static partial class OperaComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OperaComponent self)
        {
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            self.MapMask = (1 << LayerMask.NameToLayer(LayerEnum.Terrain.ToString())) | (1 << LayerMask.NameToLayer(LayerEnum.Map.ToString()));
            self.NpcMask = 1 << LayerMask.NameToLayer(LayerEnum.NPC.ToString());
            self.BoxMask = 1 << LayerMask.NameToLayer(LayerEnum.Box.ToString());
            self.PlayerMask = 1 << LayerMask.NameToLayer(LayerEnum.Player.ToString());
            self.MonsterMask = 1 << LayerMask.NameToLayer(LayerEnum.Monster.ToString());
            self.BuildingMask = 1 << LayerMask.NameToLayer(LayerEnum.Building.ToString());

            Init init = GameObject.Find("Global").GetComponent<Init>();
            self.EditorMode = init.EditorMode;
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
        }

        [EntitySystem]
        private static void Update(this OperaComponent self)
        {
            if (InputHelper.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                self.OnGetMouseButtonDown_0();
            }

            if (InputHelper.GetMouseButtonDown(1))
            {
                self.OnGetMouseButtonDown_1();
                //self.TestClientPathfinding2Component();
            }

            if (InputHelper.GetKeyDown((int)KeyCode.S))
            {
                // 按 S键 测试屏幕震动，或技能 烈地击
                //self.Root().CurrentScene().GetComponent<MJCameraComponent>().SetShakeCamera(ShakeCameraType.Type_1, 0.3f);
            }

            if (InputHelper.GetKeyDown((int)KeyCode.R))
            {
                // CodeLoader.Instance.Reload();
                // return;
            }

            if (InputHelper.GetKeyDown((int)KeyCode.T))
            {
                //C2M_TransferMap c2MTransferMap = new();
                //self.Root().GetComponent<ClientSenderCompnent>().Call(c2MTransferMap).Coroutine();
            }

            if (InputHelper.GetKeyDown(257))
            {
                self.OnGetKeyHandler(257);
            }

            if (InputHelper.GetKey(119))
            {
                self.OnGetKeyHandler(119);
            }

            if (InputHelper.GetKey(97))
            {
                self.OnGetKeyHandler(97);
            }

            if (InputHelper.GetKey(115))
            {
                self.OnGetKeyHandler(115);
            }

            if (InputHelper.GetKey(100))
            {
                self.OnGetKeyHandler(100);
            }
        }

        /// <summary>
        /// 测试客户端寻路1
        /// </summary>
        /// <param name="self"></param>
        public static void TestClientPathfindingComponent(this OperaComponent self)
        {
            Ray ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, self.MapMask))
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

                List<float3> points = new List<float3>();
                unit.GetComponent<ClientPathfindingComponent>().Find(unit.Position, hit.point, points);

                if (points.Count < 2)
                {
                    return;
                }
                float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
                unit.GetComponent<MoveComponent>().MoveToAsync(points, speed, 100, (int)speed).Coroutine();
            }
        }

        /// <summary>
        /// 测试客户端寻路2
        /// </summary>
        /// <param name="self"></param>
        public static void TestClientPathfinding2Component(this OperaComponent self)
        {
            Ray ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, self.MapMask))
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

                List<float3> points = new List<float3>();
                unit.GetComponent<ClientPathfinding2Component>().Find(hit.point, points);

                if (points.Count < 2)
                {
                    return;
                }

                float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
                unit.GetComponent<MoveComponent>().MoveToAsync(points, speed, 100, (int)speed).Coroutine();
            }
        }

        public static void UpdateClickMode(this OperaComponent self)
        {
            self.ClickMode = self.Root().GetComponent<UserInfoComponentC>().GetGameSettingValue(GameSettingEnum.Click) == "1";
        }

        public static void OnGetKeyHandler(this OperaComponent self, int keyCode)
        {
            if (!self.ClickMode)
            {
                return;
            }

            if (Time.time - self.LastSendTime < 0.1f)
            {
                return;
            }

            if (keyCode == 257 && self.EditorMode)
            {
                // AccountInfoComponent accountInfoComponent = self.ZoneScene().GetComponent<AccountInfoComponent>();
                // if (!GMHelp.GmAccount.Contains(accountInfoComponent.Account))
                // {
                //     return;
                // }
                // 测试技能
                List<int> skillids = new List<int>() { 2200140 }; //40000011 40000012
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                long targetId = self.Root().GetComponent<LockTargetComponent>().LastLockId;

                Quaternion quaternion = unit.Rotation;
                unit.GetComponent<SkillManagerComponentC>().SendUseSkill(skillids[RandomHelper.RandomNumber(0, skillids.Count)],
                    0, Mathf.FloorToInt(quaternion.eulerAngles.y), targetId, 0).Coroutine();
                self.LastSendTime = Time.time;
            }

            Vector3 dir = Vector3.zero;
            if (keyCode == 119)
            {
                dir.z = 1f;
            }

            if (keyCode == 97)
            {
                dir.x = -1f;
            }

            if (keyCode == 115)
            {
                dir.z = -1f;
            }

            if (keyCode == 100)
            {
                dir.x = 1f;
            }

            if (dir != Vector3.zero)
            {      
                self.Root().GetComponent<AttackComponent>().RemoveTimer();
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
                {
                    return;
                }

                Vector3 unitPos = self.MainUnit.Position;
                Vector3 target = dir * 2f + unitPos;
                self.MoveToPosition(target, true).Coroutine();
                self.LastSendTime = Time.time;
                return;
            }
        }

        public static void OnGetMouseButtonDown_1(this OperaComponent self)
        {
            if (self.EditorMode)
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
            }
            else
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    return;
                }
            }

            if (!self.EditorMode && self.ClickMode && self.CheckMove())
            {
                return;
            }
        }

        public static void OnGetMouseButtonDown_0(this OperaComponent self)
        {
            if (self.EditorMode)
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
            }
            else
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    return;
                }
            }

            if (self.IsPointerOverGameObject(Input.mousePosition)
                || self.CheckBox()
                || self.CheckNpc()
                || self.CheckPlayer()
                || self.CheckMonster()
                || self.CheckBuilding())
            {
                return;
            }

            if (!self.EditorMode && self.ClickMode && self.CheckMove())
            {
                return;
            }
        }

        public static bool CheckMove(this OperaComponent self)
        {
            Ray ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, self.MapMask))
            {
                self.MoveToPosition(hit.point, true).Coroutine();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckBox(this OperaComponent self)
        {
            RaycastHit Hit;
            Ray Ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out Hit, 100, self.BoxMask);
            if (!hit)
                return false;
            try
            {
                long chestId = long.Parse(Hit.collider.gameObject.name);
                self.OnClickChest(chestId);
                return true;
            }
            catch (Exception ex)
            {
                Log.Debug("无效的宝箱: " + ex.ToString());
            }

            return false;
        }

        public static void OnClickChest(this OperaComponent self, long boxid)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Unit box = UnitHelper.GetUnitFromZoneSceneByID(self.Root(), boxid);

            if (PositionHelper.Distance2D(unit.Position, box.Position) < 2)
            {
                self.OnOpenBox(boxid).Coroutine();
                return;
            }

            self.MoveToChest(boxid).Coroutine();
        }

        public static async ETTask MoveToChest(this OperaComponent self, long boxid)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
                return;
            Unit box = UnitHelper.GetUnitFromZoneSceneByID(self.Root(), boxid);

            Vector3 position = box.Position;
            Vector3 unitPos = unit.Position;
            Vector3 dir = (unitPos - position).normalized;
            position += dir * 2f;

            int ret = await self.MoveToPosition(position, true);
            if (ret != 0)
            {
                return;
            }

            self.OnOpenBox(boxid).Coroutine();
        }

        public static async ETTask OnOpenBox(this OperaComponent self, long boxid)
        {
            Unit box = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(boxid);
            if (box == null)
            {
                return;
            }

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            if (box.ConfigId == 83000101 || box.ConfigId == 83000102)
            {
                await uiComponent.ShowWindowAsync(WindowID.WindowID_JiaYuanMenu);
                uiComponent.GetDlgLogic<DlgJiaYuanMenu>().OnUpdateRubsh(box);
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(box.ConfigId);
            if (monsterConfig.Parameter != null && monsterConfig.Parameter.Length > 0 && monsterConfig.Parameter[0] > 0)
            {
                await uiComponent.ShowWindowAsync(WindowID.WindowID_OpenChest);
                uiComponent.GetDlgLogic<DlgOpenChest>().UpdateInfo(box);
            }
            else
            {
                uiComponent.GetDlgLogic<DlgMain>().View.ES_OpenBox.OnOpenBox(box);
            }

            await ETTask.CompletedTask;
        }

        public static bool CheckPlayer(this OperaComponent self)
        {
            RaycastHit Hit;
            Ray Ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out Hit, 100, self.PlayerMask);
            if (!hit)
                return false;
            string obname = Hit.collider.gameObject.name;
            try
            {
                long unitid = long.Parse(obname);
                self.OnClickUnitItem(unitid).Coroutine();
                return true;
            }
            catch (Exception ex)
            {
                Log.Debug("无效的player: " + ex.ToString());
            }

            return false;
        }

        public static async ETTask OnClickUnitItem(this OperaComponent self, long unitid)
        {
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            if (unitid == playerInfoComponent.CurrentRoleId)
            {
                return;
            }

            Unit unit = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(unitid);
            if (unit == null)
            {
                return;
            }

            if (unit.Type == UnitType.Stall)
            {
                self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_PaiMaiStall);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMaiStall>().OnUpdateUI(unit);
            }

            if (unit.Type == UnitType.Player)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WatchMenu);
                DlgWatchMenu dlgWatchMenu = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatchMenu>();
                UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
                await dlgWatchMenu.OnUpdateUI_1(MenuEnumType.Main, unit.Id, unitInfoComponent.UnitName, true);
            }
        }

        public static bool CheckMonster(this OperaComponent self)
        {
            RaycastHit Hit;
            Ray Ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out Hit, 100, self.MonsterMask);
            if (!hit)
                return false;
            string obname = Hit.collider.gameObject.name;
            try
            {
                long unitid = long.Parse(obname);
                self.OnClickMonsterItem(unitid).Coroutine();
                return true;
            }
            catch (Exception ex)
            {
                Log.Debug("无效的Monster: " + ex.ToString());
            }

            return false;
        }

        public static bool CheckBuilding(this OperaComponent self)
        {
            RaycastHit Hit;
            Ray Ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out Hit, 100, self.BuildingMask);
            if (!hit)
            {
                return false;
            }

            if (Hit.collider == null || Hit.collider.gameObject == null)
            {
                return false;
            }

            GameObject colliderobj = Hit.collider.gameObject;
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (colliderobj.name.Contains("C_PlankPlanterLow_1x1m") && mapComponent.MapType == MapTypeEnum.JiaYuan)
            {
                GameObject gameObject = colliderobj.transform.parent.gameObject;
                string[] namelist = gameObject.name.Split('_');
                int index = int.Parse(namelist[namelist.Length - 1]);

                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>()?.OnClickPlanItem(index).Coroutine();
                return true;
            }

            return false;
        }

        public static async ETTask OnClickMonsterItem(this OperaComponent self, long unitid)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            Unit unitmonster = self.Scene().GetComponent<UnitComponent>().Get(unitid);
            if (unitmonster == null)
            {
                return;
            }

            if (unitmonster.Type == UnitType.Monster && unitmonster.GetMasterId() == UnitHelper.GetMyUnitId(self.Root()))
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonProperty);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonProperty>().InitPropertyShow(unitmonster).Coroutine();
                return;
            }

            if (unitmonster.Type == UnitType.Monster)
            {
                self.Root().GetComponent<LockTargetComponent>().LockTargetUnitId(unitid);
                return;
            }

            if (unitmonster.Type == UnitType.Pet && mapComponent.MapType == MapTypeEnum.JiaYuan)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>().OnClickPet(unitid).Coroutine();
                return;
            }

            if (unitmonster.Type == UnitType.Pasture)
            {
                self.Root().GetComponent<LockTargetComponent>().LockTargetUnitId(unitid);
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanMenu);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMenu>().OnUpdatePasture(unitmonster);
                return;
            }
        }

        public static bool CheckNpc(this OperaComponent self)
        {
            RaycastHit Hit;
            Ray Ray = self.MainCamera.ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out Hit, 100, self.NpcMask);
            if (!hit)
                return false;
            string obname = Hit.collider.gameObject.name;
            try
            {
                int npcid = int.Parse(obname);
                self.OnClickNpc(npcid).Coroutine();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"无效的npc collider: {obname}" + ex.ToString());
            }

            return false;
        }

        public static async ETTask OnClickNpc(this OperaComponent self, int npcid, string operatetype = "0")
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            System.Numerics.Vector3 unitPosi = new(unit.Position.x, unit.Position.y, unit.Position.z);
            Unit npc = TaskHelper.GetNpcByConfigId(self.Root(), unitPosi, npcid);

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            Vector3 newTarget = new(npcConfig.Position[0] * 0.01f, npcConfig.Position[1] * 0.01f, npcConfig.Position[2] * 0.01f);
            if (npcConfig.MovePosition.Length == 0 && npc != null)
            {
                if (npc.GetComponent<AnimatorComponent>() != null)
                {
                    npc.GetComponent<AnimatorComponent>().Play(MotionType.SelectNpc);
                }

                if (npc.GetComponent<AnimationComponent>() != null)
                {
                    npc.GetComponent<AnimationComponent>().Play(MotionType.SelectNpc);
                }
            }

            if (npc != null)
            {
                self.Root().GetComponent<LockTargetComponent>().OnLockNpc(npc);
                newTarget = npc.Position;
            }

            self.NpcId = npcid;
            newTarget.y = unit.Position.y;
            Vector3 unitPos = unit.Position;
            Vector3 dir = (unitPos - newTarget).normalized;
            self.UnitStartPosition = unit.Position;

            if (PositionHelper.Distance2D(unit.Position, newTarget) <= TaskHelper.NpcSpeakDistance + 1f)
            {
                self.OnArriveToNpc();
                self.OnUnitToSpeak(newTarget);
                return;
            }

            newTarget += dir * TaskHelper.NpcSpeakDistance;
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
            {
                return;
            }

            if (ConfigData.TurtleList.Contains(npcid))
            {
                return;
            }

            int ret = await self.MoveToPosition(newTarget, false, operatetype);
            if (ret != 0)
            {
                return;
            }

            if (PositionHelper.Distance2D(unit.Position, newTarget) > TaskHelper.NpcSpeakDistance + 0.2f)
            {
                return;
            }

            self.OnArriveToNpc();
            self.OnUnitToSpeak(newTarget);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MapBig);
        }

        public static void OnArriveToNpc(this OperaComponent self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.JiaYuan)
            {
                JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
                UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                if (!jiaYuanComponent.IsMyJiaYuan(userInfo.UserId))
                {
                    return;
                }
            }

            int functionId = NpcConfigCategory.Instance.Get(self.NpcId).NpcType;
            if (self.NpcId == 40000003)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "神秘之门", "是否前往神秘之门？", () =>
                {
                    int sceneId = self.Root().GetComponent<MapComponent>().SceneId;
                    int chapterid = DungeonConfigCategory.Instance.DungeonToChapter[sceneId];
                    int mysterDungeonid = DungeonSectionConfigCategory.Instance.GetMysteryDungeon(chapterid);
                    EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, mysterDungeonid, 0, "0").Coroutine();
                }, null).Coroutine();
            }
            else if (self.NpcId == 40000004)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "返回副本", LanguageComponent.Instance.LoadLocalization("是否返回副本!"),
                    () =>
                    {
                        int sceneid = self.Root().GetComponent<BattleMessageComponent>().LastDungeonId;
                        if (sceneid == 0)
                        {
                            EnterMapHelper.RequestQuitFuben(self.Root());
                        }
                        else
                        {
                            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, sceneid, 0, "0").Coroutine();
                        }
                    },
                    null).Coroutine();
            }
            else if (functionId < 100)
            {
                self.OpenNpcTaskUI(self.NpcId).Coroutine();
            }
            else
            {
                FunctionUI.OpenFunctionUI(self.Root(), self.NpcId, functionId);
            }
        }

        public static async ETTask OpenNpcTaskUI(this OperaComponent self, int npcid)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TaskGet);
            DlgTaskGet dlgTaskGet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTaskGet>();
            dlgTaskGet.InitData(npcid);
        }

        public static void OnUnitToSpeak(this OperaComponent self, Vector3 vector3)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmNpcSpeak);
            unit.Rotation = Quaternion.LookRotation(vector3 - self.UnitStartPosition);
            unit.GetComponent<StateComponentC>().SetNetWaitEndTime(TimeHelper.ClientNow() + 200);
        }

        public static int CheckObstruct(this OperaComponent self, Vector3 start, Vector3 target)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.TeamDungeon)
            {
                return 0;
            }

            Vector3 dir = (target - start).normalized;
            while (true)
            {
                RaycastHit hit;
                if (Vector3.Distance(start, target) < 1f)
                {
                    break;
                }

                start = start + (1f * dir);
                int mapMask = (1 << LayerMask.NameToLayer(LayerEnum.Obstruct.ToString()));
                Physics.Raycast(start + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, mapMask);

                if (hit.collider != null)
                {
                    return int.Parse(hit.collider.gameObject.name);
                }
            }

            return 0;
        }

        public static async ETTask<int> MoveToPosition(this OperaComponent self, Vector3 position, bool yanGan = false, string operatetype = "0")
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int obstruct = self.CheckObstruct(unit.Position, position);
            if (obstruct != 0)
            {
                string monsterName = MonsterConfigCategory.Instance.Get(obstruct).MonsterName;
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("请先消灭{0}", monsterName));
                }

                return -1;
            }

            int errorCode = MoveHelper.IfCanMove(unit);
            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(unit.Root(), errorCode);
                return errorCode;
            }

            EventSystem.Instance.Publish(self.Root(), new BeforeMove() { DataParamString = operatetype });
            int ret = await unit.MoveToAsync(position, null, operatetype == "1");
            return ret;
        }

        /// <summary>
        /// 检测是否点击UI
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        public static bool IsPointerOverGameObject(this OperaComponent self, Vector2 mousePosition)
        {
            //创建一个点击事件
            PointerEventData eventData = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
            eventData.position = mousePosition;
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            //向点击位置发射一条射线，检测是否点击UI
            UnityEngine.EventSystems.EventSystem.current.RaycastAll(eventData, raycastResults);
            if (raycastResults.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}