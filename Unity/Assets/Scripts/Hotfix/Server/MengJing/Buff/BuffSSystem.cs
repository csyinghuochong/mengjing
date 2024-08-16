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
            self.BuffEndTime = CheckBuffTime(theUnitBelongto, self.mBuffConfig) +
                    1000 * (int)self.GetTianfuProAdd((int)BuffAttributeEnum.AddBuffTime) + TimeHelper.ServerNow();
            self.BuffEndTime = buffData.BuffEndTime > 0? buffData.BuffEndTime : self.BuffEndTime;
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
            SkillSetComponentS skillSetComponent = self.TheUnitFrom.GetComponent<SkillSetComponentS>();
            if (skillSetComponent == null)
                return 0f;

            float addValue = 0f;
            Dictionary<int, float> keyValuePairs = skillSetComponent.GetBuffPropertyAdd(self.mBuffConfig.Id);
            if (keyValuePairs == null)
                return addValue;
            keyValuePairs.TryGetValue(key, out addValue);
            return addValue;
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