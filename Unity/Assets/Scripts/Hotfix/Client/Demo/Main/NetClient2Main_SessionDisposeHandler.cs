namespace ET.Client
{
    [MessageHandler(SceneType.All)]
    public class NetClient2Main_SessionDisposeHandler: MessageHandler<Scene, NetClient2Main_SessionDispose>
    {
        protected override async ETTask Run(Scene entity, NetClient2Main_SessionDispose message)
        {

            EventSystem.Instance.Publish(entity.Root(), new SessionDispose());

            await ETTask.CompletedTask;
        }
    }
}