using System;
using System.Collections.Generic;

namespace ET.Server
{

    /// <summary>
    /// 持续伤害
    /// </summary>
    [Invoke(TimerInvokeType.RoleBullet7Timer)]
    public class RoleBullet7Timer: ATimer<RoleBullet7Componnet>
    {
        protected override void Run(RoleBullet7Componnet self)
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

    [FriendOf(typeof(RoleBullet7Componnet))]
    [EntitySystemOf(typeof(RoleBullet7Componnet))]
    public static partial class RoleBullet7ComponentSystem
    {
        
        [EntitySystem]
        private static void Awake(this RoleBullet7Componnet self)
        {
        }

        [EntitySystem]
        private static void Destroy(this RoleBullet7Componnet self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }


        public static void OnBaseBulletInit(this RoleBullet7Componnet self, SkillS skillS, long masterid)
        {
            self.PassTime = 0;
            self.Masterid = masterid;
            self.BuffState = BuffState.Running;
            self.SkillS = skillS;
            self.BeginTime = TimeHelper.ServerNow();
            self.DelayTime = (long)(1000 * skillS.SkillConf.SkillDelayTime);
            self.DamageRange = skillS.GetTianfuProAdd((int)SkillAttributeEnum.AddDamageRange) + (float)skillS.SkillConf.DamgeRange[0];
            self.BuffEndTime = 1000 * (int)skillS.GetTianfuProAdd((int)SkillAttributeEnum.AddSkillLiveTime) + skillS.SkillConf.SkillLiveTime +
                    TimeHelper.ServerNow();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.RoleBullet7Timer, self);
        }

        public static void OnUpdate(this RoleBullet7Componnet self)
        {
            Unit bullet = self.GetParent<Unit>();
            UnitComponent unitComponent = bullet.GetParent<UnitComponent>();
            long nowTime = TimeHelper.ServerNow();
            SkillS skillS = self.SkillS;
            if (bullet.IsDisposed || skillS == null || skillS.TheUnitFrom.IsDisposed || nowTime > self.BuffEndTime || skillS.IsFinished())
            {
                unitComponent.Remove(bullet.Id);
                self.BuffState = BuffState.Finished;
                return;
            }

            //获取当前全部的unit进行范围监测
            List<EntityRef<Unit>> units = unitComponent.GetAll();
            skillS.UpdateCheckPoint(bullet.Position);

            for (int i = units.Count - 1; i >= 0; i--)
            {
                Unit uu = units[i];

                if (uu.IsDisposed || uu.Id == bullet.Id || uu.Id == self.Masterid)
                {
                    continue;
                }

                if (!skillS.CheckShape(uu.Position))
                {
                    continue;
                }

                if (!uu.IsCanBeAttack())
                {
                    continue;
                }

                if (!skillS.HurtIds.Contains(uu.Id))
                {
                    skillS.HurtIds.Add(uu.Id);
                }

                if (!skillS.TheUnitFrom.IsCanAttackUnit(uu))
                {
                    continue;
                }

                if (!skillS.LastHurtTimes.ContainsKey(uu.Id))
                {
                    // 第一次伤害
                    skillS.LastHurtTimes.Add(uu.Id, nowTime);
                    skillS.OnCollisionUnit(uu);
                }

                if (skillS.SkillTriggerInvelTime > 0)
                {
                    // 间隔伤害
                    if (nowTime - skillS.LastHurtTimes[uu.Id] > skillS.SkillTriggerInvelTime)
                    {
                        skillS.OnCollisionUnit(uu);
                        skillS.LastHurtTimes[uu.Id] = nowTime;
                    }
                }
            }
        }

    }
}