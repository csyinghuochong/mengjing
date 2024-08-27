namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanGatherHandler : MessageLocationHandler<Unit, C2M_JiaYuanGatherRequest, M2C_JiaYuanGatherResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanGatherRequest request, M2C_JiaYuanGatherResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            Unit unitplan = unit.GetParent<UnitComponent>().Get(request.UnitId);
            if (unitplan == null)
            {
                return;
            }

            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            switch (request.OperateType)
            {
                case 1:
                    JiaYuanPlant jiaYuanPlan = jiaYuanComponent.GetJiaYuanPlant(request.UnitId);
                    if (jiaYuanPlan == null)
                    {
                        Log.Error($"jiaYuanPlan == null  {unit.Id}  {request.CellIndex}");
                        return;
                    }

                    response.Error = JiaYuanHelper.GetPlanShouHuoItem(jiaYuanPlan.ItemId, jiaYuanPlan.StartTime, jiaYuanPlan.GatherNumber, jiaYuanPlan.GatherLastTime);
                    if (response.Error != ErrorCode.ERR_Success)
                    {
                        return;
                    }

                    JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(unitplan.ConfigId);
                    unit.GetComponent<BagComponentS>().OnAddItemData($"{jiaYuanFarmConfig.GetItemID};1", $"{ItemGetWay.JiaYuanGather}_{TimeHelper.ServerNow()}");

                    unitplan.GetComponent<NumericComponentS>().ApplyValue(NumericType.GatherLastTime, TimeHelper.ServerNow());
                    unitplan.GetComponent<NumericComponentS>().ApplyChange(NumericType.GatherNumber, 1);

                    jiaYuanPlan.GatherNumber += 1;
                    jiaYuanPlan.GatherLastTime = TimeHelper.ServerNow();
                    JiaYuanRecord JiaYuanRecord = JiaYuanRecord.Create();
                    JiaYuanRecord.PlayerId = unit.Id;
                    JiaYuanRecord.Time = TimeHelper.ServerNow();
                    JiaYuanRecord.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    jiaYuanPlan.GatherRecord.Add(JiaYuanRecord) ;
                    unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.JiaYuanGatherPlant_401, 0, 1);
                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JiaYuanGatherPlant_93, 0, 1);
                    break;
                case 2:
                    JiaYuanPastures jiaYuanPasture = jiaYuanComponent.GetJiaYuanPastures(request.UnitId);
                    if (jiaYuanPasture == null)
                    {
                        Log.Error($"jiaYuanPlan == null  {unit.Id}  {request.UnitId}");
                        return;
                    }

                    response.Error = JiaYuanHelper.GetPastureShouHuoItem(jiaYuanPasture.ConfigId, jiaYuanPasture.StartTime, jiaYuanPasture.GatherNumber, jiaYuanPasture.GatherLastTime);
                    if (response.Error != ErrorCode.ERR_Success)
                    {
                        return;
                    }

                    JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(jiaYuanPasture.ConfigId);
                    unit.GetComponent<BagComponentS>().OnAddItemData($"{jiaYuanPastureConfig.GetItemID};1", $"{ItemGetWay.JiaYuanGather}_{TimeHelper.ServerNow()}");

                    unitplan.GetComponent<NumericComponentS>().ApplyValue(NumericType.GatherLastTime, TimeHelper.ServerNow());
                    unitplan.GetComponent<NumericComponentS>().ApplyChange(NumericType.GatherNumber, 1);

                    jiaYuanPasture.GatherNumber += 1;
                    jiaYuanPasture.GatherLastTime = TimeHelper.ServerNow();
                    unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.JiaYuanGatherPasture_402, 0, 1);

                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JiaYuanGatherPasture_95, 0, 1);
                    break;
            }

            UnitCacheHelper.SaveComponentCache( unit.Root(), jiaYuanComponent).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
