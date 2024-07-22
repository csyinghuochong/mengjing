using System;
using ET.Server;

namespace ET.Client
{
    [Invoke((long)SceneType.RobotManager)]
    public class FiberInit_RobotManager : AInvokeHandler<FiberInit, ETTask>
    {

        public override async ETTask Handle(FiberInit fiberInit)
        {
            Console.WriteLine("FiberInit_Robot");

            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<PlayerComponent>();
            root.AddComponent<CurrentScenesComponent>();
            root.AddComponent<ObjectWait>();
            root.AddComponent<RobotManagerComponent>();
            await ETTask.CompletedTask;
        }
    }
}