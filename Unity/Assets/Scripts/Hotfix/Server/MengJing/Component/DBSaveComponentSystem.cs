using System;

namespace ET.Server
{

    [EntitySystemOf((typeof(DBSaveComponent)))]
    [FriendOf((typeof(DBSaveComponent)))]
    public static partial class DBSaveComponentSystem
    {

        [Invoke(TimerInvokeType.DBSaveTimer)]
        public class DBSaveTimer : ATimer<DBSaveComponent>
        {
            protected override void Run(DBSaveComponent self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"session idle checker timer error: {self.Id}\n{e}");
                }
            }
        }


        [EntitySystem]
        private static void Awake(this ET.Server.DBSaveComponent self)
        {

        }

        public static void SetNoFindPath(this ET.Server.DBSaveComponent self)
        {


        }

        public static void Activeted(this DBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.DBSaveTimer, self);
        }


        public static void Check(this DBSaveComponent self)
        {
            UnitCacheHelper.AddOrUpdateUnitAllCache(self.GetParent<Unit>());
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Server.DBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
    }

}