namespace ET.Server
{
    [Invoke((long)SceneType.ReCharge)]
    public class FiberInit_ReCharge : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            
            //root.AddComponent<ReChargeWXComponent>();
            root.AddComponent<ReChargeQDComponent>();
            //root.AddComponent<ReChargeAliComponent>();
            //root.AddComponent<ReChargeIOSComponent>();
            //root.AddComponent<ReChargeTikTokComponent>();
            await ETTask.CompletedTask;
        }
    }
}