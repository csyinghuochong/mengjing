using System;

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
            M2C_TeamDungeonOpenResult m2C_HorseNoticeInfo = new M2C_TeamDungeonOpenResult() { TeamInfo = teamInfo  };
            ActorId gateServerId = StartSceneConfigCategory.Instance.GetBySceneName(scene.Zone(), "Gate1").ActorId;
            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                    (gateServerId, new T2G_GateUnitInfoRequest()
                    {
                        UserID = teamInfo.PlayerList[i].UserID
                    });

                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    MapMessageHelper.SendToClient(scene.Root(), g2M_UpdateUnitResponse.SessionInstanceId, m2C_HorseNoticeInfo);
                }
            }
            await ETTask.CompletedTask;
        }
    }
}
