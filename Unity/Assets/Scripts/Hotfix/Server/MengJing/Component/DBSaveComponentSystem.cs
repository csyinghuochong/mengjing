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
        private static void Awake(this DBSaveComponent self)
        {

        }

        public static void SetNoFindPath(this DBSaveComponent self)
        {


        }
        
        public static void OnLogin(this DBSaveComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            string offLineInfo = $"{unit.Zone()}区： " +
                    $"unit.id: {unit.GetComponent<UserInfoComponentS>().Id} : " +
                    $" {unit.GetComponent<UserInfoComponentS>().UserInfo.Name} : " +
                    $"{  TimeHelper.DateTimeNow().ToString()}   登录";
            if (!unit.IsRobot())
            {
                LogHelper.LoginInfo(offLineInfo);
                Log.Debug(offLineInfo);
            }
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
           
            numericComponent.ApplyValue(NumericType.LastGameTime, TimeHelper.ServerNow(), false); 
        }

        public static void Activeted(this DBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(10000, TimerInvokeType.DBSaveTimer, self);
        }

        public static void UpdateCacheDB(this DBSaveComponent self)
        {
            UnitCacheHelper.AddOrUpdateUnitAllCache(self.GetParent<Unit>());
        }

        public static void Check(this DBSaveComponent self)
        {
            self.GetParent<Unit>().GetComponent<UserInfoComponentS>().Check();
            
            UnitCacheHelper.AddOrUpdateUnitAllCache(self.GetParent<Unit>());
        }
        
        [EntitySystem]
        private static void Destroy(this DBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
    }

}