namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class EnterMapFinish_CreateUIMain: AEvent<Scene, EnterMapFinish>
    {
        protected override async ETTask Run(Scene root, EnterMapFinish args)
        {
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Main);
            root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MJLobby);
        }
    }
}