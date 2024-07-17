namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2T_TeamDungeonAgreeHandler : MessageHandler<Scene, C2T_TeamDungeonAgreeRequest, T2C_TeamDungeonAgreeResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamDungeonAgreeRequest request, T2C_TeamDungeonAgreeResponse response)
        {
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            if (teamSceneComponent.GetTeamInfo(request.TeamPlayerInfo.UserID) != null)
            {
                response.Error = ErrorCode.ERR_IsHaveTeam;
                return;
            }

            ActorId gateServerId = StartSceneConfigCategory.Instance.GetBySceneName(scene.Zone(), "Gate1").ActorId;
            T2G_GateUnitInfoRequest T2G_GateUnitInfoRequest = T2G_GateUnitInfoRequest.Create();
            T2G_GateUnitInfoRequest.UserID = request.TeamPlayerInfo.UserID;
            G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                    (gateServerId, T2G_GateUnitInfoRequest);
            if (g2M_UpdateUnitResponse.PlayerState != (int)PlayerState.Game || g2M_UpdateUnitResponse.SessionInstanceId == 0)
            {
                //对方已下线
     
                return;
            }

            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo(request.TeamId);
            if (teamInfo == null || teamInfo.PlayerList.Count == 3)
            {
     
                return;
            }
            bool haveplayer = false;
            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                if (teamInfo.PlayerList[i].UserID == request.TeamPlayerInfo.UserID)
                {
                    haveplayer = true;
                    break;
                }
            }
            if (!haveplayer)
            {
                teamInfo.PlayerList.Add(request.TeamPlayerInfo);
            }
            teamSceneComponent.SyncTeamInfo(teamInfo,teamInfo.PlayerList).Coroutine();
        }
    }
}
