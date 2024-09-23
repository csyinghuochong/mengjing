using System;

namespace ET.Server
{
    [Invoke(TimerInvokeType.ReviveTimer)]
    public class ReviveTimer : ATimer<ReviveTimeComponent>
    {
        protected override void Run(ReviveTimeComponent self)
        {
            try
            {
                Unit unit = self.GetParent<Unit>();
                if (unit.IsDisposed)
                {
                    return;
                }

                unit.GetComponent<HeroDataComponentS>().OnRevive();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(ReviveTimeComponent))]
    [EntitySystemOf(typeof(ReviveTimeComponent))]
    public static partial class ReviveTimeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ReviveTimeComponent self, long aliveTime)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(aliveTime, TimerInvokeType.ReviveTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this ReviveTimeComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }
    }
}