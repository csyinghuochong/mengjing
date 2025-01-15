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

            Console.WriteLine($"C2M_TeamDungeonCreateRequest  { request.TeamPlayerInfo.UserID} ");
            
            ActorId teamServerId = UnitCacheHelper.GetTeamServerId(unit.Zone());
            M2T_TeamDungeonCreateRequest M2T_TeamDungeonCreateRequest = M2T_TeamDungeonCreateRequest.Create();
            M2T_TeamDungeonCreateRequest.FubenId = request.FubenId;
            M2T_TeamDungeonCreateRequest.TeamPlayerInfo = request.TeamPlayerInfo;
            M2T_TeamDungeonCreateRequest.FubenType = request.FubenType;
            M2T_TeamDungeonCreateRequest.SceneType = request.SceneType;
            T2M_TeamDungeonCreateResponse createResponse = (T2M_TeamDungeonCreateResponse)await unit.Root().GetComponent<MessageSender>().Call(teamServerId,M2T_TeamDungeonCreateRequest);

            Console.WriteLine($"T2M_TeamDungeonCreateResponse  { createResponse} ");
            
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
