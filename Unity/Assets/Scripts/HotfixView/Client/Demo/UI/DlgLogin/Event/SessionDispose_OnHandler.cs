

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class SessionDispose_OnHandler: AEvent<Scene, SessionDispose>
    {
        protected override async ETTask Run(Scene root, SessionDispose args)
        {
            Log.Warning("SessionDispose_OnHandler");
            //await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
            ConfigData.LoadSceneFinished = false;
            //先简单做一下断线重连
         
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.SceneType < SceneTypeEnum.MainCityScene)
            {
                //直接返回登陆
                EventSystem.Instance.Publish(root, new ReturnLogin());
                return;
            }

            int disconnectType = root.GetComponent<PlayerComponent>().DisconnectType;
            root.GetComponent<PlayerComponent>().DisconnectType = 0;
            switch (disconnectType)
            {
                case ErrorCode.ERR_OtherAccountLogin:
                    OnOtherAccountLogin(root).Coroutine();
                    break;
                case ErrorCode.ERR_SessionDisconnect:
                    OnSessionDisconnect(root).Coroutine();
                    break;
                case ErrorCode.ERR_KickOutPlayer:
                    //PopupTipHelp.OpenPopupTip(scene, "重新登录", "由于您长时间未操作，请重新登录！", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine(); 
                    break;
                case ErrorCode.ERR_PackageFrequent:
                    //PopupTipHelp.OpenPopupTip(scene, "消息异常", "请重新登录", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine();
                     break;
                default:
                    EventSystem.Instance.Publish(root, new ReturnLogin());
                    break;
            }
        }

        private async ETTask OnSessionDisconnect(Scene root)
        {
            // 断线重连的流程
            // 需要显示菊花。。
            await root.GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second * 10);
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            await LoginHelper.Login(root, playerComponent.Account, playerComponent.Password, 1, playerComponent.VersionMode);
            await LoginHelper.LoginGameAsync(root, 1);
        }

        private async ETTask OnOtherAccountLogin(Scene root)
        {
            PopupTipHelp.OpenPopupTip_2(root, "系统提示", "账号在其他设备登陆!", () => 
                        {
                            EventSystem.Instance.Publish(root, new ReturnLogin());
                        })
                    .Coroutine();
        }
    }
}