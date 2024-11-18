

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class SessionDispose_OnHandler: AEvent<Scene, SessionDispose>
    {
        protected override async ETTask Run(Scene root, SessionDispose args)
        {
            Log.Warning("SessionDispose_OnHandler");
            //await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
            
            
            //先简单做一下断线重连
         
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.SceneType < SceneTypeEnum.MainCityScene)
            {
                //直接返回登陆
                EventSystem.Instance.Publish(root, new ReturnLogin());
                return;
            }

            int disconnectType = root.GetComponent<PlayerComponent>().DisconnectType;
            switch (disconnectType)
            {
                case ErrorCode.ERR_OtherAccountLogin:
                    
                    break;
                case ErrorCode.ERR_SessionDisconnect:
                    
                    break;
                default:
                    EventSystem.Instance.Publish(root, new ReturnLogin());
                    break;
            }
            // 断线重连的流程
            // await root.GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second * 10);
            // PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            // await LoginHelper.Login(root, playerComponent.Account, playerComponent.Password, 1, playerComponent.VersionMode);
            // await LoginHelper.LoginGameAsync(root, 1);
        }
    }
}