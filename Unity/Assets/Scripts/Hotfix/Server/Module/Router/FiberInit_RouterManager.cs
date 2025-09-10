using System;

namespace ET.Server
{
    [Invoke((long)SceneType.RouterManager)]
    public class FiberInit_RouterManager: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get((int)root.Id);

            Console.WriteLine($"FiberInit_RouterManager");
            root.AddComponent<HttpComponent, string>($"http://*:{startSceneConfig.Port}/");

            await ETTask.CompletedTask;
        }
    }
}