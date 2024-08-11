namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class P2M_PaiMaiBuyInfoHandler: MessageHandler<Unit, P2M_PaiMaiBuyInfoRequest, M2P_PaiMaiBuyInfoResponse>
    {
        protected override async ETTask Run(Unit unit, P2M_PaiMaiBuyInfoRequest request, M2P_PaiMaiBuyInfoResponse response)
        {
            unit.GetComponent<DataCollationComponent>().UpdateBuySelfPlayerList( request.CostGold,request.PlayerId, true );

            long paimaiGold = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.PaiMaiTodayGold);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PaiMaiTodayGold, paimaiGold + request.CostGold, true);

            await ETTask.CompletedTask;
        }
    }
}