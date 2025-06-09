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
            self.BattleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();

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

        public static void ResetUI(this ES_JoystickMove self, bool removeTime)
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

            self.MainUnit = null;

            if (removeTime)
            {
                self.IsDrag = false;
                self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            }
        }
        
        public static void InitMainHero(this ES_JoystickMove self)
        {
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.NumericComponent = self.MainUnit.GetComponent<NumericComponentC>();
        }

        
        public static void AfterEnterScene(this ES_JoystickMove self)
        {
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.NumericComponent = self.MainUnit.GetComponent<NumericComponentC>();
            self.BattleMessageComponent.TransferMap = false;
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
            self.IsDrag = true;
            
            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }
            
            self.lastSendTime = 0;
            self.direction = self.GetDirection(pdata);
            self.SendMove(self.direction);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.JoystickTimer);
            self.JoystickTimer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.JoystickTimer, self);

            //EventSystem.Instance.Publish(self.Root().CurrentScene(), new MoveStart() { Unit = unit });
            //unit.Rotation =  quaternion.Euler(0, math.radians(self.direction ), 0);
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
            angle = ( angle  - angle % 5 );
            return angle;
        }

        private static void Draging(this ES_JoystickMove self, PointerEventData pdata)
        {
            if (!self.IsDrag)
            {
                return;
            }
            
            self.direction = self.GetDirection(pdata);
        }

        public static void OnUpdate(this ES_JoystickMove self)
        {
            self.SendMove(self.direction);
        }

        //靠墙慢慢往前蹭
        public static void MoveSlowly(this ES_JoystickMove self, int direction)
        {
            Unit unit = self.MainUnit;
            unit.GetComponent<GameObjectComponent>().UpdateRotation(quaternion.Euler(0, math.radians(direction ), 0));
            
            float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            speed = Mathf.Max(speed, 4f);
            
            int speedRate = 60;  //移动速度 10是原始速度1/10 100是原始速度
            speed *= (speedRate * 0.01f);
            bool sendmove = false;
            for (int i = 0; i < 80; i++)    //左右80度范围寻找可以移动的点
            {
                unit.SpeedRate = speedRate;
                List<float3> pathfind = new List<float3>();
                quaternion rotation_1 = quaternion.Euler(0, math.radians(direction + i ), 0);
                self.CanMovePosition(unit, rotation_1, pathfind, 2, 0.1f, false);

                if (pathfind.Count < 2)
                {
                    pathfind.Clear();
                    quaternion rotation_2 = quaternion.Euler(0, math.radians(direction - i ), 0);
                    self.CanMovePosition(unit, rotation_2, pathfind, 2, 0.1f, false);
                }
                
                if (pathfind.Count >= 2)
                {
                    sendmove = true;
                    unit.MoveResultToAsync(pathfind, null , speedRate).Coroutine();
                    unit.GetComponent<MoveComponent>().MoveToAsync(pathfind, speed).Coroutine();
                    break;
                }
            }

            if (!sendmove)
            {
                EventSystem.Instance.Publish(self.Root().CurrentScene(), new MoveStart() { Unit = unit });
            }
        }

        private static void PathfindingComponentFind(this ES_JoystickMove self, Unit unit, quaternion rotation, float dis,  List<float3> pathfind)
        {
            float3 targetpos = unit.Position + math.forward(rotation) * dis;
            
            RaycastHit hit;
            Physics.Raycast(targetpos + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.MapLayer);
            if (hit.collider != null)
            {
                targetpos = hit.point;  
            }
            unit.GetComponent<ClientPathfindingComponent>().Find(unit.Position,  targetpos, pathfind);
        }

        private static void SendMove(this ES_JoystickMove self, int direction)
        {
            self.AttackComponent.RemoveTimer();

            if(self.BattleMessageComponent.TransferMap)
            {
                return;
            }
            long serverNow = TimeHelper.ServerNow();
            //自动攻击正在向怪物移动 这个时候不要频繁的打断。。
            if (serverNow - self.AttackComponent.MoveAttackTime < 200)
            {
                return;
            }
            long passTime = serverNow - self.lastSendTime;
            if (passTime  < 30 || (self.lastDirection == direction && passTime < self.checkTime))
            {
                return;
            }
                        
            Unit unit = self.MainUnit;
            quaternion rotation = quaternion.Euler(0, math.radians(direction), 0);
            List<float3> pathfind = new List<float3>();
            
            //self.CanMovePosition(unit, rotation, pathfind);
            self.PathfindingComponentFind( unit, rotation, 2f, pathfind );
            if (pathfind.Count < 2)
            {
                self.PathfindingComponentFind( unit, rotation, 1f, pathfind );
            }
            
            //unit.GetComponent<ClientPathfinding2Component>().Find(unit.Position + targetpos, pathfind);
            //unit.GetComponent<ET6PathfindingComponent>().Find(unit.Position,  targetpos, pathfind);
            if (pathfind.Count < 2)
            {
                //self.MoveSlowly(direction);
                return;
            }
            
            float3 newv3 = pathfind[pathfind.Count - 1];
            float distance = Vector3.Distance(newv3, unit.Position);
            float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            speed = Mathf.Max(speed, 4f);
            float needTime = distance / speed;
            self.checkTime =(long)(1000 * needTime) - 200;

            //GameObject.Find("Global/Target").transform.position = newv3;
            //Log.Debug($"MoveToAsync:  direction: {direction}    unitPosition:{unitPosition}  newv3:{newv3}  distance:{distance}  self.checkTime:{self.checkTime}");
            int errorCode = MoveHelper.IfCanMove(unit);
            if (errorCode == ErrorCode.ERR_CanNotMove_Rigidity)
            {
                SkillManagerComponentC skillManager = unit.GetComponent<SkillManagerComponentC>();
                if (skillManager.HaveSkillType(ConfigData.Skill_XuanZhuan_Attack_2))
                {
                    self.checkTime = 100;
                    self.lastSendTime = serverNow;
                    self.lastDirection = direction;
                    MoveHelper.RequestSkillXuanZhuan( self.Root(), direction ).Coroutine();
                    return;
                }
            }
            if (errorCode!= ErrorCode.ERR_Success)
            {
                if (errorCode == ErrorCode.ERR_CanNotMove_NetWait 
                    || errorCode == ErrorCode.ERR_CanNotMove_Rigidity
                    || errorCode == ErrorCode.ERR_CanNotMove_Speed)
                {
                    return ;
                }
                HintHelp.ShowErrorHint(unit.Root(), errorCode);
                  return;
            }

            EventSystem.Instance.Publish(self.Root(), new BeforeMove() { DataParamString = string.Empty });

            unit.MoveResultToAsync(pathfind, null, 100, serverNow ).Coroutine();
            unit.GetComponent<MoveComponent>().MoveToAsync(pathfind, speed).Coroutine();
            
            self.lastSendTime = serverNow;
            self.lastDirection = direction;
        }
        
        private static void ShowObstructName(this ES_JoystickMove self, GameObject hit)
        {
            //FlyTipComponent.Instance.ShowFlyTip($"阻挡物： {self.GetPath(hit)}");
            Log.Debug($"阻挡物： {self.GetPath(hit)}");
        }

        private static  string GetPath(this ES_JoystickMove self, GameObject obj)
        {
            if (obj.transform.parent == null)
            {
                // 如果是根节点，直接返回自己的名字
                return obj.name;
            }
            else
            {
                // 递归调用获取父节点路径，然后加上自己的名字
                return self.GetPath(obj.transform.parent.gameObject) + "/" + obj.name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unit"></param>
        /// <param name="rotation"></param>
        /// <param name="pathfind"></param>
        /// <param name="number"></param>
        /// <param name="dis"></param>
        /// <param name="showobs"></param>
        /// <returns></returns>
        private static float3 CanMovePosition(this ES_JoystickMove self, Unit unit, quaternion rotation,  List<float3> pathfind, int number = 30, float distance = 0.2f, bool showobs = true)
        {
            float3 targetPosi = unit.Position;
            for (int i = 0; i < number; i++)
            {
                targetPosi += math.forward(rotation) * ( distance);
                RaycastHit hit;
                Physics.Raycast(targetPosi + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.BuildingLayer);
                if (hit.collider != null)
                {
                    if (showobs)
                    {
                        self.ShowObstructName(hit.collider.gameObject);
                    }
                    break;
                }

                Physics.Raycast(targetPosi + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.ObstructLayer);
                if (hit.collider != null)
                {
                    if (showobs)
                    {                    
                        self.ShowObstructName(hit.collider.gameObject);
                    }
                    break;
                }

                Physics.Raycast(targetPosi + new float3(0f, 10f, 0f), Vector3.down, out hit, 100, self.MapLayer);
                if (hit.collider == null)
                {
                    break;
                }
                else
                {
                    if (Mathf.Abs(hit.point.y - targetPosi.y) > 0.4f)
                    {
                        break;
                    }
                    else
                    {
                        targetPosi = hit.point;
                        pathfind.Add(targetPosi);
                    }
                }
            }

            return targetPosi;
        }
        
        public static void ResetJoystick(this ES_JoystickMove self)
        {
            self.IsDrag = false;
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
            self.IsDrag = false;
            
            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }
            //EventSystem.Instance.Publish(self.Root().CurrentScene(), new MoveStop() { Unit = unit });
            
            long lastTimer = self.JoystickTimer;
            self.ResetJoystick();
            if (lastTimer == 0)
            {
                return;
            }
            
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
            {
                return;
            }
            
            if(self.BattleMessageComponent.TransferMap)
            {
                return;
            }
            
            EventSystem.Instance.Publish(self.Root().CurrentScene(), new MoveStop() { Unit = unit });
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            moveComponent.Stop(false);
            MoveHelper.StopResult(self.Root(), unit.Position);
        }
    }
}
