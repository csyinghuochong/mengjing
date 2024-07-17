namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class G2M_RechargeRequestHandler : MessageHandler<Unit, G2M_RechargeResultRequest, M2G_RechargeResultResponse>
    {
        protected override async ETTask Run(Unit unit, G2M_RechargeResultRequest request, M2G_RechargeResultResponse response)
        {
            RechargeHelp.SendDiamondToUnit(unit, request.RechargeNumber, request.OrderInfo);
            await ETTask.CompletedTask;
        }
    }
}
