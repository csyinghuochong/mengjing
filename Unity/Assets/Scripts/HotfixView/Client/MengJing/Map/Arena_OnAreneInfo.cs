namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Arena_OnAreneInfo: AEvent<Scene, AreneInfo>
    {
        protected override async ETTask Run(Scene scene, AreneInfo args)
        {
            DlgArenaMain dlgArenaMain = scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgArenaMain>();
            if (dlgArenaMain == null)
            {
                return;
            }

            dlgArenaMain.OnUpdateUI(args.M2CAreneInfoResult);

            await ETTask.CompletedTask;
        }
    }
}