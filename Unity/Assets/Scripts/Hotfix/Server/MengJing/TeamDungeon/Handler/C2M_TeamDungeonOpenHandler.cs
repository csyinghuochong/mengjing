namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TeamDungeonOpenHandler : MessageLocationHandler<Unit, C2M_TeamDungeonOpenRequest, M2C_TeamDungeonOpenResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamDungeonOpenRequest request, M2C_TeamDungeonOpenResponse response)
        {
            ActorId teamServerId = UnitCacheHelper.GetTeamServerId(unit.Zone());
            M2T_TeamDungeonOpenRequest M2T_TeamDungeonOpenRequest = M2T_TeamDungeonOpenRequest.Create();
            M2T_TeamDungeonOpenRequest.UserID = unit.Id;
            M2T_TeamDungeonOpenRequest.FubenType = request.FubenType;
            M2T_TeamDungeonOpenRequest.SceneType = request.SceneType;
            T2M_TeamDungeonOpenResponse createResponse = (T2M_TeamDungeonOpenResponse)await unit.Root().GetComponent<MessageSender>().Call(teamServerId,M2T_TeamDungeonOpenRequest);

            if (createResponse.Error != ErrorCode.ERR_Success)
            {
                ServerLogHelper.LogDebug($"T2M_TeamDungeonOpenResponse:{createResponse.Error}");
                response.Error = createResponse.Error;

                return;
            }
            response.FubenType = request.FubenType;
            await ETTask.CompletedTask;
        }
    }
}
