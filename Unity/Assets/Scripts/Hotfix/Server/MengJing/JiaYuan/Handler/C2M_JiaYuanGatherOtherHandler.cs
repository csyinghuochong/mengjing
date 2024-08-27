namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanGatherOtherHandler : MessageLocationHandler<Unit, C2M_JiaYuanGatherOtherRequest, M2C_JiaYuanGatherOtherResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanGatherOtherRequest request, M2C_JiaYuanGatherOtherResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            Unit unitplan = unit.GetParent<UnitComponent>().Get(request.UnitId);
            if (unitplan == null)
            {
                response.Error = ErrorCode.ERR_PlantNotExist;
                return;
            }

            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.JiaYuan, unit.Id))
            {
                NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                if (numericComponent.GetAsInt(NumericType.JiaYuanGatherOther) >= 5)
                {
                    response.Error = ErrorCode.ERR_TimesIsNot;
                    return;
                }

                JiaYuanComponentS jiaYuanComponent = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(unit.Root(), request.MasterId);
                if (jiaYuanComponent == null)
                {
                    return;
                }

                JiaYuanOperate jiaYuanOperate = null;
                switch (request.OperateType)
                {
                    case 1:
                        JiaYuanPlant jiaYuanPlan = jiaYuanComponent.GetJiaYuanPlant(request.UnitId);
                        if (jiaYuanPlan == null)
                        {
                            Log.Error($"jiaYuanPlan == null  {unit.Id}  {request.CellIndex}");
                            return;
                        }
                        if (jiaYuanPlan.StealNumber >= 1)
                        {
                            response.Error = ErrorCode.ERR_JiaYuanSteal;
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
                        unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.JiaYuanGatherPlant_401, 0, 1);
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JiaYuanGatherPlant_93, 0, 1);
                        jiaYuanPlan.GatherNumber += 1;
                        jiaYuanPlan.StealNumber += 1;
                        jiaYuanPlan.GatherLastTime = TimeHelper.ServerNow();

                        jiaYuanOperate = JiaYuanOperate.Create();
                        jiaYuanOperate.OperateType = JiaYuanOperateType.GatherPlant;
                        jiaYuanOperate.UnitId = unit.Id;
                        jiaYuanOperate.MasterId = request.MasterId;
                        jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;

                        JiaYuanRecord jiaYuanRecord = JiaYuanRecord.Create();
                        jiaYuanRecord.OperateType = JiaYuanOperateType.GatherPlant;
                        jiaYuanRecord.OperateId = jiaYuanPlan.ItemId;
                        jiaYuanRecord.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                        jiaYuanRecord.Time = TimeHelper.ServerNow();
                        jiaYuanRecord.PlayerId = unit.Id;
                        jiaYuanPlan.GatherRecord.Add(jiaYuanRecord);
                        jiaYuanComponent.AddJiaYuanRecord(jiaYuanRecord);
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

                        unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.JiaYuanGatherPasture_402, 0, 1);
                        unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JiaYuanGatherPasture_95, 0, 1);
                        jiaYuanPasture.GatherNumber += 1;
                        jiaYuanPasture.StealNumber += 1;
                        jiaYuanPasture.GatherLastTime = TimeHelper.ServerNow();

                        jiaYuanOperate = JiaYuanOperate.Create();
                        jiaYuanOperate.OperateType = JiaYuanOperateType.GatherPasture;
                        jiaYuanOperate.UnitId = request.UnitId;
                        jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                        JiaYuanRecord jiaYuanRecord_1 = JiaYuanRecord.Create();
                        jiaYuanRecord_1.OperateType = JiaYuanOperateType.GatherPasture;
                        jiaYuanRecord_1.OperateId = jiaYuanPasture.ConfigId;
                        jiaYuanRecord_1.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                        jiaYuanRecord_1.Time = TimeHelper.ServerNow();
                        jiaYuanComponent.AddJiaYuanRecord(jiaYuanRecord_1);
                        break;
                }

                //玩家在线
                ActorId jiayuanactorid = UnitCacheHelper.GetJiaYuanServerId(unit.Zone());
                M2J_JiaYuanOperateRequest opmessage = M2J_JiaYuanOperateRequest.Create();
                opmessage.JiaYuanOperate = jiaYuanOperate;
                J2M_JiaYuanOperateResponse m2JJiaYuanOperateResponse = (J2M_JiaYuanOperateResponse)await unit.Root().GetComponent<MessageSender>().Call(jiayuanactorid, opmessage);
                unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.JiaYuanGatherOther,1 );
            }

            await ETTask.CompletedTask;
        }
    }
}