namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanCangKuOpenHandler : MessageLocationHandler<Unit, C2M_JiaYuanCangKuOpenRequest, M2C_JiaYuanCangKuOpenResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanCangKuOpenRequest request, M2C_JiaYuanCangKuOpenResponse response)
        {
            int cangkuNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.JianYuanCangKu);
            if (cangkuNumber >= 4)
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }

            string costItems = JiaYuanHelper.GetOpenJiaYuanWarehouse(cangkuNumber);
            if (!unit.GetComponent<BagComponentS>().OnCostItemData(costItems))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.JianYuanCangKu, cangkuNumber + 1);
            await ETTask.CompletedTask;
        }
    }
}
