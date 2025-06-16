

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class SessionDispose_OnRelink: AEvent<Scene, SessionDispose>
    {
        protected override async ETTask Run(Scene root, SessionDispose args)
        {
            //await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
            //先简单做一下断线重连
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            int disconnectType = root.GetComponent<PlayerInfoComponent>().DisconnectType;
            root.GetComponent<PlayerInfoComponent>().DisconnectType = 0;
            
            Log.Warning($"SessionDispose_OnHandler: {mapComponent.MapType}  {disconnectType}");
            // FlyTipComponent.Instance.ShowFlyTipDi($"SessionDispose_OnRelink: {mapComponent.MapType}  {disconnectType}");
            
            if (mapComponent.MapType < MapTypeEnum.MainCityScene)
            {
                //直接返回登陆
                EventSystem.Instance.Publish(root, new ReturnLogin());
                return;
            }

            switch (disconnectType)
            {
                case ErrorCode.ERR_OtherAccountLogin:
                    OnOtherAccountLogin(root);
                    break;
                case ErrorCode.ERR_SessionDisconnect:
                    OnSessionDisconnect(root);
                    break;
                case ErrorCode.ERR_KickOutPlayer:
                    //PopupTipHelp.OpenPopupTip(scene, "重新登录", "由于您长时间未操作，请重新登录！", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine(); 
                    break;
                case ErrorCode.ERR_PackageFrequent:
                    //PopupTipHelp.OpenPopupTip(scene, "消息异常", "请重新登录", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine();
                     break;
                default:
                    //EventSystem.Instance.Publish(root, new ReturnLogin());
                    OnSessionDisconnect(root);
                    break;
            }

            await ETTask.CompletedTask;
        }

        private  void OnSessionDisconnect(Scene root)
        {
            // 断线重连的流程
            // 需要显示菊花。。
            Log.Warning($"OnSessionDisconnect...Relink");
            root.GetComponent<RelinkComponent>().CheckRelink().Coroutine();
        }

        private  void OnOtherAccountLogin(Scene root)
        {
            PopupTipHelp.OpenPopupTip_2(root, "系统提示", "账号在其他设备登陆!", () => 
                        {
                            EventSystem.Instance.Publish(root, new ReturnLogin());
                        })
                    .Coroutine();
        }
    }
}