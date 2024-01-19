namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class LoginFinish_CreateLobbyUI: AEvent<Scene, LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish args)
        {
            Log.Debug("LoginFinish_CreateLobbyUI");
            scene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MJLobby);
            await ETTask.CompletedTask;
        }
    }
}