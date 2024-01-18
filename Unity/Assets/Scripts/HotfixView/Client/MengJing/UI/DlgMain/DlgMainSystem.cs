using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgMain))]
    public static class DlgMainSystem
    {
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

        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.E_ShrinkButton.AddListener(self.OnShrinkButton);
            self.View.E_RoseEquipButton.AddListener(self.OnRoseEquipButton);
            self.View.E_PetButton.AddListener(self.OnPetButton);
            self.View.E_RoseSkillButton.AddListener(self.OnRoseSkillButton);
            self.View.E_TaskButton.AddListener(self.OnTaskButton);
            self.View.E_FriendButton.AddListener(self.OnFriendButton);
            self.View.E_ChengJiuButton.AddListener(self.OnChengJiuButton);
            self.View.E_AdventureButton.AddListener(self.OnAdventureButton);
            self.View.E_PetFormationButton.AddListener(self.OnPetFormationButton);

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
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();

            self.ObstructLayer = 1 << LayerMask.NameToLayer(LayerEnum.Obstruct.ToString());
            self.BuildingLayer = 1 << LayerMask.NameToLayer(LayerEnum.Building.ToString());
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
            self.ResetUI();
            self.AfterEnterScene();
        }

        private static void OnShrinkButton(this DlgMain self)
        {
            bool isShow = !self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf;
            self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(isShow);
        }

        private static void OnRoseEquipButton(this DlgMain self)
        {
            Log.Debug("打开背包界面！！！");
        }

        private static void OnPetButton(this DlgMain self)
        {
            Log.Debug("打开宠物界面！！！");
        }

        private static void OnRoseSkillButton(this DlgMain self)
        {
            Log.Debug("打开技能界面！！！");
        }

        private static void OnTaskButton(this DlgMain self)
        {
            Log.Debug("打开任务界面！！！");
        }

        private static void OnFriendButton(this DlgMain self)
        {
            Log.Debug("打开社交界面！！！");
        }

        private static void OnChengJiuButton(this DlgMain self)
        {
            Log.Debug("打开成就界面！！！");
        }

        private static void OnAdventureButton(this DlgMain self)
        {
            Log.Debug("进入冒险！！！");
        }

        private static void OnPetFormationButton(this DlgMain self)
        {
            Log.Debug("进入宠物探险！！！");
        }

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
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
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
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.JoystickTimer, self);
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

        private static void OnMainHeroMove(this DlgMain self)
        {
            // Unit unit = self.MainUnit;
            // Vector3 newv3 = unit.Position + unit.Rotation * Vector3.forward * 3f;
            // int obstruct = self.CheckObstruct(unit, newv3);
            // if (obstruct == 0)
            // {
            //     return;
            // }
            //
            // if (unit.GetComponent<MoveComponent>().IsArrived())
            // {
            //     return;
            // }
            //
            // self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_Stop());
        }

        private static void SendMove(this DlgMain self, int direction)
        {
            // long clientNow = TimeHelper.ClientNow();
            //
            // if (clientNow - self.lastSendTime < 30)
            // {
            //     return;
            // }
            //
            // if (clientNow - self.AttackComponent.MoveAttackTime < 200)
            // {
            //     return;
            // }
            //
            // if (self.lastDirection == direction && clientNow - self.lastSendTime < self.checkTime)
            // {
            //     return;
            // }
            //
            // Unit unit = self.MainUnit;
            // Quaternion rotation = Quaternion.Euler(0, direction, 0);
            // float distance = self.CanMoveDistance(unit, rotation);
            // distance = Mathf.Max(distance, 2f);
            // float speed = self.NumericComponent.GetAsFloat(NumericType.Now_Speed);
            // speed = Mathf.Max(speed, 4f);
            // float needTime = distance / speed;
            // self.checkTime = (int)(1000 * needTime) - 200;
            //
            // //Debug.Log("checkTime..." + distance / speed + " distance:" + distance + " speed:" + speed + " checkTime:" + self.checkTime);
            // //移动速度最低发送间隔
            //
            // //检测光墙
            // int obstruct = self.CheckObstruct(unit, unit.Position + rotation * Vector3.forward * 2f);
            // if (obstruct != 0)
            // {
            //     unit.GetComponent<StateComponent>().ObstructStatus = 1;
            //     self.ShowObstructTip(obstruct);
            //     return;
            // }
            //
            // EventType.DataUpdate.Instance.DataType = DataType.BeforeMove;
            // EventType.DataUpdate.Instance.DataParamString = string.Empty;
            // Game.EventSystem.PublishClass(EventType.DataUpdate.Instance);
            // Vector3 newv3 = unit.Position + rotation * Vector3.forward * distance;
            //
            // //MapHelper.LogMoveInfo($"移动发送请求: {TimeHelper.ServerNow()}");
            // unit.MoveByYaoGan(newv3, direction, distance, null).Coroutine();
            // self.lastSendTime = clientNow;
            // self.lastDirection = direction;
        }

        private static void ShowObstructTip(this DlgMain self, int monsterId)
        {
            // if (Time.time - self.LastShowTip < 1f)
            // {
            //     return;
            // }
            //
            // self.LastShowTip = Time.time;
            // string monsterName = MonsterConfigCategory.Instance.Get(monsterId).MonsterName;
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
            // RaycastHit hit;
            // Physics.Raycast(target + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, self.ObstructLayer);
            // if (hit.collider == null)
            // {
            //     return 0;
            // }
            //
            // int monsterid = int.Parse(hit.collider.gameObject.name);
            // List<Unit> units = UnitHelper.GetUnitList(unit.DomainScene(), UnitType.Monster);
            // for (int i = 0; i < units.Count; i++)
            // {
            //     if (units[i].ConfigId == monsterid)
            //     {
            //         return monsterid;
            //     }
            // }

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

        private static void ResetUI(this DlgMain self)
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

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        private static void ShowUI(this DlgMain self)
        {
        }

        private static void AfterEnterScene(this DlgMain self)
        {
            // self.MainUnit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // self.NumericComponent = self.MainUnit.GetComponent<NumericComponent>();
        }

        private static void EndDrag(this DlgMain self, PointerEventData pdata)
        {
            long lastTimer = self.Timer;
            self.ResetUI();
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
            // self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_Stop());
        }

        private static void EndDrag_Old(this DlgMain self, PointerEventData pdata)
        {
            if (!self.View.E_YaoGanDiFixImage.gameObject.activeSelf)
            {
                return;
            }

            self.ResetUI();
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
    }
}