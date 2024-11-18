namespace ET
{
    public struct EntryEvent1
    {
    }   
    
    public struct EntryEvent2
    {
    } 
    
    public struct EntryEvent3
    {
    }
    
    public struct EntryEvent4
    {
    }
    
    public static class Entry
    {
        public static void Init()
        {
            
        }
        
        public static void Start()
        {
            StartAsync().Coroutine();
        }
        
        private static async ETTask StartAsync()
        {
            
            Log.Warning($"Debug...Entry.StartAsync: {TimeHelper.ClientNow()}");
            WinPeriod.Init();

            Log.Warning($"Debug...WinPeriod.Init: {TimeHelper.ClientNow()}");
            
            // 注册Mongo type
            MongoRegister.Init();   //耗时6s
            
            Log.Warning($"Debug...MongoRegister.Init: {TimeHelper.ClientNow()}");
            
            // 注册Entity序列化器
            EntitySerializeRegister.Init();
            
            Log.Warning($"Debug...EntitySerializeRegister.Init: {TimeHelper.ClientNow()}");
            
            World.Instance.AddSingleton<IdGenerater>();
            World.Instance.AddSingleton<OpcodeType>();
            World.Instance.AddSingleton<ObjectPool>();
            World.Instance.AddSingleton<MessageQueue>();
            World.Instance.AddSingleton<NetServices>();
            World.Instance.AddSingleton<NavmeshComponent>();
            World.Instance.AddSingleton<LogMsg>();
            
            Log.Warning($"Debug...AddSingleton: {TimeHelper.ClientNow()}");

            TimeInfo.Instance.TimeZone = 8;
            // 创建需要reload的code singleton
            CodeTypes.Instance.CreateCode();
            
            Log.Warning($"Debug...CreateCode: {TimeHelper.ClientNow()}");
            
            await World.Instance.AddSingleton<ConfigLoader>().LoadAsync();  //耗时8s

            Log.Warning($"Debug...Entry.Create.Main: {TimeHelper.ClientNow()}");
    
            await FiberManager.Instance.Create(SchedulerType.Main, ConstFiberId.Main, 0, SceneType.Main, "");
        }
    }
}