using System;
using System.Collections.Generic;


namespace ET.Client
{
    
    /// <summary>
    /// 持续伤害
    /// </summary>
    [Invoke(TimerInvokeType.RoleBullet7TimerC)]
    public class RoleBullet7TimerC : ATimer<RoleBullet7Componnet>
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
        private static void Awake(this ET.Client.RoleBullet7Componnet self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.RoleBullet7Componnet self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }
        
        public static void OnBaseBulletInit(this RoleBullet7Componnet self,  long masterid)
        {
            self.PassTime = 0;
            self.Masterid = masterid;
            self.BuffState = BuffState.Running;
            self.BeginTime = TimeHelper.ServerNow();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.RoleBullet7TimerC, self);
            self.TargetUnit = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(masterid);
        }

        public static void OnUpdate(this RoleBullet7Componnet self)
        {
            if (self.TargetUnit != null)
            {
                self.GetParent<Unit>().Position = self.TargetUnit.Position;
            }
        }
    }
}