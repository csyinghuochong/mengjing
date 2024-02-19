namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class AppStartInitFinish_CreateLoginUI: AEvent<Scene, AppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, AppStartInitFinish args)
        {
            Log.Debug("AppStartInitFinish_CreateLoginUI");
            //await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
        }
    }
}