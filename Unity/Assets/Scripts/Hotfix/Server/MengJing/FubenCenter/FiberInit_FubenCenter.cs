namespace ET.Server
{
    [Invoke((long)SceneType.FubenCenter)]
    public class FiberInit_FubenCenter : AInvokeHandler<FiberInit, ETTask>
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
            root.AddComponent<FubenCenterComponent>();
            Log.Debug("FiberInit_FubenCenter");
            await ETTask.CompletedTask;
        }
    }
}