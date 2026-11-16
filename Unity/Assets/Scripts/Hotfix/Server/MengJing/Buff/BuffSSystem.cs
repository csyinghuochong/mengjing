using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (BuffS))]
    [FriendOf(typeof (BuffS))]
    public static partial class BuffSSystem
    {
        [EntitySystem]
        private static void Awake(this BuffS self)
        {
        }

        [EntitySystem]
        private static void Destroy(this BuffS self)
        {
        }

        public static void OnBaseBuffInit(this BuffS self, BuffData buffData, Unit theUnitFrom, Unit theUnitBelongto)
        {
            self.PassTime = 0;
            self.IsTrigger = false;
            self.BuffData = buffData;
            self.TheUnitFrom = theUnitFrom;
            self.TheUnitBelongto = theUnitBelongto;
            self.BuffState = BuffState.Running;
            self.BeginTime = TimeHelper.ServerNow();
            self.mSkillConf = SkillConfigCategory.Instance.Get(buffData.SkillId);
            self.mBuffConfig = SkillBuffConfigCategory.Instance.Get(buffData.BuffId);
            self.DelayTime = self.mBuffConfig.BuffDelayTime;
            self.BuffEndTime = GetBuffEndTime(buffData, self.mBuffConfig, theUnitFrom, theUnitBelongto, self.BeginTime);
            self.InterValTime = self.mBuffConfig.BuffLoopTime * 1000;
            self.InterValTimeBegin = TimeHelper.ServerNow();
            self.NowBuffValue = 0f;
        }

        /// <summary>
        /// 返回毫秒
        /// </summary>
        /// <param name="theUnitBelongto"></param>
        /// <param name="skillBuffConfig"></param>
        /// <returns></returns>
        public static int CheckBuffTime( Unit theUnitBelongto, SkillBuffConfig skillBuffConfig)
        {
            int buffTime = skillBuffConfig.BuffTime;
            if (skillBuffConfig.BuffType == 2 && skillBuffConfig.buffParameterType == 7)
            {
                //韧性缩短眩晕时间
                NumericComponentS numericComponent = theUnitBelongto.GetComponent<NumericComponentS>();
                float addResPro = numericComponent.GetAsFloat(NumericType.Now_Res);

                //最多抵抗一半
                if (addResPro >= 0.5f)
                {
                    addResPro = 0.5f;
                }

                buffTime = (int)((float)buffTime * (1f - addResPro));
            }

            return buffTime;
        }

        public static float GetTianfuProAdd(this BuffS self, int key)
        {
            return GetTianfuProAdd(self.TheUnitFrom, self.mBuffConfig.Id, key);
        }

        private static float GetTianfuProAdd(Unit from, int buffId, int key)
        {
            Dictionary<int, float> properties = from.GetComponent<SkillSetComponentS>()?.GetBuffPropertyAdd(buffId);
            return properties != null && properties.TryGetValue(key, out float value) ? value : 0f;
        }

        public static long GetBuffEndTime(BuffData buffData, SkillBuffConfig config, Unit from, Unit target, long now)
        {
            if (buffData.BuffEndTime > 0)
            {
                return buffData.BuffEndTime;
            }

            float talentDuration = GetTianfuProAdd(from, config.Id, (int)BuffAttributeEnum.AddBuffTime);
            return now + CheckBuffTime(target, config) + 1000 * (int)talentDuration;
        }

        public static SkillRuneBuffTarget GetRuneBuffTarget(SkillBuffConfig config)
        {
            if (config.BuffType == 2 && (1 << config.buffParameterType) == StateTypeEnum.Dizziness)
            {
                return SkillRuneBuffTarget.Dizziness;
            }

            if (config.BuffType == 1 && config.buffParameterType == NumericType.Extra_Buff_Speed_Mul && config.buffParameterValue < 0)
            {
                return SkillRuneBuffTarget.MoveSpeedSlow;
            }

            return SkillRuneBuffTarget.None;
        }

        public static void OnFinished(this BuffS self)
        {
            BuffHandlerS aaiHandler = BuffDispatcherComponentS.Instance.Get(self.mBuffConfig.BuffScript);
            aaiHandler.OnFinished(self);
        }

        public static void OnInit(this BuffS self, Unit from, Unit to, SkillS skillS)
        {
            if (self == null)
            {
                Console.WriteLine("BuffS self == null");
            }

            BuffHandlerS aaiHandler = BuffDispatcherComponentS.Instance.Get(self.mBuffConfig.BuffScript);
            
            if (aaiHandler == null)
            {
                Console.WriteLine($"aaiHandler == null:  {self.mBuffConfig.BuffScript}");
            }
            
            aaiHandler.OnInit(self, from, to, skillS);
        }

        public static void OnUpdate(this BuffS self)
        {
            BuffHandlerS aaiHandler = BuffDispatcherComponentS.Instance.Get(self.mBuffConfig.BuffScript);
            aaiHandler.OnUpdate(self);
        }
    }
}
