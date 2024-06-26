namespace ET.Client
{
    [Event(SceneType.Current)]
    public class Task_OnTaskNpcDialog: AEvent<Scene, TaskNpcDialog>
    {
        protected override async ETTask Run(Scene scene, TaskNpcDialog args)
        {
            if (args.ErrorCode == 0)
            {
                OperaComponent operaComponent = scene.GetComponent<OperaComponent>();
                operaComponent.OpenNpcTaskUI(args.NpcId).Coroutine();
            }

            if (args.ErrorCode > 200000)
            {
                HintHelp.ShowErrorHint(scene.Root(), args.ErrorCode);
            }

            await ETTask.CompletedTask;
        }
    }
}