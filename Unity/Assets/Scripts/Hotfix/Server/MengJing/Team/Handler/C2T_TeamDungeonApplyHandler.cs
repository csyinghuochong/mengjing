namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2T_TeamDungeonApplyHandler : MessageHandler<Scene, C2T_TeamDungeonApplyRequest, T2C_TeamDungeonApplyResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamDungeonApplyRequest request, T2C_TeamDungeonApplyResponse response)
        {
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            if (teamSceneComponent.GetTeamInfo(request.TeamPlayerInfo.UserID) != null)
            {
                response.Error = ErrorCode.ERR_IsHaveTeam;
                return;
            }

            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo(request.TeamId);
            if (teamInfo == null || teamInfo.PlayerList.Count == 3)
            {
                response.Error = ErrorCode.ERR_TeamIsFull;

                return;
            }

            //需要判断次数就添加C2M
            M2C_TeamDungeonApplyResult m2C_HorseNoticeInfo = M2C_TeamDungeonApplyResult.Create();
            m2C_HorseNoticeInfo.TeamPlayerInfo = request.TeamPlayerInfo;
            ActorId gateServerId = StartSceneConfigCategory.Instance.GetBySceneName(scene.Zone(), "Gate1").ActorId;
            T2G_GateUnitInfoRequest T2G_GateUnitInfoRequest = T2G_GateUnitInfoRequest.Create();
            T2G_GateUnitInfoRequest.UserID = teamInfo.TeamId;
            G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                  (gateServerId, T2G_GateUnitInfoRequest);
            if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
            {
                MapMessageHelper.SendToClient(scene.Root(), g2M_UpdateUnitResponse.SessionInstanceId, m2C_HorseNoticeInfo);
            }
        }
    }
}
