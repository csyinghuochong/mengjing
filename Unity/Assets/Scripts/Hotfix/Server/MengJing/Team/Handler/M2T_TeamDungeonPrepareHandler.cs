using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Team)]
    public class M2T_TeamDungeonPrepareHandler : MessageHandler<Scene, M2T_TeamDungeonPrepareRequest, T2M_TeamDungeonPrepareResponse>
    {
        protected override async ETTask Run(Scene scene, M2T_TeamDungeonPrepareRequest request, T2M_TeamDungeonPrepareResponse response)
        {
            TeamInfo teamInfo = scene.GetComponent<TeamSceneComponent>().GetTeamInfo(request.TeamId);
            if (teamInfo == null)
            {
                Log.Debug($"M2T_TeamDungeonPrepare: teamInfo == null");
                response.Error = ErrorCode.Err_TeamIsNull;
                return;
            }
            
            //0未选择 1同意 2拒绝
            int errorCode = request.ErrorCode;
            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                if (teamInfo.PlayerList[i].UserID == request.UnitID)
                {
                    teamInfo.PlayerList[i].Prepare = request.Prepare;
                }
            }
            for(int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                if (teamInfo.PlayerList[i].Prepare == 2)
                {
                    errorCode = ErrorCode.Err_PlayerRefuse;
                    break;
                }
                if (teamInfo.PlayerList[i].Prepare == 0)
                {
                    errorCode = ErrorCode.Err_HaveNotPrepare;
                    break;
                }
            }

            M2C_TeamDungeonPrepareResult m2C_HorseNoticeInfo = M2C_TeamDungeonPrepareResult.Create();
            m2C_HorseNoticeInfo.TeamInfo = teamInfo;
            m2C_HorseNoticeInfo.ErrorCode = errorCode;
            ActorId gateServerId = StartSceneConfigCategory.Instance.GetBySceneName(scene.Zone(), "Gate1").ActorId;
            T2G_GateUnitInfoRequest T2G_GateUnitInfoRequest = T2G_GateUnitInfoRequest.Create();
            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                T2G_GateUnitInfoRequest.UserID = teamInfo.PlayerList[i].UserID;
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                    (gateServerId, T2G_GateUnitInfoRequest);

                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    
                    MapMessageHelper.SendToClient(scene.Root(), g2M_UpdateUnitResponse.SessionInstanceId, m2C_HorseNoticeInfo);
                }
            }
            response.TeamInfo = teamInfo;
            await ETTask.CompletedTask;
        }
    }
}
