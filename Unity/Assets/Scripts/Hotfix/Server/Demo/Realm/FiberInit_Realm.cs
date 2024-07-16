using System;
using System.Net;

namespace ET.Server
{
    [Invoke((long)SceneType.Realm)]
    public class FiberInit_Realm: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<TokenComponent>();
            root.AddComponent<AccountSessionsComponent>();
            root.AddComponent<DBManagerComponent>();
            root.AddComponent<FangChenMiComponentS>();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get(root.Fiber.Id);
            root.AddComponent<NetComponent, IPEndPoint, NetworkProtocol>(startSceneConfig.InnerIPPort, NetworkProtocol.UDP);
            Console.WriteLine($"FiberInit_Realm: {root.Fiber.Id}  {startSceneConfig.InnerIPPort}");
            await ETTask.CompletedTask;
        }
    }
}