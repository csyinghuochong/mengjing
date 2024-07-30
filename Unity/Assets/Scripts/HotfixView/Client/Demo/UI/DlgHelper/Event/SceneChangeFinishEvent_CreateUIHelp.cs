namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
             scene.AddComponent<MJCameraComponent>();
             
             Log.Debug("AddComponent<OperaComponent>");
             scene.AddComponent<OperaComponent>();
            
             // scene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Helper);
             //scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.AfterEnterScene(args.SceneType);
             
             await ETTask.CompletedTask;
        }
    }
}