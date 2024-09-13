namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SoloMatchHandler : MessageLocationHandler<Unit, C2M_SoloMatchRequest, M2C_SoloMatchResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SoloMatchRequest request, M2C_SoloMatchResponse response)
        {
            //获取地图类型,如果当前地图不是在主城就返回
            /*
            MapComponent mapComponent = unit.DomainScene().GetComponent<MapComponent>();
            if (mapComponent.SceneTypeEnum != SceneTypeEnum.MainCityScene)
            {
                reply();
                return;
            }
            */

            //给匹配服务器发送消息
            ActorId soloServerId = UnitCacheHelper.GetSoloServerId(unit.Zone());  //获取solo服务器ID
            SoloPlayerInfo soloPlayerInfo = SoloPlayerInfo.Create();
            soloPlayerInfo.UnitId = unit.Id;
            soloPlayerInfo.Combat = unit.GetComponent<UserInfoComponentS>().UserInfo.Combat;
            soloPlayerInfo.Name = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
            soloPlayerInfo.Occ = unit.GetComponent<UserInfoComponentS>().UserInfo.Occ;
            soloPlayerInfo.MatchTime = TimeHelper.ServerNow();
            M2S_SoloMatchRequest M2S_SoloMatchRequest = M2S_SoloMatchRequest.Create();
            M2S_SoloMatchRequest.SoloPlayerInfo = soloPlayerInfo;
            S2M_SoloMatchResponse d2GGetUnit = (S2M_SoloMatchResponse)await unit.Root().GetComponent<MessageSender>().Call(soloServerId,M2S_SoloMatchRequest);

            ServerLogHelper.LogWarning("发送竞技场匹配地图消息" + soloPlayerInfo.UnitId, true);
            await ETTask.CompletedTask;
        }
    }
}
