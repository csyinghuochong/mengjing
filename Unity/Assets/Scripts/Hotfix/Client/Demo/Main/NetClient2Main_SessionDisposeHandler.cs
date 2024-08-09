namespace ET.Client
{
    [MessageHandler(SceneType.All)]
    public class NetClient2Main_SessionDisposeHandler: MessageHandler<Scene, NetClient2Main_SessionDispose>
    {
        protected override async ETTask Run(Scene entity, NetClient2Main_SessionDispose message)
        {
            //先简单做一下断线重连
            Scene root = entity.Root();
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.SceneType >= SceneTypeEnum.MainCityScene)
            {
                await root.GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second * 10);
                PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
                await LoginHelper.Login(root, playerComponent.Account, playerComponent.Password, 1, playerComponent.VersionMode);
                await LoginHelper.LoginGameAsync(root, 1);
            }
            else
            {
                //直接返回登陆
                //EventSystem.Instance.Publish(root, new ReturnLogin());
            }
            
            await ETTask.CompletedTask;
        }
    }
}