namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class EnterMapFinish_CreateUIHuoBiSet: AEvent<Scene, EnterMapFinish>
    {
        protected override async ETTask Run(Scene root, EnterMapFinish args)
        {
            UIComponent uiComponent = root.GetComponent<UIComponent>();
            await uiComponent.ShowWindowAsync(WindowID.WindowID_HuoBiSet);
            uiComponent.HideWindow(WindowID.WindowID_HuoBiSet);
        }
    }
}