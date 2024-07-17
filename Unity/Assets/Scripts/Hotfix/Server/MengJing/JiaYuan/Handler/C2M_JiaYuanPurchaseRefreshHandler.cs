namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPurchaseRefreshHandler : MessageLocationHandler<Unit, C2M_JiaYuanPurchaseRefresh, M2C_JiaYuanPurchaseRefresh>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPurchaseRefresh request, M2C_JiaYuanPurchaseRefresh response)
        {
            long jiayuanzijin = unit.GetComponent<UserInfoComponentS>().UserInfo.JiaYuanFund;
            int refreshtime = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.JiaYuanPurchaseRefresh);
            long needzijin = refreshtime >= 1 ? JiaYuanHelper.JiaYuanPurchaseRefresh : 0;

            if (refreshtime >= 3)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            if (jiayuanzijin < needzijin)
            {
                response.Error = ErrorCode.ERR_HouBiNotEnough;
                return;
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.JiaYuanPurchaseRefresh, refreshtime + 1);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.JiaYuanFund, (needzijin * -1).ToString());
            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            jiaYuanComponent.UpdatePurchaseItemList_2();

            response.PurchaseItemList .AddRange(jiaYuanComponent.PurchaseItemList_7); 
            await ETTask.CompletedTask;
        }
    }
}
