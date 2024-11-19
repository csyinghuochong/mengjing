namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class G2C_SecondLoginHandler: MessageHandler<Scene, G2C_SecondLogin>
    {
        protected override async ETTask Run(Scene root, G2C_SecondLogin message)
        {
            Log.Debug("G2C_SecondLoginHandler..重连成功！！");
            //也可以放在 LoginHelper.LoginGameAsync
            
            await UserInfoNetHelper.RequestUserInfoInit(root);
            await UserInfoNetHelper.RequestFreshUnit(root);
            EventSystem.Instance.Publish(root, new RelinkSucess());
            
            //MapComponent mapComponent = root.GetComponent<MapComponent>();
            // if (mapComponent.SceneType == message.SceneType )
            // {
            //     await UserInfoNetHelper.RequestUserInfoInit(root);
            //     await UserInfoNetHelper.RequestFreshUnit(root);
            //     Log.Debug("G2C_SecondLoginHandler: mapComponent.SceneType == message.SceneType");
            // }
            // else  if (SceneTypeEnum.MainCityScene != message.SceneType)
            // {
            //     Log.Debug("G2C_SecondLoginHandler: mapComponent.SceneType != message.SceneType");
            //     EnterMapHelper.RequestTransfer(  root, message.SceneType,  message.SceneId, 0, "0" ).Coroutine();
            // }
            // else
            // {
            //     await UserInfoNetHelper.RequestUserInfoInit(root);
            //     
            //     SceneChangeHelper.SceneChangeTo( root, IdGenerater.Instance.GenerateInstanceId(), SceneTypeEnum.MainCityScene, CommonHelp.MainCityID(),0, "0" ).Coroutine();
            //     await UserInfoNetHelper.RequestFreshUnit(root);
            //     Log.Debug("G2C_SecondLoginHandler: mapComponent.SceneType  else");
            // }

            await ETTask.CompletedTask;
        }
    }
}