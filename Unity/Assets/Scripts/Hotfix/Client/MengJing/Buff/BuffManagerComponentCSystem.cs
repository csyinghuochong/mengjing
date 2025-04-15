using System;
using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof(BuffManagerComponentC))]
    [FriendOf(typeof(BuffManagerComponentC))]
    public static partial class BuffManagerComponentCSystem
    {
        [Invoke(TimerInvokeType.BuffTimerC)]
        public class BuffTimer : ATimer<BuffManagerComponentC>
        {
            protected override void Run(BuffManagerComponentC self)
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
        private static void Awake(this BuffManagerComponentC self)
        {
            self.t_Buffs.Clear();
            self.m_Buffs.Clear();
        }

        [EntitySystem]
        private static void Destroy(this BuffManagerComponentC self)
        {
            self.OnDispose();
        }

        public static void OnDispose(this BuffManagerComponentC self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.m_Buffs.Clear();
        }

        //DeadNoRemove 0移除   1 不移除
        public static void OnDead(this BuffManagerComponentC self)
        {
            for (int i = self.m_Buffs.Count - 1; i >= 0; i--)
            {
                BuffC buffHandler = self.m_Buffs[i];
                if (buffHandler.mSkillBuffConf.DeadNoRemove == 1)
                {
                    continue;
                }

                buffHandler.BuffState = BuffState.Finished;
            }
        }

        public static void Check(this BuffManagerComponentC self)
        {
            int buffcnt = self.m_Buffs.Count;
            for (int i = buffcnt - 1; i >= 0; i--)
            {
                BuffC buffHandler = self.m_Buffs[i];

                BuffHandlerC aaiHandler = BuffDispatcherComponentC.Instance.Get(buffHandler.mSkillBuffConf.BuffScript);
                aaiHandler.OnUpdate(buffHandler);

                if (buffHandler.BuffState == BuffState.Finished)
                {
                    aaiHandler.OnFinished(buffHandler);
                    buffHandler.Clear();
                    buffHandler.Dispose();
                    self.m_Buffs.RemoveAt(i);
                }
            }

            if (self.m_Buffs.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }

        #region 添加，移除Buff

        public static void InitData(this BuffManagerComponentC self, UnitInfo unitInfo)
        {
            self.t_Buffs = unitInfo.Buffs;
        }
        
        public static void InitBuff(this BuffManagerComponentC self)
        {
            List<KeyValuePair> buffs = self.t_Buffs;
            long timeNow = TimeHelper.ClientNow();
            for (int i = 0; i < buffs.Count; i++)
            {
                long buffEndTime = long.Parse(buffs[i].Value2);
                if (buffEndTime <= timeNow)
                {
                    continue;
                }

                // $"{buffHandler.BuffData.SkillId}_{buffHandler.BuffData.Spellcaster}"
                BuffData buffData = new BuffData();
                string[] buffinfo = buffs[i].Value.Split('_');
                buffData.TargetAngle = 0;
                buffData.BuffId = buffs[i].KeyId;
                buffData.SkillId = int.Parse(buffinfo[0]);
                buffData.Spellcaster = buffinfo[1];
                buffData.BuffEndTime = buffEndTime;
                self.BuffFactory(buffData);
            }

            self.t_Buffs.Clear();
        }
        
        public static void BuffFactory(this BuffManagerComponentC self, BuffData buffData)
        {
            SkillBuffConfig skillBuffConfig = SkillBuffConfigCategory.Instance.Get(buffData.BuffId);
            string BuffClassScript = skillBuffConfig.BuffScript;
            BuffC buffHandler = self.AddChild<BuffC>();
            self.m_Buffs.Add(buffHandler); //给buff目标添加buff管理器

            BuffHandlerC aaiHandler = BuffDispatcherComponentC.Instance.Get(skillBuffConfig.BuffScript);
            aaiHandler.OnInit(buffHandler, buffData, self.GetParent<Unit>());

            if (self.Timer == 0)
            {
                //self.Timer = TimerComponent.Instance.NewFrameTimer(TimerType.BuffTimer, self);
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.BuffTimerC, self);
            }
        }

        /// <summary>
        /// 移除Buff(下一帧才真正移除)
        /// </summary>
        /// <param name="buffId">要移除的BuffId</param>
        public static void RemoveBuff(this BuffManagerComponentC self, long buffId)
        {
            int buffcnt = self.m_Buffs.Count;
            for (int i = buffcnt - 1; i >= 0; i--)
            {
                BuffC buffHandler = self.m_Buffs[i];
                if (buffHandler.mSkillBuffConf == null)
                {
                    continue;
                }

                if (buffHandler.BuffData.BuffId == buffId)
                {
                    buffHandler.BuffState = BuffState.Finished;
                }
            }
        }

        #endregion

        #region 获取BuffSystem

        public static int GetBuffNumber(this BuffManagerComponentC self, int buffId)
        {
            int number = 0;
            int buffcnt = self.m_Buffs.Count;
            for (int i = buffcnt - 1; i >= 0; i--)
            {
                if (self.m_Buffs[i].BuffData.BuffId == buffId)
                {
                    number++;
                }
            }

            return number;
        }

        public static int GetBuffSourceNumber(this BuffManagerComponentC self, long formId, int buffId)
        {
            int buffnumber = 0;
            int bufflist = self.m_Buffs.Count;

            for (int i = bufflist - 1; i >= 0; i--)
            {
                if (self.m_Buffs[i].BuffData.BuffId != buffId)
                {
                    continue;
                }
                if (formId != 0 && formId != self.m_Buffs[i].BuffData.UnitIdFrom)
                {
                    continue;
                }
                buffnumber++;
            }
            return buffnumber;
        }
        
        /// <summary>
        /// 通过标识ID获得Buff
        /// </summary>
        /// <param name="buffId">BuffData的标识ID</param>
        public static List<BuffC> GetBuffByConfigId(this BuffManagerComponentC self, int buffId)
        {
            List<BuffC> list = new List<BuffC>();
            int buffcnt = self.m_Buffs.Count;
            for (int i = buffcnt - 1; i >= 0; i--)
            {
                if (self.m_Buffs[i].mSkillBuffConf == null)
                {
                    continue;
                }

                if (self.m_Buffs[i].mSkillBuffConf.Id == buffId)
                {
                    list.Add(self.m_Buffs[i]);
                }
            }

            return list;
        }

        #endregion
    }
}