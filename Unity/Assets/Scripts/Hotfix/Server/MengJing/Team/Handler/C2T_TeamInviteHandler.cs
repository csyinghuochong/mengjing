using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2T_TeamInviteHandler : MessageHandler<Scene, C2T_TeamInviteRequest, T2C_TeamInviteResponse>
    {
        protected override async ETTask Run(Scene scene, C2T_TeamInviteRequest request, T2C_TeamInviteResponse response)
        {
            //检测是否可以邀请玩家组队
            TeamSceneComponent teamSceneComponent = scene.GetComponent<TeamSceneComponent>();
            TeamInfo teamInfo = teamSceneComponent.GetTeamInfo( request.UserID );
            if (teamInfo != null)
            {
                return;
            }

            teamInfo = teamSceneComponent.GetTeamInfo(request.TeamPlayerInfo.UserID);
            if (teamInfo != null)
            {
                if (teamInfo.TeamId != request.TeamPlayerInfo.UserID || teamInfo.PlayerList.Count == 3)
                {
                    return;
                }
                for (int i = 0; i < teamInfo.PlayerList.Count; i++)
                {
                    if (teamInfo.PlayerList[i].UserID == request.UserID)
                    {
                        return;
                    }
                }
            }

            ActorId gateServerId = StartSceneConfigCategory.Instance.GetBySceneName(scene.Zone(), "Gate1").ActorId;
            G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                (gateServerId, new T2G_GateUnitInfoRequest() 
                {
                    UserID = request.UserID
                });

            if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
            {
                M2C_TeamInviteResult m2C_HorseNoticeInfo = new M2C_TeamInviteResult() {   TeamPlayerInfo = request.TeamPlayerInfo };
                MapMessageHelper.SendToClient(scene.Root(), g2M_UpdateUnitResponse.SessionInstanceId, m2C_HorseNoticeInfo);
            }

        }
    }
}
