namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class M2T_TeamDungeonOpenHandler : MessageHandler<Scene, M2T_TeamDungeonOpenRequest, T2M_TeamDungeonOpenResponse>
    {
        protected override async ETTask Run(Scene scene, M2T_TeamDungeonOpenRequest request, T2M_TeamDungeonOpenResponse response)
        {
            TeamInfo teamInfo = scene.GetComponent<TeamSceneComponent>().GetTeamInfo(request.UserID);
            if (teamInfo == null)
            {
                Log.Debug($"M2T_TeamDungeonOpen: teamInfo == null");
                response.Error = ErrorCode.ERR_TeamIsFull;
                return;
            }
            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                teamInfo.PlayerList[i].Prepare = teamInfo.PlayerList[i].UserID == teamInfo.TeamId ? 1 : 0;
            }

            teamInfo.FubenType = request.FubenType;
            M2C_TeamDungeonOpenResult m2C_HorseNoticeInfo = M2C_TeamDungeonOpenResult.Create();
            m2C_HorseNoticeInfo.TeamInfo = teamInfo;
            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                MapMessageHelper.SendToClient(scene.Root(), teamInfo.PlayerList[i].UserID, m2C_HorseNoticeInfo);
            }
            await ETTask.CompletedTask;
        }
    }
}
