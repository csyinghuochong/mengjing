using System;
using System.Net;

namespace ET.Server
{
    [Invoke((long)SceneType.RouterManager)]
    public class FiberInit_RouterManager: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get((int)root.Id);
            root.AddComponent<HttpComponent, string>($"http://*:{startSceneConfig.Port}/");

            Log.Console($"RouterManager create: {root.Fiber.Id}");
            Console.WriteLine($"RouterManager create: {root.Fiber.Id}    {startSceneConfig.Port}");
            
            await ETTask.CompletedTask;
        }
    }
}