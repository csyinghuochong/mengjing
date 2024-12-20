using System;
using System.Net;
using ET.Server;

namespace ET.Client
{
    [Invoke((long)SceneType.RobotManager)]
    public class FiberInit_RobotManager : AInvokeHandler<FiberInit, ETTask>
    {

        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<PlayerInfoComponent>();
            root.AddComponent<CurrentScenesComponent>();
            root.AddComponent<ObjectWait>();
            root.AddComponent<RobotManagerComponent>();
            
             // StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get(root.Fiber.Id);
             //            root.AddComponent<NetComponent, IPEndPoint, NetworkProtocol>(startSceneConfig.InnerIPPort, NetworkProtocol.UDP);
             //            
            await ETTask.CompletedTask;
        }
    }
}