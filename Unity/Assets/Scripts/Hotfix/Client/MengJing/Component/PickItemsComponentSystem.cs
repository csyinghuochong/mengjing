using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof(PickItemsComponent))]
    [FriendOf(typeof(PickItemsComponent))]
    public static partial class PickItemsComponentSystem
    {
        [Invoke(TimerInvokeType.PickItemTimer)]
        public class PickItemTimer : ATimer<PickItemsComponent>
        {
            protected override void Run(PickItemsComponent self)
            {
                self.SendPickImmediately();
            }
        }

        [EntitySystem]
        private static void Awake(this PickItemsComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this PickItemsComponent self)
        {
            self.UnitDrops.Clear();
        }

        public static void SendPick(this PickItemsComponent self, Unit unitDrop)
        {
            self.UnitDrops.Add(unitDrop);
            if (self.LastSendTime > 0 && TimeInfo.Instance.ServerNow() - self.LastSendTime < 200)
            {
                self.CheckSyneTimer();
            }
            else
            {
                self.SendPickImmediately();
            }
        }

        private static void CheckSyneTimer(this PickItemsComponent self)
        {
            if (self.SyncTime < TimeInfo.Instance.ServerNow())
            {
                if (self.SyncTimerId != 0)
                {
                    self.Root().GetComponent<TimerComponent>().Remove(ref self.SyncTimerId);
                }

                self.SyncTime = TimeInfo.Instance.ServerNow() + 200;
                self.SyncTimerId = self.Root().GetComponent<TimerComponent>().NewOnceTimer(self.SyncTime, TimerInvokeType.PickItemTimer, self);
            }
        }

        private static void SendPickImmediately(this PickItemsComponent self)
        {
            if (self.UnitDrops.Count == 0)
            {
                return;
            }
            
            self.LastSendTime = TimeInfo.Instance.ServerNow();

            List<Unit> unitDrops = new List<Unit>();
            unitDrops.AddRange(self.UnitDrops);
            self.UnitDrops.Clear();

            MapHelper.SendPickItem(self.Root(), unitDrops).Coroutine();
        }
    }
}