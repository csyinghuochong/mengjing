namespace ET.Server
{
    [Invoke((long)SceneType.Team)]
    public class FiberInit_Team : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<DBManagerComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            root.AddComponent<TeamSceneComponent>();
            await ETTask.CompletedTask;
        }
    }
}