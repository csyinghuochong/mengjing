using System;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(Effect))]
    [FriendOf(typeof(Effect))]
    public static partial class EffectSystem
    {
        [EntitySystem]
        private static void Awake(this Effect self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.Effect self)
        {
            self.OnFinished();
        }
        
        public static void OnFinished(this Effect self)
        {
            self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.EffectPath, self.EffectObj);
            self.EffectState = BuffState.Finished;
            self.TheUnitBelongto = null;
            self.EffectObj = null;
            self.EffectPath = String.Empty;
            self.EffectEndTime = 0;
        }

        
        public static void OnInit(this Effect self, EffectData effectData, Unit theUnitBelongto)
        {
            self.EffectPath = string.Empty;
            self.EffectObj = null;
            self.EffectData = effectData;
            self.EffectState = BuffState.Running;
            self.TheUnitBelongto = theUnitBelongto;
            self.EffectConfig = EffectConfigCategory.Instance.Get(effectData.EffectId);
            self.EffectBeginTime = TimeHelper.ServerNow();
            self.EffectEndTime = TimeHelper.ServerNow() + self.EffectConfig.SkillEffectLiveTime;
            self.EffectAngle = -10000;
            self.OnUpdate();
        }

        public static void OnLoadGameObject(this Effect self, GameObject gameObject, long instanceId)
        {
            try
            {
                if (self.EffectState != BuffState.Running || instanceId != self.InstanceId)
                {
                    if (gameObject != null)
                    {
                        GameObject.DestroyImmediate(gameObject);
                    }

                    return;
                }
                
                if (self.EffectData.InstanceId == 0 || gameObject == null)
                {
                    self.EffectState = BuffState.Finished;
                }

                if (self.TheUnitBelongto == null || self.TheUnitBelongto.IsDisposed)
                {
                    self.EffectState = BuffState.Finished;
                }

                if (self.EffectState == BuffState.Finished)
                {
                    return;
                }

                self.EffectObj = gameObject;
                self.EffectObj.name = self.EffectConfig.EffectName;
                int skillParentID = self.EffectConfig.SkillParent;
                //显示特效大小。
                //if (this.EffectData.SkillId != 0)
                //{
                //    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(this.EffectData.SkillId);
                //    int rangeType = skillConfig.DamgeRangeType;       //技能范围类型
                //    float[] rangeValue = FunctionHelp.DoubleArrToFloatArr(skillConfig.DamgeRange);          //技能范围
                //    this.AddCollider(this.EffectObj, rangeType, rangeValue);            //添加客户端碰撞显示
                //}
                GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
                switch (skillParentID)
                {
                    //跟随玩家
                    case 0:
                        HeroTransformComponent heroTransformComponent = self.TheUnitBelongto.GetComponent<HeroTransformComponent>();
                        if (heroTransformComponent == null)
                        {
                            self.EffectState = BuffState.Finished;
                            return;
                        }

                        Transform tParent = heroTransformComponent.GetTranform(self.EffectConfig.SkillParentPosition);
                        if (tParent == null)
                        {
                            self.EffectState = BuffState.Finished;
                            return;
                        }

                        self.EffectObj.transform.SetParent(tParent);
                        self.EffectObj.transform.localPosition = Vector3.zero;
                        self.EffectObj.transform.localScale = Vector3.one;
                        float angle = self.EffectData.TargetAngle != 0 ? self.EffectData.TargetAngle : 0;// self.TheUnitBelongto.Rotation.eulerAngles.y
                        self.EffectObj.transform.localRotation = Quaternion.Euler(0, angle, 0);
                        break;
                    //不跟随玩家
                    case 1:
                        self.EffectObj.transform.SetParent(globalComponent.Unit);
                        if ( self.EffectAngle == -10000)
                        {
                            angle = self.EffectData.EffectAngle != 0 ? self.EffectData.EffectAngle : self.EffectData.TargetAngle;
                            self.EffectObj.transform.position = self.EffectData.EffectPosition;
                            self.EffectObj.transform.localRotation = Quaternion.Euler(0, angle, 0);
                        }
                        else
                        {
                            self.EffectObj.transform.position = self.EffectPosition;
                            self.EffectObj.transform.localRotation = Quaternion.Euler(0, self.EffectAngle, 0);
                        }
                        self.EffectObj.transform.localScale = Vector3.one;
                        break;
                    //实时跟随玩家位置,但是不跟随旋转
                    case 2:
                        self.EffectObj.transform.SetParent(globalComponent.Unit);
                        self.EffectObj.transform.position = self.TheUnitBelongto.Position;
                        self.EffectObj.transform.localScale = Vector3.one;
                        self.EffectObj.transform.localRotation = Quaternion.Euler(0, self.EffectData.TargetAngle, 0);
                        break;
                    //实时跟随位置,无指定绑点
                    case 3:
                        self.EffectObj.transform.SetParent(globalComponent.Unit);
                        self.EffectObj.transform.position = self.TheUnitBelongto.Position;
                        self.EffectObj.transform.localScale = Vector3.one;
                        self.EffectObj.transform.localRotation = Quaternion.Euler(0, self.EffectData.TargetAngle, 0);
                        break;
                    //闪电链特效
                    case 4:
                        Unit unitTarget = null;
                        ChainLightningComponent chainLightningComponent = self.AddComponent<ChainLightningComponent, GameObject>(self.EffectObj);
                        heroTransformComponent = self.TheUnitBelongto.GetComponent<HeroTransformComponent>();
                        if (heroTransformComponent == null)
                        {
                            self.EffectState = BuffState.Finished;
                            return;
                        }

                        chainLightningComponent.Start = heroTransformComponent.GetTranform(PosType.Center);
                        if (self.EffectData.TargetID != 0)
                        {
                            unitTarget = self.TheUnitBelongto.GetParent<UnitComponent>().Get(self.EffectData.TargetID);
                            if (unitTarget == null)
                            {
                                self.EffectState = BuffState.Finished;
                                return;
                            }

                            chainLightningComponent.UsePosition = false;
                            chainLightningComponent.End = unitTarget.GetComponent<HeroTransformComponent>().GetTranform(PosType.Center);
                            chainLightningComponent.OnUpdate();
                        }
                        else
                        {
                            chainLightningComponent.UsePosition = true;
                            chainLightningComponent.EndPosition = self.EffectData.EffectPosition;
                            chainLightningComponent.OnUpdate();
                        }

                        break;
                }

                self.EffectObj.SetActive(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 实例化特效
        /// </summary>
        public static void PlayEffect(this Effect self)
        {
            if (self.EffectData.InstanceId == 0)
            {
                return;
            }

            self.EffectPath = StringBuilderHelper.GetEffectPathByConfig(self.EffectConfig);
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.EffectPath, self.InstanceId, true,self.OnLoadGameObject);
        }

        public static void OnUpdate(this Effect self)
        {
            if (self.EffectState == BuffState.Finished)
            {
                return;
            }

            long serverTime = TimeHelper.ServerNow();
            float passTime = (serverTime - self.EffectBeginTime) * 0.001f;
            if (passTime < self.EffectConfig.SkillEffectDelayTime)
            {
                return;
            }

            if (string.IsNullOrEmpty(self.EffectPath))
            {
                self.PlayEffect();
            }

            if (serverTime > self.EffectEndTime)
            {
                self.EffectState = BuffState.Finished;
                return;
            }

            if (self.TheUnitBelongto == null || self.TheUnitBelongto.IsDisposed || self.EffectData.InstanceId == 0)
            {
                self.EffectState = BuffState.Finished;
                return;
            }

            int skillParentID = self.EffectConfig.SkillParent;
            if (skillParentID == 4) //闪电链
            {
                if (self.EffectData.TargetID != 0 && null == self.TheUnitBelongto.GetParent<UnitComponent>().Get(self.EffectData.TargetID))
                {
                    self.EffectState = BuffState.Finished;
                    return;
                }
            }

            if (self.EffectConfig.HideTime > 0 && self.EffectObj != null)
            {
                self.HideObjTime += Time.deltaTime;
                if (self.HideObjTime >= self.EffectConfig.HideTime)
                {
                    self.HideObjTime = 0;
                    self.EffectObj.SetActive(false);
                    self.EffectObj.SetActive(true);
                }
            }
        }


        /// <summary>
        /// 添加服务器的碰撞范围,显示作用
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="rangeType"></param>
        /// <param name="rangeValue"></param>
        public static void AddCollider(this Effect self, GameObject effect, int rangeType, float[] rangeValue)
        {
            //Log.Debug("实装碰撞体:" + self.EffectConfig.Id.ToString() + "rangeType :" + rangeType + "rangeValue:" + rangeValue);
            if (rangeType == 1 && effect.GetComponent<SphereCollider>() == null)
            {
                SphereCollider collider = effect.AddComponent<SphereCollider>();
                collider.radius = rangeValue[0];
                collider.isTrigger = true;
            }
            if (rangeType == 2 && effect.GetComponent<BoxCollider>() == null)
            {
                BoxCollider collider = effect.AddComponent<BoxCollider>();
                collider.center = new Vector3(0, 0, rangeValue[1] * 0.5f);
                collider.size = new Vector3(rangeValue[0], 1, rangeValue[1]);
                collider.isTrigger = true;
            }
        }

        /// <summary>
        /// 实时更新当前特效位置
        /// </summary>
        public static void UpdateEffectPosition(this Effect self, float3 vec3, float angle)
        {
            if (self.EffectObj == null)
            {
                self.EffectPosition = vec3;
                self.EffectAngle = angle;
                return;
            }
            if (angle != -1)
            {
                self.EffectObj.transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            self.EffectObj.transform.position = vec3;
        }
        
    }
}