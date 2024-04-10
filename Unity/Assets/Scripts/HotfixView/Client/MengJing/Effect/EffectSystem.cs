using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (Effect))]
    [FriendOf(typeof (Effect))]
    public static partial class EffectSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.Effect self)
        {
        }

        public  static void OnInit(this ET.Client.Effect self, EffectData effectData, Unit theUnitBelongto)
        {
            self.EffectPath = string.Empty;
            self.EffectObj = null;
            self.EffectData = effectData;
            self.EffectState = BuffState.Running;
            self.TheUnitBelongto = theUnitBelongto;
            self.EffectConfig = EffectConfigCategory.Instance.Get(effectData.EffectId);
            self.EffectData.EffectBeginTime = effectData.EffectBeginTime > 0? effectData.EffectBeginTime : TimeHelper.ServerNow();
            self.EffectEndTime = TimeHelper.ServerNow() + self.EffectConfig.SkillEffectLiveTime;

            self.OnUpdate();
        }

        public static void OnLoadGameObject(this ET.Client.Effect self, GameObject gameObject, long instanceId)
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

                self.EffectObj = gameObject;
                self.EffectObj.name = self.EffectConfig.EffectName;
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
                        float angle = self.EffectData.TargetAngle != 0? self.EffectData.TargetAngle : 0;// self.TheUnitBelongto.Rotation.eulerAngles.y
                        self.EffectObj.transform.localRotation = Quaternion.Euler(0, angle, 0);
                        break;
                    //不跟随玩家
                    case 1:
                        angle = self.EffectData.EffectAngle != 0? self.EffectData.EffectAngle : self.EffectData.TargetAngle;
                        self.EffectObj.transform.SetParent(globalComponent.Unit);
                        self.EffectObj.transform.position = self.EffectData.EffectPosition;
                        self.EffectObj.transform.localScale = Vector3.one;
                        self.EffectObj.transform.localRotation = Quaternion.Euler(0, angle, 0);
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

            string effectFileName = "";
            switch (self.EffectConfig.EffectType)
            {
                //技能特效
                case 1:
                    effectFileName = "SkillEffect/";
                    break;
                //受击特效
                case 2:
                    effectFileName = "SkillHitEffect/";
                    break;
                //技能特效
                case 3:
                    effectFileName = "SkillEffect/";
                    break;
            }

            string effectNamePath = effectFileName + self.EffectConfig.EffectName;
            self.EffectPath = StringBuilderHelper.GetEffetPath(effectNamePath);
            GameObjectPoolComponent.Instance.AddLoadQueue(self.EffectPath, self.InstanceId, self.OnLoadGameObject);
        }

        public static void OnUpdate(this Effect self)
        {
            if (self.EffectState == BuffState.Finished)
            {
                return;
            }

            long serverTime = TimeHelper.ServerNow();
            float passTime = (serverTime - self.EffectData.EffectBeginTime) * 0.001f;
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

        public static void OnFinished(this Effect self)
        {
            GameObjectPoolComponent.Instance.RecoverGameObject(self.EffectPath, self.EffectObj);
            self.EffectState = BuffState.Finished;
            self.EffectData.InstanceId = 0;
            self.TheUnitBelongto = null;
            self.EffectObj = null;
            self.EffectPath = String.Empty;
            self.EffectEndTime = 0;
        }
    }
}