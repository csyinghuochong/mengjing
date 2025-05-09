namespace ET.Server
{
    [Invoke((long)SceneType.JiaYuan)]
    public class FiberInit_JiaYuan : AInvokeHandler<FiberInit, ETTask>
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
            root.AddComponent<JiaYuanSceneComponent>();

            await ETTask.CompletedTask;
        }
    }
}