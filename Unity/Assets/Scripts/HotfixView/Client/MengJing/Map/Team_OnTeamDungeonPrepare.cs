namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Team_OnTeamDungeonPrepare : AEvent<Scene, RecvTeamDungeonPrepare>
    {
        protected override async ETTask Run(Scene scene, RecvTeamDungeonPrepare args)
        {
            bool blackroom = UnitHelper.IsBackRoom(scene);
            if (blackroom)
            {
                return;
            }
            
            DlgTeamDungeonPrepare dlgTeamDungeonPrepare = scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamDungeonPrepare>();

            if (dlgTeamDungeonPrepare == null)
            {
                return;
            }

            dlgTeamDungeonPrepare.OnUpdateUI(args.m2CTeamDungeonPrepareResult.TeamInfo, args.m2CTeamDungeonPrepareResult.ErrorCode);
            await ETTask.CompletedTask;
        }
    }
}