namespace ET.Client
{
    [MessageHandler(SceneType.All)]
    public class NetClient2Main_SessionDisposeHandler: MessageHandler<Scene, NetClient2Main_SessionDispose>
    {
        protected override async ETTask Run(Scene entity, NetClient2Main_SessionDispose message)
        {
            Log.Debug($"NetClient2Main_SessionDisposeHandler:{entity.Root().Name}");
            
           
            EventSystem.Instance.Publish(entity.Root(), new SessionDispose());
            
            
            await ETTask.CompletedTask;
        }
    }
}