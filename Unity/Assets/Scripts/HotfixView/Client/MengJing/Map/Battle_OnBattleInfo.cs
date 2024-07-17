namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Battle_OnBattleInfo: AEvent<Scene, BattleInfo>
    {
        protected override async ETTask Run(Scene scene, BattleInfo args)
        {
            DlgBattleMain dlgBattleMain = scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgBattleMain>();

            if (dlgBattleMain == null)
            {
                return;
            }

            dlgBattleMain.OnUpdateUI(args.M2CBattleInfoResult);

            await ETTask.CompletedTask;
        }
    }
}