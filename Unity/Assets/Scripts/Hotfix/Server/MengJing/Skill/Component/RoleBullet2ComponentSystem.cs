using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [Invoke(TimerInvokeType.RoleBullet2Timer)]
    public class RoleBullet2Timer : ATimer<RoleBullet2Componnet>
    {
        protected override void Run(RoleBullet2Componnet self)
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

    [FriendOf(typeof(RoleBullet2Componnet))]
    [EntitySystemOf(typeof(RoleBullet2Componnet))]
    public static partial class RoleBullet2ComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RoleBullet2Componnet self)
        {
        }

        [EntitySystem]
        private static void Destroy(this RoleBullet2Componnet self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnBaseBulletInit(this RoleBullet2Componnet self, SkillS skillS, long masterid)
        {
            self.PassTime = 0;
            self.MasterId = masterid;
            self.BuffState = BuffState.Running;
            self.SkillS = skillS;
            Unit unit = self.GetParent<Unit>();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            self.BeginTime = numericComponent.GetAsLong(NumericType.StartTime);
            self.DelayTime = (long)(1000 * skillS.SkillConf.SkillDelayTime);
            self.DamageRange = skillS.GetTianfuProAdd((int)SkillAttributeEnum.AddDamageRange) +
                    (float)skillS.SkillConf.DamgeRange[0];
            self.BuffEndTime = 1000 * (int)skillS.GetTianfuProAdd((int)SkillAttributeEnum.AddSkillLiveTime) +
                    skillS.SkillConf.SkillLiveTime + TimeHelper.ServerNow();
            self.StartAngle = numericComponent.GetAsInt(NumericType.StartAngle);
            self.TheUnitBelongto = unit.GetParent<UnitComponent>().Get(masterid);
            self.Radius = (float)skillS.SkillConf.SkillRangeSize;
            self.StartPosition = unit.Position;
            self.InterValTimeSum = 0;

            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.RoleBullet2Timer, self);
        }

        public static void OnUpdate(this RoleBullet2Componnet self)
        {
            self.PassTime = TimeHelper.ServerNow() - self.BeginTime;

            Unit unit = self.GetParent<Unit>();
            Unit theUnitBelongto = self.TheUnitBelongto;
            SkillS skillS = self.SkillS;
            if (unit.IsDisposed || skillS == null || theUnitBelongto.IsDisposed || unit.Scene() == null ||
                TimeHelper.ServerNow() > self.BuffEndTime)
            {
                unit.GetParent<UnitComponent>().Remove(unit.Id);
                self.BuffState = BuffState.Finished;
                //移除unit
                return;
            }

            self.Angle = (self.PassTime * 0.001f) * (float)skillS.SkillConf.SkillMoveSpeed + self.StartAngle;
            if (self.Angle >= (self.InterValTimeSum + 1) * 360)
            {
                self.Angle %= 360;
                self.HurtIds.Clear();
                self.InterValTimeSum++;
            }

            float3 sourcePoint = theUnitBelongto != null ? theUnitBelongto.Position : self.StartPosition;
            quaternion rotation = quaternion.Euler(0, math.radians(self.Angle), 0);
            unit.Position = sourcePoint + math.forward(math.normalize(rotation)).normalize() * self.Radius;

            List<EntityRef<Unit>> units = unit.GetParent<UnitComponent>().GetAll();
            for (int i = units.Count - 1; i >= 0; i--)
            {
                Unit uu = units[i];
                //不对自己造成伤害和同一个目标不造成2次伤害
                if (uu.IsDisposed || uu.Id == unit.Id || uu.Id == self.MasterId || skillS.IsFinished())
                {
                    continue;
                }

                if (self.HurtIds.Contains(uu.Id))
                {
                    continue;
                }

                //检测目标是否在技能范围
                float dic = math.distance(unit.Position, uu.Position);
                if (dic > self.DamageRange)
                {
                    continue;
                }

                if (!uu.IsCanBeAttack())
                {
                    continue;
                }

                self.HurtIds.Add(uu.Id);
                skillS.OnCollisionUnit(uu);
            }
        }
    }
}