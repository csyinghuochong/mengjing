using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TeamDungeonCreateHandler : MessageLocationHandler<Unit, C2M_TeamDungeonCreateRequest, M2C_TeamDungeonCreateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamDungeonCreateRequest request, M2C_TeamDungeonCreateResponse response)
        {
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv != request.TeamPlayerInfo.PlayerLv)
            {
                return;
            }

            ActorId teamServerId = UnitCacheHelper.GetTeamServerId(unit.Zone());
            T2M_TeamDungeonCreateResponse createResponse = (T2M_TeamDungeonCreateResponse)await unit.Root().GetComponent<MessageSender>().Call(teamServerId, new M2T_TeamDungeonCreateRequest()
            {
                FubenId = request.FubenId,
                TeamPlayerInfo = request.TeamPlayerInfo,
                FubenType = request.FubenType,
            });

            if (createResponse.Error != ErrorCode.ERR_Success)
            {
                response.Error = createResponse.Error;
                return;
            }
            response.FubenType = request.FubenType;
            await ETTask.CompletedTask;
        }
    }
}
