﻿using System;
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 家园偷取
    /// </summary>
    [ActorMessageHandler]
    public class C2M_JiaYuanGatherOtherHandler : AMActorLocationRpcHandler<Unit, C2M_JiaYuanGatherOtherRequest, M2C_JiaYuanGatherOtherResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanGatherOtherRequest request, M2C_JiaYuanGatherOtherResponse response, Action reply)
        {
            if (unit.GetComponent<BagComponent>().GetBagLeftCell() < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                reply();
                return;
            }
            Unit unitplan = unit.GetParent<UnitComponent>().Get(request.UnitId);
            if (unitplan == null)
            {
                response.Error = ErrorCode.ERR_PlantNotExist;
                reply();
                return;
            }

            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.JiaYuan, unit.Id))
            {
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                if (numericComponent.GetAsInt(NumericType.JiaYuanGatherOther) >= 5)
                {
                    response.Error = ErrorCode.ERR_TimesIsNot;
                    reply();
                    return;
                }

                JiaYuanComponent jiaYuanComponent = await DBHelper.GetComponentCache<JiaYuanComponent>(unit.DomainZone(), request.MasterId);
                if (jiaYuanComponent == null)
                {
                    reply();
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
                            reply();
                            return;
                        }
                        if (jiaYuanPlan.StealNumber >= 1)
                        {
                            response.Error = ErrorCode.ERR_JiaYuanSteal;
                            reply();
                            return;
                        }

                        response.Error = JiaYuanHelper.GetPlanShouHuoItem(jiaYuanPlan.ItemId, jiaYuanPlan.StartTime, jiaYuanPlan.GatherNumber, jiaYuanPlan.GatherLastTime);
                        if (response.Error != ErrorCode.ERR_Success)
                        {
                            reply();
                            return;
                        }

                        JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(unitplan.ConfigId);
                        unit.GetComponent<BagComponent>().OnAddItemData($"{jiaYuanFarmConfig.GetItemID};1", $"{ItemGetWay.JiaYuanGather}_{TimeHelper.ServerNow()}");

                        unitplan.GetComponent<NumericComponent>().ApplyValue(NumericType.GatherLastTime, TimeHelper.ServerNow());
                        unitplan.GetComponent<NumericComponent>().ApplyChange(null, NumericType.GatherNumber, 1, 0);
                        unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.JiaYuanGatherPlant_401, 0, 1);
                        unit.GetComponent<TaskComponent>().TriggerTaskEvent(TaskTargetType.JiaYuanGatherPlant_93, 0, 1);
                        unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.JiaYuanGatherPlant_93, 0, 1);
                        jiaYuanPlan.GatherNumber += 1;
                        jiaYuanPlan.StealNumber += 1;
                        jiaYuanPlan.GatherLastTime = TimeHelper.ServerNow();

                        jiaYuanOperate  = new JiaYuanOperate();
                        jiaYuanOperate.OperateType = JiaYuanOperateType.GatherPlant;
                        jiaYuanOperate.UnitId = request.UnitId;
                        jiaYuanOperate.PlayerId = unit.Id;
                        jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponent>().UserInfo.Name;

                        JiaYuanRecord jiaYuanRecord = new JiaYuanRecord()
                        {
                            OperateType = JiaYuanOperateType.GatherPlant,
                            OperateId = jiaYuanPlan.ItemId,
                            PlayerName = unit.GetComponent<UserInfoComponent>().UserInfo.Name,
                            Time = TimeHelper.ServerNow(),
                            PlayerId = unit.Id,
                        };
                        jiaYuanPlan.GatherRecord.Add(jiaYuanRecord);
                        jiaYuanComponent.AddJiaYuanRecord(jiaYuanRecord);
                        break;
                    case 2:
                        JiaYuanPastures jiaYuanPasture = jiaYuanComponent.GetJiaYuanPastures(request.UnitId);
                        if (jiaYuanPasture == null)
                        {
                            Log.Error($"jiaYuanPlan == null  {unit.Id}  {request.UnitId}");
                            reply();
                            return;
                        }

                        response.Error = JiaYuanHelper.GetPastureShouHuoItem(jiaYuanPasture.ConfigId, jiaYuanPasture.StartTime, jiaYuanPasture.GatherNumber, jiaYuanPasture.GatherLastTime);
                        if (response.Error != ErrorCode.ERR_Success)
                        {
                            reply();
                            return;
                        }

                        JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(jiaYuanPasture.ConfigId);
                        unit.GetComponent<BagComponent>().OnAddItemData($"{jiaYuanPastureConfig.GetItemID};1", $"{ItemGetWay.JiaYuanGather}_{TimeHelper.ServerNow()}");

                        unitplan.GetComponent<NumericComponent>().ApplyValue(NumericType.GatherLastTime, TimeHelper.ServerNow());
                        unitplan.GetComponent<NumericComponent>().ApplyChange(null, NumericType.GatherNumber, 1, 0);

                        unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.JiaYuanGatherPasture_402, 0, 1);
                        unit.GetComponent<TaskComponent>().TriggerTaskEvent(TaskTargetType.JiaYuanGatherPasture_95, 0, 1);
                        unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.JiaYuanGatherPasture_95, 0, 1);
                        jiaYuanPasture.GatherNumber += 1;
                        jiaYuanPasture.StealNumber += 1;
                        jiaYuanPasture.GatherLastTime = TimeHelper.ServerNow();

                        jiaYuanOperate = new JiaYuanOperate();
                        jiaYuanOperate.OperateType = JiaYuanOperateType.GatherPasture;
                        jiaYuanOperate.UnitId = request.UnitId;
                        jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponent>().UserInfo.Name;
                        JiaYuanRecord jiaYuanRecord_1 = new JiaYuanRecord()
                        {
                            OperateType = JiaYuanOperateType.GatherPasture,
                            OperateId = jiaYuanPasture.ConfigId,
                            PlayerName = unit.GetComponent<UserInfoComponent>().UserInfo.Name,
                            Time = TimeHelper.ServerNow(),
                        };
                        jiaYuanComponent.AddJiaYuanRecord(jiaYuanRecord_1);
                        break;
                }


                long gateServerId = DBHelper.GetGateServerId(unit.DomainZone());
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await ActorMessageSenderComponent.Instance.Call
                    (gateServerId, new T2G_GateUnitInfoRequest()
                    {
                        UserID = request.MasterId
                    });

                //玩家在线
                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    M2M_JiaYuanOperateMessage opmessage = new M2M_JiaYuanOperateMessage()
                    {
                        JiaYuanOperate = jiaYuanOperate,
                    };
                    MessageHelper.SendToLocationActor(request.MasterId, opmessage);
                }
                else
                {
                    await DBHelper.SaveComponentCache(unit.DomainZone(), request.MasterId, jiaYuanComponent);
                }
               
                unit.GetComponent<NumericComponent>().ApplyChange( null, NumericType.JiaYuanGatherOther,1, 0 );
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}