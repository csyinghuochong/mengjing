namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_PetMatchHandler : MessageLocationHandler<Unit, C2M_PetMatchRequest, M2C_PetMatchResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMatchRequest request, M2C_PetMatchResponse response)
        {
            //给匹配服务器发送消息
            ActorId soloServerId = UnitCacheHelper.GetPetMatchServerId(unit.Zone());  //获取solo服务器ID
            PetMatchPlayerInfo soloPlayerInfo = PetMatchPlayerInfo.Create();
            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            soloPlayerInfo.UnitId = unit.Id;
            soloPlayerInfo.Name = userInfoComponentS.UserInfo.Name;
            soloPlayerInfo.Occ = userInfoComponentS.UserInfo.Occ;
            soloPlayerInfo.RobotId = userInfoComponentS.UserInfo.RobotId;
            soloPlayerInfo.MatchTime = TimeHelper.ServerNow();
            if (userInfoComponentS.UserInfo.RobotId > 0)
            {
                unit.GetComponent<PetComponentS>().InitRobotPet();
            }

            NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();
            
            M2PetMatch_MatchRequest M2S_SoloMatchRequest = M2PetMatch_MatchRequest.Create();
            M2S_SoloMatchRequest.SoloPlayerInfo = soloPlayerInfo;
            PetMatch2M_MatchResponse d2GGetUnit = (PetMatch2M_MatchResponse)await unit.Root().GetComponent<MessageSender>().Call(soloServerId,M2S_SoloMatchRequest);
            response.Error = d2GGetUnit.Error;
            ServerLogHelper.LogWarning("发送竞技场匹配地图消息" + soloPlayerInfo.UnitId, true);
            await ETTask.CompletedTask;
        }
    }
}
