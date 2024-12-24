using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    /// <summary>
    /// 伤害一次
    /// </summary>
    [EntitySystemOf(typeof (RoleBullet1Componet))]
    [FriendOf(typeof (RoleBullet1Componet))]
    public static partial class RoleBullet1ComponentSystem
    {
        
        [Invoke(TimerInvokeType.RoleBullet1Timer)]
        public class RoleBullet1Timer: ATimer<RoleBullet1Componet>
        {
            protected override void Run(RoleBullet1Componet self)
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
        
        [EntitySystem]
        private static void Awake(this RoleBullet1Componet self)
        {
        }

        [EntitySystem]
        private static void Destroy(this RoleBullet1Componet self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        public static void OnBaseBulletInit(this RoleBullet1Componet self, SkillS skillHandler, long masterid)
        {
            self.PassTime = 0;
            self.Masterid = masterid;
            self.BuffState = BuffState.Running;
            self.SkillS = skillHandler;
            self.BeginTime = TimeHelper.ServerNow();
            self.DelayTime = (long)(1000 * skillHandler.SkillConf.SkillDelayTime);
            self.DamageRange = skillHandler.GetTianfuProAdd((int)SkillAttributeEnum.AddDamageRange) + (float)skillHandler.SkillConf.DamgeRange[0];
            self.BuffEndTime = 1000 * (int)skillHandler.GetTianfuProAdd((int)SkillAttributeEnum.AddSkillLiveTime) +
                    skillHandler.SkillConf.SkillLiveTime + TimeHelper.ServerNow();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.RoleBullet1Timer, self);
        }

        public static void OnUpdate(this RoleBullet1Componet self)
        {
            self.PassTime = TimeHelper.ServerNow() - self.BeginTime;
            //if (self.PassTime <= self.DelayTime)
            //{
            //    return;
            //}

            Unit unit = self.GetParent<Unit>();
            SkillS skillS = self.SkillS;
            if (unit.IsDisposed || skillS == null || skillS.TheUnitFrom.IsDisposed || TimeHelper.ServerNow() > self.BuffEndTime || skillS.IsFinished())
            {
                //移除Unity
                unit.GetParent<UnitComponent>().Remove(unit.Id);
                self.BuffState = BuffState.Finished;
                return;
            }

            //获取当前全部的unit进行范围监测
            List<EntityRef<Unit>> units = unit.GetParent<UnitComponent>().GetAll();
            skillS.UpdateCheckPoint(unit.Position);

            //Log.Debug($"子弹位置： x: {unit.Position.x}  z: {unit.Position.z}");
            for (int i = units.Count - 1; i >= 0; i--)
            {
                Unit uu = units[i];

                if (uu.IsDisposed || uu.Id == unit.Id || uu.Id == self.Masterid)
                {
                    continue;
                }

                if (skillS.IfHaveHurtId(uu.Id))
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

                //监测到对应碰撞体触发伤害
                skillS.OnAddHurtIds(uu.Id);
                skillS.OnCollisionUnit(uu);
            }
        }
    }
}