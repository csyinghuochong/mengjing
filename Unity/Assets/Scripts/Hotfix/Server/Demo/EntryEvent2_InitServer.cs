using System;

namespace ET.Server
{
    [Event(SceneType.Main)]
    public class EntryEvent2_InitServer : AEvent<Scene, EntryEvent2>
    {
        protected override async ETTask Run(Scene root, EntryEvent2 args)
        {
            switch (Options.Instance.AppType)
            {
                case AppType.Server:
                    {

                        int process = root.Fiber.Process;
                        root.AddComponent<DBManagerComponent>();
                        StartProcessConfig startProcessConfig = StartProcessConfigCategory.Instance.Get(process);
                        if (startProcessConfig.InnerPort != 0)
                        {
                            await FiberManager.Instance.Create(SchedulerType.ThreadPool, ConstFiberId.NetInner, 0, SceneType.NetInner, "NetInner");
                        }

                        // 根据配置创建纤程
                        var processScenes = StartSceneConfigCategory.Instance.GetByProcess(process);
                        
                        //Console.WriteLine($"processScenes: {process}  {processScenes.Count}");
                        foreach (StartSceneConfig startConfig in processScenes)
                        { 
                            //Console.WriteLine($"processScenes1: {process}  {startConfig.Name}");
                            await FiberManager.Instance.Create(SchedulerType.ThreadPool, startConfig.Id, startConfig.Zone, startConfig.Type, startConfig.Name);
                        }

                        break;
                    }
                case AppType.Watcher:
                    {
                        root.AddComponent<WatcherComponent>();
                        break;
                    }
                case AppType.GameTool:
                    {
                        break;
                    }
            }

            if (Options.Instance.Console == 1)
            {
                root.AddComponent<ConsoleComponent>();
            }
        }
    }
}