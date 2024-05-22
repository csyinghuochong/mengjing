namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    public class T2G_GateUnitInfoHandler: MessageHandler<Scene, T2G_GateUnitInfoRequest, G2T_GateUnitInfoResponse>
    {
        protected override async ETTask Run(Scene scene, T2G_GateUnitInfoRequest request, G2T_GateUnitInfoResponse response)
        {
            Player gateUnitInfo = scene.GetComponent<PlayerComponent>().GetByUserId(request.UserID);

            response.SessionInstanceId = (gateUnitInfo != null && gateUnitInfo.GetComponent<PlayerSessionComponent>()?.Session != null)
                    ? gateUnitInfo.Id : 0;
            response.PlayerState = gateUnitInfo != null? (int)gateUnitInfo.PlayerState : (int)PlayerState.None;
            response.UnitId = gateUnitInfo != null? gateUnitInfo.UnitId : 0;
            await ETTask.CompletedTask;
        }
    }
}