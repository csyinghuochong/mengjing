using System;
using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof (EffectViewComponent))]
    [FriendOf(typeof (EffectViewComponent))]
    public static partial class EffectViewComponentSytstem
    {
        
        [Invoke(TimerInvokeType.Effectimer)]
        public class BuffTimer: ATimer<EffectViewComponent>
        {
            protected override void Run(EffectViewComponent self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
                
        [EntitySystem]
        private static void Awake(this EffectViewComponent self)
        {
            self.Effects = new List<Effect>();
            self.InitEffect();
        }

        [EntitySystem]
        private static void Destroy(this EffectViewComponent self)
        {
            self.OnDispose();
        }

        public static void OnDispose(this EffectViewComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        public static void RemoveEffectType(this EffectViewComponent self, int effectTypeEnum)
        {
            for (int i = self.Effects.Count - 1; i >= 0; i--)
            {
                if (self.Effects[i].EffectData.EffectTypeEnum == effectTypeEnum)
                {
                    self.Effects[i].EffectState = BuffState.Finished;
                }
            }
        }

        public static void RemoveEffectId(this EffectViewComponent self, long instanceId)
        {
            for (int i = self.Effects.Count - 1; i >= 0; i--)
            {
                if (self.Effects[i].EffectData.InstanceId == instanceId)
                {
                    self.Effects[i].EffectState = BuffState.Finished;
                }
            }
        }

        public static Effect GetEffect(this EffectViewComponent self, long instanceId)
        {
            for (int i = self.Effects.Count - 1; i >= 0; i--)
            {
                if (self.Effects[i].EffectData.InstanceId == instanceId)
                {
                    return self.Effects[i];
                }
            }

            return null;
        }

        public static void UpdatePositon(this EffectViewComponent self)
        {
            for (int i = self.Effects.Count - 1; i >= 0; i--)
            {
                Effect aEffectHandler = self.Effects[i];
                if (aEffectHandler.EffectData.InstanceId == 0)
                {
                    continue;
                }

                if (aEffectHandler.EffectConfig.SkillParent != 2 && aEffectHandler.EffectConfig.SkillParent != 3)
                {
                    continue;
                }

                aEffectHandler.UpdateEffectPosition(self.GetParent<Unit>().Position, -1);
            }
        }

        public static void Check(this EffectViewComponent self)
        {
            for (int i = self.Effects.Count - 1; i >= 0; i--)
            {
                Effect aEffectHandler = self.Effects[i];
                if (aEffectHandler.EffectState == BuffState.Finished)
                {
                    aEffectHandler.Dispose();
                    self.Effects.RemoveAt(i);
                    continue;
                }

                aEffectHandler.OnUpdate();
            }

            if (self.Effects.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }

        public static void InitEffect(this EffectViewComponent self)
        {
            BuffManagerComponentC buffManager = self.GetParent<Unit>().GetComponent<BuffManagerComponentC>();
            if (buffManager == null)
            {
                return;
            }

            List<BuffC> buffList = buffManager.m_Buffs;
            for (int i = 0; i < buffList.Count; i++)
            {
                BuffC aBuffHandler = buffList[i];
                if (self.GetEffect(aBuffHandler.EffectInstanceId) != null)
                {
                    continue;
                }

                if (aBuffHandler.mSkillConf == null || aBuffHandler.EffectData.InstanceId == 0)
                {
                    continue;
                }

                int skillParentID = aBuffHandler.mEffectConf.SkillParent;
                if (skillParentID == 0 || skillParentID == 2 || skillParentID == 3)
                {
                    self.EffectFactory(aBuffHandler.EffectData);
                }
            }
        }

        public static void RemoveSameBuffEffect(this EffectViewComponent self, EffectData effectData)
        {
            if (effectData.EffectTypeEnum != EffectTypeEnum.BuffEffect)
            {
                return;
            }



            for(int i = 0; i < self.Effects.Count; i++)
            {
                Effect effect = self.Effects[i];
                
                if (effect.EffectData.EffectTypeEnum != EffectTypeEnum.BuffEffect)
                {
                    continue;
                }

                if (effect.EffectData.EffectId == effectData.EffectId)
                {
                    effect.EffectState = BuffState.Finished;
                }
            }
        }

        public static Effect EffectFactory(this EffectViewComponent self, EffectData effectData)
        {
            Unit unit = self.GetParent<Unit>();
            
            self.RemoveSameBuffEffect(effectData);

            Effect resultEffect = self.AddChild<Effect>(true);
            resultEffect.OnInit(effectData, unit);
            self.Effects.Add(resultEffect);

            if (self.Timer == 0)
            {
                self.Timer =  self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.Effectimer, self);
            }

            return resultEffect;
        }
    }
}