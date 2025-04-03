using System;

namespace ET.Server
{
    [Invoke((long)SceneType.PetMatch)]
    public class FiberInit_PetMatch : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {

            Scene root = fiberInit.Fiber.Root;
            
            Console.WriteLine($"FiberInit_PetMatch:  {root.Name}");
            
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<DBManagerComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            root.AddComponent<PetMatchSceneComponent>();
            await ETTask.CompletedTask;
        }
    }
}