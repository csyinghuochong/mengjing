using I2.Loc;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class AppStartInitFinish_CreateLoginUI: AEvent<Scene, AppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, AppStartInitFinish args)
        {
            //await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            mapComponent.MapType = MapTypeEnum.LoginScene;
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_MJLogin);
            await root.GetComponent<SceneManagerComponent>().ChangeScene(MapTypeEnum.LoginScene, 0, 0);
        }
    }
}