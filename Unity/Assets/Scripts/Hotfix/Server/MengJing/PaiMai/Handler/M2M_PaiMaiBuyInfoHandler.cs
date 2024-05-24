using System;


namespace ET.Server
{

    [MessageHandler(SceneType.PaiMai)]
    public class M2M_PaiMaiBuyInfoHandler: MessageHandler<Unit, M2M_PaiMaiBuyInfoRequest, M2M_PaiMaiBuyInfoResponse>
    {
        protected override async ETTask Run(Unit unit, M2M_PaiMaiBuyInfoRequest request, M2M_PaiMaiBuyInfoResponse response)
        {
            unit.GetComponent<DataCollationComponent>().UpdateBuySelfPlayerList( request.CostGold,request.PlayerId, true );

            long paimaiGold = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.PaiMaiTodayGold);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PaiMaiTodayGold, paimaiGold + request.CostGold, true);

            await ETTask.CompletedTask;
        }
    }
}