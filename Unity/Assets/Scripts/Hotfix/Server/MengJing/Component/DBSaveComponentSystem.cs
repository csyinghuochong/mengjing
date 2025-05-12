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
                ServerLogHelper.LoginInfo(offLineInfo);
                Log.Debug(offLineInfo);
            }
            self.PlayerState = PlayerState.Game;
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.LastLoginTime, TimeHelper.ServerNow(), false); 
        }
        
        public static void OnRelogin(this DBSaveComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            string offLineInfo = $"{unit.Zone()}区： " +
                    $"unit.id: {unit.Id} : " +
                    $" {unit.GetComponent<UserInfoComponentS>().UserInfo.Name} : " +
                    $"{  TimeHelper.DateTimeNow().ToString()}   二次登录";

            if (!unit.IsRobot())
            {
                ServerLogHelper.LoginInfo(offLineInfo);
                //需要通知其他服务器吗？
                Log.Debug(offLineInfo);
            }
            self.PlayerState = PlayerState.Game;
        }
        
        //离线
        public static  void OnOffLine(this DBSaveComponent self)
        {
            Console.WriteLine($"OnOffLine: {self.Id}");
            
            Unit unit = self.GetParent<Unit>();
            string offLineInfo = $"{unit.Zone()}区： " +
                    $"unit.id: {unit.Id} : " +
                    $" {unit.GetComponent<UserInfoComponentS>().UserInfo.Name} : " +
                    $"{  TimeHelper.DateTimeNow().ToString()}   离线";

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsLong(NumericType.Now_Stall) > 0)
            {
                long stallId = numericComponent.GetAsLong(NumericType.Now_Stall);
                Unit unitstall = unit.GetParent<UnitComponent>().Get(stallId);
                if (unitstall != null)
                {
                    unitstall.AddComponent<DeathTimeComponent, long>(TimeHelper.Hour * 6);
                }
            }

            numericComponent.ApplyValue(NumericType.LastLoginTime, TimeHelper.ServerNow(), false);
            self.PlayerState = PlayerState.Disconnect;
            if (!unit.IsRobot())
            {
                ServerLogHelper.LoginInfo(offLineInfo);
                Log.Warning(offLineInfo);
                self.UpdateCacheDB();
            }
        }
        
        
        public static void OnDisconnect(this DBSaveComponent self)
        {
            Console.WriteLine($"OnDisconnect: {self.Id}");
            
            Unit unit = self.GetParent<Unit>();
            string offLineInfo = $"{unit.Zone()}区： " +
                    $"unit.id: {unit.Id} : " +
                    $" {unit.GetComponent<UserInfoComponentS>().UserInfo.Name} : " +
                    $"{  TimeHelper.DateTimeNow().ToString()}  移除";

            Scene scene = unit.Scene();
            int sceneTypeEnum = scene.GetComponent<MapComponent>().MapType;
            if (sceneTypeEnum == MapTypeEnum.MainCityScene)
            {
                unit.RecordPostion(sceneTypeEnum, GlobalValueConfigCategory.Instance.MainCityID);
            }
           
            unit.GetComponent<EnergyComponentS>().OnDisconnect();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.LastLoginTime, TimeHelper.ServerNow(), false);
            self.PlayerState = PlayerState.None;
            TransferHelper.BeforeTransfer(unit,sceneTypeEnum);
            
            if (!unit.IsRobot())
            {
                self.UpdateCacheDB();
                ServerLogHelper.LoginInfo(offLineInfo);
                ServerLogHelper.LogDebug(offLineInfo);
            }

            unit.GetParent<UnitComponent>().Remove(unit.Id);
            TransferHelper.OnPlayerDisconnect(scene, unit.Id);
        }
        
        public static void Activeted(this DBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Second, TimerInvokeType.DBSaveTimer, self);
        }

        public static void UpdateCacheDB(this DBSaveComponent self)
        {
            UnitCacheHelper.AddOrUpdateUnitAllCache(self.GetParent<Unit>());
        }

        /// <summary>
        /// 每秒检测
        /// </summary>
        /// <param name="self"></param>
        public static void Check(this DBSaveComponent self)
        {
            Unit unit =  self.GetParent<Unit>(); 
            unit.GetComponent<UserInfoComponentS>().Check(1);
            unit.GetComponent<TaskComponentS>().Check(1);
            
            self.DBInterval++;
            if (self.DBInterval >= 600)
            {
                self.DBInterval = 0;
                self.UpdateCacheDB();   
            }
        }
        
        [EntitySystem]
        private static void Destroy(this DBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
    }

}