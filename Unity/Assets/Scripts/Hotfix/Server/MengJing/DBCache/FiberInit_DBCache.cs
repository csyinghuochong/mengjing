using System.Net;

namespace ET.Server
{
    [Invoke((long)SceneType.DBCache)]
    public class FiberInit_DBCache : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<UnitCacheComponent>();
            await ETTask.CompletedTask;
        }
    }
}