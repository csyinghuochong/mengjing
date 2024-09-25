using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [Invoke(TimerInvokeType.JoystickTimer)]
    public class JoystickTimer : ATimer<ES_JoystickMove>
    {
        protected override void Run(ES_JoystickMove self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [EntitySystemOf(typeof(ES_JoystickMove))]
    [FriendOfAttribute(typeof(ES_JoystickMove))]
    public static partial class ES_JoystickMoveSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JoystickMove self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Move(pdata as PointerEventData); });
            self.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.E_YaoGanDiMoveEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.PointerDown_Fix(pdata as PointerEventData); });
            self.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.E_YaoGanDiFixEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            self.AttackComponent = self.Root().GetComponent<AttackComponent>();

            self.ObstructLayer = 1 << LayerMask.NameToLayer(LayerEnum.Obstruct.ToString());
            self.BuildingLayer = 1 << LayerMask.NameToLayer(LayerEnum.Building.ToString());
            self.MapLayer = 1 << LayerMask.NameToLayer(LayerEnum.Map.ToString());
            self.ResetJoystick();
            self.AfterEnterScene();
        }

        [EntitySystem]
        private static void Destroy(this ES_JoystickMove self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            self.DestroyWidget();
        }

        public static void ResetUI(this ES_JoystickMove self)
        {
            self.SetAlpha(0.3f);
            if (self.OperateMode == 0)
            {
                self.E_CenterShowImage.transform.localPosition = Vector3.zero;
                self.E_ThumbImage.transform.localPosition = Vector3.zero;
            }
            else
            {
                self.E_CenterShowImage.gameObject.SetActive(false);
                self.E_ThumbImage.gameObject.SetActive(false);
                self.E_YaoGanDiFixEventTrigger.gameObject.SetActive(false);
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
        }

        public static void AfterEnterScene(this ES_JoystickMove self)
        {
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.NumericComponent = self.MainUnit.GetComponent<NumericComponentC>();
        }

        public static void UpdateOperateMode(this ES_JoystickMove self, int operateMode)
        {
            self.OperateMode = operateMode;

            // 0固定 1移动
            self.E_YaoGanDiFixImage.gameObject.SetActive(operateMode == 0);
            self.E_YaoGanDiMoveImage.gameObject.SetActive(operateMode == 1);

            self.E_CenterShowImage.transform.SetParent(operateMode == 0 ? self.E_YaoGanDiFixImage.transform
                    : self.E_YaoGanDiMoveImage.transform);
            self.E_CenterShowImage.transform.SetParent(operateMode == 0 ? self.E_YaoGanDiFixImage.transform
                    : self.E_YaoGanDiMoveImage.transform);

            self.E_CenterShowImage.gameObject.SetActive(self.OperateMode == 0);
            self.E_ThumbImage.gameObject.SetActive(self.OperateMode == 0);

            self.SetAlpha(0.3f);

            self.E_CenterShowImage.transform.localPosition = Vector3.zero;
            self.E_ThumbImage.transform.localPosition = Vector3.zero;
        }

        private static void SetAlpha(this ES_JoystickMove self, float value)
        {
            Color color_1 = new Color(1f, 1f, 1f);
            color_1.a = value;
            self.E_CenterShowImage.color = color_1;
            self.E_ThumbImage.color = color_1;
        }

        private static void PointerDown_Move(this ES_JoystickMove self, PointerEventData pdata)
        {
            RectTransform canvas = self.GetYaoGanDi().GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, self.UICamera, out self.OldPoint);
            self.SetAlpha(1f);
            if (self.OperateMode == 0)
            {
                self.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.E_CenterShowImage.transform.localPosition = Vector3.zero;
                self.E_ThumbImage.transform.localPosition = Vector3.zero;
                self.OldPoint = Vector2.zero;
            }
            else
            {
                self.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.E_CenterShowImage.gameObject.SetActive(true);
                self.E_ThumbImage.gameObject.SetActive(true);
                self.E_CenterShowImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
                self.E_ThumbImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
            }
        }

        private static void PointerDown_Fix(this ES_JoystickMove self, PointerEventData pdata)
        {
            RectTransform canvas = self.GetYaoGanDi().GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, self.UICamera, out self.OldPoint);
            self.SetAlpha(1f);
            if (self.OperateMode == 0)
            {
                self.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.E_CenterShowImage.transform.localPosition = Vector3.zero;
                self.E_ThumbImage.transform.localPosition = Vector3.zero;
                self.OldPoint = Vector2.zero;
            }
            else
            {
                self.E_YaoGanDiFixImage.gameObject.SetActive(true);
                self.E_CenterShowImage.gameObject.SetActive(true);
                self.E_ThumbImage.gameObject.SetActive(true);
                self.E_CenterShowImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
                self.E_ThumbImage.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            self.BeginDrag(pdata);
        }

        private static void BeginDrag(this ES_JoystickMove self, PointerEventData pdata)
        {
            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            if (SettingData.ShowFindPath)
            {
                CommonHelp.ClearPathFindLog();
                SettingData.FindPathInit = unit.Position;
                SettingData.FindPathList.Clear();
            }
            
            self.lastSendTime = 0;
            self.direction = self.GetDirection(pdata);
            self.SendMove(self.direction);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            self.JoystickTimer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.JoystickTimer, self);
            
            EventSystem.Instance.Publish(self.Root().CurrentScene(), new MoveStart() { Unit = unit });
            unit.Rotation =  quaternion.Euler(0, math.radians(self.direction ), 0);
        }

        private static GameObject GetYaoGanDi(this ES_JoystickMove self)
        {
            return self.OperateMode == 0 ? self.E_YaoGanDiFixImage.gameObject : self.E_YaoGanDiMoveImage.gameObject;
        }

        private static int GetDirection(this ES_JoystickMove self, PointerEventData pdata)
        {
            RectTransform canvas = self.GetYaoGanDi().GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, self.UICamera, out self.NewPoint);

            Vector3 vector3 = new(self.NewPoint.x, self.NewPoint.y, 0f);
            float maxDistance = Vector2.Distance(self.OldPoint, self.NewPoint);
            if (maxDistance < self.Distance)
            {
                self.E_ThumbImage.transform.localPosition = vector3;
            }
            else
            {
                self.NewPoint = self.OldPoint + (self.NewPoint - self.OldPoint).normalized * self.Distance;
                vector3.x = self.NewPoint.x;
                vector3.y = self.NewPoint.y;
                self.E_ThumbImage.transform.localPosition = vector3;
            }

            Vector2 indicator = self.NewPoint - self.OldPoint;
            int angle = 90 - (int)(Mathf.Atan2(indicator.y, indicator.x) * Mathf.Rad2Deg) + (int)self.MainCamera.transform.eulerAngles.y;
            angle = ( angle  - angle % 20 );
            return angle;
        }

        private static void Draging(this ES_JoystickMove self, PointerEventData pdata)
        {
            self.direction = self.GetDirection(pdata);
        }

        public static void OnUpdate(this ES_JoystickMove self)
        {
            self.SendMove(self.direction);
        }

        private static void SendMove(this ES_JoystickMove self, int direction)
        {
            long clientNow = TimeHelper.ClientNow();
            
            if ( clientNow - self.lastSendTime < 30)
            {
                return;
            }
            
            if (clientNow - self.AttackComponent.MoveAttackTime < 200)
            {
                return;
            }

            if (self.lastDirection == direction && clientNow - self.lastSendTime < self.checkTime)
            {
                return;
            }
          
            Unit unit = self.MainUnit;
            quaternion rotation = quaternion.Euler(0, math.radians(direction), 0);
            ;// Quaternion.Euler(0, direction, 0);

            List<float3> pathfind = new List<float3>();
            float3 newv3 = self.CanMovePosition(unit, rotation, pathfind);
            if (pathfind.Count < 2)
            {
                unit.Rotation =  quaternion.Euler(0, math.radians(direction ), 0);
                return;
            }

            float3 initpos = pathfind[0];
            List<float3> pathfind_2 = new List<float3>();
            pathfind_2.Add(initpos);
            
            
            ////////-------------------------------------
            // int distance_init = 0;
            // for (int i = 1; i < pathfind.Count; i++)
            // {
            //     float distance_cur = math.distance(pathfind[i] , pathfind[distance_init]);
            //     if (distance_cur < 0.5f)
            //     {
            //         continue;
            //     }
            //     else
            //     {
            //         distance_init = i;
            //         pathfind_2.Add(pathfind[i]);
            //     }
            // }
            //
            // distance_init = 0;
            // for (int i = 1; i <pathfind_2.Count;)
            // {
            //     if (math.abs(pathfind_2[i].y - pathfind_2[i-1].y) < 0.02f)
            //     {
            //         pathfind_2.RemoveAt(i);
            //     }
            //     else
            //     {
            //         i++;
            //     }
            // }
            /////////--------------------------------
            for (int i = 1; i <pathfind.Count; i++)
            {
                //if (!pathfind[i].y.Equals(pathfind[i-1].y))
                if (math.abs(pathfind[i].y - pathfind[i-1].y) > 0.05f)
                {
                    pathfind_2.Add(pathfind[i]);
                }
            }

            if (pathfind_2.Count > 2)
            {
                int distance_init = 0;
                for (int i = 1; i <pathfind_2.Count;  )
                {
                    float distance_cur = math.distance(pathfind_2[i] , pathfind_2[distance_init]);
                    if (distance_cur < 0.5f)
                    {
                        pathfind_2.RemoveAt(i);
                    }
                    else
                    {
                        distance_init = i;
                        i++;
                    }
                }
            }
            /////////--------------------------------
            
            
            if (pathfind_2.Count < 2)
            {
                pathfind_2.Add(pathfind[pathfind.Count - 1]);
            }

            newv3 = pathfind_2[pathfind_2.Count - 1];
            float distance = Vector3.Distance(newv3, unit.Position);
            float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            speed = Mathf.Max(speed, 4f);
            float needTime = distance / speed;
            self.checkTime =(long)(1000 * needTime) - 200;

            //GameObject.Find("Global/Target").transform.position = newv3;
            //Log.Debug($"MoveToAsync:  direction: {direction}    unitPosition:{unitPosition}  newv3:{newv3}  distance:{distance}  self.checkTime:{self.checkTime}");
            if (SettingData.ShowFindPath)
            {
                Transform gameObject = GameObject.Find("Global/FindPath/10").transform;
                gameObject.localPosition = newv3;
            }

            int errorCode = MoveHelper.IfCanMove(unit);
            if (errorCode!= ErrorCode.ERR_Success)
            {
                  HintHelp.ShowErrorHint(unit.Root(), errorCode);
                  return;
            }

            EventSystem.Instance.Publish(self.Root(), new BeforeMove() { DataParamString = string.Empty });

            if (SettingData.MoveMode == 0)
            {
                unit.MoveToAsync( newv3,  null,self.checkTime, direction,  self.lastDirection ).Coroutine();
            }
            else
            {
                unit.MoveResultToAsync(pathfind_2, null, self.checkTime, direction,  self.lastDirection ).Coroutine();
                unit.GetComponent<MoveComponent>().MoveToAsync(pathfind_2, speed).Coroutine();
            }
            
            self.lastSendTime = clientNow;
            self.lastDirection = direction;
        }

        private static void ShowObstructTip(this ES_JoystickMove self, int monsterId)
        {
            if (Time.time - self.LastShowTip < 1f)
            {
                return;
            }

            self.LastShowTip = Time.time;
            string monsterName = MonsterConfigCategory.Instance.Get(monsterId).MonsterName;
            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("请先消灭{0}", monsterName));
            }
        }

        private static float CanMoveDistance(this ES_JoystickMove self, Unit unit, Quaternion rotation)
        {
            float intveral = 1f; //每次寻的长度
            int distance = 2;
            int maxnumber = 5; //最多寻多少次
            for (int i = distance; i <= maxnumber; i++)
            {
                Vector3 unitPosi = unit.Position;
                Vector3 target = unitPosi + rotation * Vector3.forward * i * intveral;
                RaycastHit hit;

                distance = i;
                Physics.Raycast(target + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, self.BuildingLayer);
                if (hit.collider != null)
                {
                    break;
                }
            }

            return distance * intveral;
        }

        private static float3 CanMovePosition(this ES_JoystickMove self, Unit unit, quaternion rotation,  List<float3> pathfind)
        {
            float3 targetPosi = unit.Position;
            for (int i = 0; i < 30; i++)
            {
                targetPosi = targetPosi + math.forward(rotation) * ( 0.2f);
                RaycastHit hit;

                Physics.Raycast(targetPosi + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.BuildingLayer);
                if (hit.collider != null)
                {
                    break;
                }

                Physics.Raycast(targetPosi + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.MapLayer);
                if (hit.collider == null)
                {
                    // if (i == 0)
                    // {
                    //     targetpositon = target;
                    // }
                    break;
                }
                else
                {
                    targetPosi = hit.point;
                }
                
                pathfind.Add(targetPosi);
            }

            return targetPosi;
        }
        
        private static float3 CanMovePosition_2(this ES_JoystickMove self, Unit unit, quaternion rotation,  List<float3> pathfind)
        {
            float3 targetPosi = unit.Position;
            for (int i = 0; i < 10; i++)
            {
                targetPosi = targetPosi + math.forward(rotation) * ( 0.5f);
                RaycastHit hit;

                Physics.Raycast(targetPosi + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.BuildingLayer);
                if (hit.collider != null)
                {
                    break;
                }

                Physics.Raycast(targetPosi + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.MapLayer);
                if (hit.collider == null)
                {
                    // if (i == 0)
                    // {
                    //     targetpositon = target;
                    // }
                    break;
                }
                else
                {
                    targetPosi = hit.point;
                }
                
                pathfind.Add(targetPosi);
            }

            return targetPosi;
        }
        
        private static int CheckObstruct(this ES_JoystickMove self, Unit unit, Vector3 target)
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

        private static void ResetJoystick(this ES_JoystickMove self)
        {
            self.SetAlpha(0.3f);
            if (self.OperateMode == 0)
            {
                self.E_CenterShowImage.transform.localPosition = Vector3.zero;
                self.E_ThumbImage.transform.localPosition = Vector3.zero;
            }
            else
            {
                self.E_CenterShowImage.gameObject.SetActive(false);
                self.E_ThumbImage.gameObject.SetActive(false);
                self.E_YaoGanDiFixImage.gameObject.SetActive(false);
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
        }

        private static void EndDrag(this ES_JoystickMove self, PointerEventData pdata)
        {
            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }
            EventSystem.Instance.Publish(self.Root().CurrentScene(), new MoveStop() { Unit = unit });
            
            long lastTimer = self.JoystickTimer;
            self.ResetJoystick();
            if (lastTimer == 0)
            {
                return;
            }

            if (SettingData.ShowFindPath)
            {
                CommonHelp.WritePathFindLog();
            }
            
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
            {
                return;
            }
            
            if (SettingData.MoveMode == 0)
            {
                MoveHelper.Stop(self.Root());
            }
            else
            {
                MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
                moveComponent.Stop(false);
                MoveHelper.StopResult(self.Root(), unit.Position);
            }
        }
    }
}
