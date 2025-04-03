namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Solo_SoloQuitEvent : AEvent<Scene, UISoloQuit>
    {
        protected override async ETTask Run(Scene scene, UISoloQuit args)
        {
            scene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Solo);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class Solo_SoloReward : AEvent<Scene, UISoloReward>
    {
        protected override async ETTask Run(Scene scene, UISoloReward args)
        {
            DlgSoloReward dlgSoloReward = scene.GetComponent<UIComponent>().GetDlgLogic<DlgSoloReward>();
            if (dlgSoloReward == null)
            {
                await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SoloReward);
                dlgSoloReward = scene.GetComponent<UIComponent>().GetDlgLogic<DlgSoloReward>();
                dlgSoloReward.OnInit(args.m2C_SoloDungeon.SoloResult, args.m2C_SoloDungeon.RewardItem);
            }

            await ETTask.CompletedTask;
        }
    }
}