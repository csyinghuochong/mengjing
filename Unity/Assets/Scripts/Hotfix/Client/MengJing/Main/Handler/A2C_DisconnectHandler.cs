namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class A2C_DisconnectHandler: MessageHandler<Scene, A2C_Disconnect>
    {
        protected override async ETTask Run(Scene root, A2C_Disconnect message)
        {
            Log.Warning("A2C_Disconnect");

            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.MapType < MapTypeEnum.MainCityScene)
            {
                //直接返回登陆
                EventSystem.Instance.Publish(root, new ReturnLogin());
                return;
            }
            root.GetComponent<PlayerInfoComponent>().DisconnectType = message.Error;
            
            await ETTask.CompletedTask;
        }
    }
}