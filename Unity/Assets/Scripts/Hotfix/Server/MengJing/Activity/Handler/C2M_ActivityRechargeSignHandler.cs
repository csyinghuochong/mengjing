namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityRechargeSignHandler : MessageLocationHandler<Unit, C2M_ActivityRechargeSignRequest, M2C_ActivityRechargeSignResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ActivityRechargeSignRequest request, M2C_ActivityRechargeSignResponse response)
        {
            if (!ActivityConfigCategory.Instance.Contain(request.ActivityId))
            {
                Log.Warning($"C2M_ActivityRechargeError {unit.Id} {request.ActivityId}");
                return;
            }

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(request.ActivityId);
            int itemNumber = ItemHelper.GetNeedCell(activityConfig.Par_2);
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < itemNumber)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.RechargeSign) != 1)
            {
                response.Error = ErrorCode.ERR_TaskCanNotGet;
                return;
            }

            ServerLogHelper.LogDebug($"充值签到成功1：{unit.Id} { bagComponent.GetItemNumber(10010043)}");
            numericComponent.ApplyValue(NumericType.RechargeSign, 2);
            unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_2, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
            ServerLogHelper.LogDebug($"充值签到成功2：{unit.Id} { bagComponent.GetItemNumber(10010043)}");
            await ETTask.CompletedTask;
        }
    }
}
