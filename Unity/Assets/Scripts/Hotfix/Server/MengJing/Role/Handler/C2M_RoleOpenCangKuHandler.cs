namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_RoleOpenCangKuHandler : MessageLocationHandler<Unit, C2M_RoleOpenCangKuRequest, M2C_RoleOpenCangKuResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RoleOpenCangKuRequest request, M2C_RoleOpenCangKuResponse response)
        {
            int cangkuNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.CangKuNumber);
            if (cangkuNumber >= 4)
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }

            string costItems = GlobalValueConfigCategory.Instance.Get(38).Value;
            if (!unit.GetComponent<BagComponentS>().OnCostItemData(costItems))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.CangKuNumber, cangkuNumber+1);
            await ETTask.CompletedTask;
        }
    }
}
