namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_WelfareDraw2Handler : MessageLocationHandler<Unit, C2M_WelfareDraw2Request, M2C_WelfareDraw2Response>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareDraw2Request request, M2C_WelfareDraw2Response response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

            //已经生成了奖励格子
            if (numericComponent.GetAsInt(NumericType.DrawIndex2) > 0)
            {
                return;
            }

            if (numericComponent.GetAsLong(NumericType.RechargeNumber) / 50 - numericComponent.GetAsLong(NumericType.WelfareChouKaNumber) <= 0)
            {
                return;
            }

            int index = RandomHelper.RandomNumber(0, ConfigData.WelfareChouKaList.Count) + 1;

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.DrawIndex2, index);
            unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.WelfareChouKaNumber, 1);
            await ETTask.CompletedTask;
        }
    }
}