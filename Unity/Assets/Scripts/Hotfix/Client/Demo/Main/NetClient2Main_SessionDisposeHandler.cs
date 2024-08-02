namespace ET.Client
{
    [MessageHandler(SceneType.All)]
    public class NetClient2Main_SessionDisposeHandler: MessageHandler<Scene, NetClient2Main_SessionDispose>
    {
        protected override async ETTask Run(Scene entity, NetClient2Main_SessionDispose message)
        {
            //先简单做一下断线重连
            Scene root = entity.Root();
            await root.GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second * 10);
            Log.Debug("开始重连");
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            await LoginHelper.Login(root, playerComponent.Account, playerComponent.Password, 1, playerComponent.VersionMode);
            await LoginHelper.LoginGameAsync(root, 1);
            await ETTask.CompletedTask;
        }
    }
}