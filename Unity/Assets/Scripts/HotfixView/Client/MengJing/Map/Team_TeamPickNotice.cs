namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Team_TeamPickNotice: AEvent<Scene, TeamPickNotice>
    {
        protected override async ETTask Run(Scene scene, TeamPickNotice args)
        {
            DlgTeamMain dlgTeamMain = scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamMain>();
            if (dlgTeamMain != null)
            {
                dlgTeamMain.OnTeamPickNotice(args.M2CTeamPickMessage.DropItems);
            }

            await ETTask.CompletedTask;
        }
    }
}