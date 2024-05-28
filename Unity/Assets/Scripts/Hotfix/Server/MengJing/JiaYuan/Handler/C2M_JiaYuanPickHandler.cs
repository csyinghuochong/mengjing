﻿using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPickHandler : MessageLocationHandler<Unit, C2M_JiaYuanPickRequest, M2C_JiaYuanPickResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPickRequest request, M2C_JiaYuanPickResponse response, Action reply)
        {
            Unit boxUnit = unit.GetParent<UnitComponent>().Get(request.UnitId);
            if (boxUnit == null)
            {
                response.Error = ErrorCode.ERR_PlantNotExist;
                reply();
                return;
            }
            if (boxUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Now_Dead) == 1)
            {
                response.Error = ErrorCode.ERR_PlantNotExist;
                reply();
                return;
            }
          
            if (unit.Id != request.MasterId)
            {
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                if (numericComponent.GetAsInt(NumericType.JiaYuanPickOther) >= 5)
                {
                    response.Error = ErrorCode.ERR_TimesIsNot;
                    reply();
                    return;
                }
            }

            boxUnit.GetComponent<HeroDataComponent>().OnDead(unit);

            if (unit.Id == request.MasterId)
            {
                JiaYuanComponent jiaYuanComponent = unit.GetComponent<JiaYuanComponent>();
                jiaYuanComponent.OnRemoveUnit(request.UnitId);

                await DBHelper.SaveComponentCache(unit.DomainZone(), unit.Id, jiaYuanComponent);
            }
            else
            {
                unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.JiaYuanPickOther, 1, 0);

                JiaYuanComponent jiaYuanComponent_2 = await DBHelper.GetComponentCache<JiaYuanComponent>(unit.DomainZone(), request.MasterId);
                long gateServerId = DBHelper.GetGateServerId(unit.DomainZone());
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await ActorMessageSenderComponent.Instance.Call
                    (gateServerId, new T2G_GateUnitInfoRequest()
                    {
                        UserID = request.MasterId
                    });

                //玩家在线
                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    JiaYuanOperate jiaYuanOperate = new JiaYuanOperate();
                    jiaYuanOperate = new JiaYuanOperate();
                    jiaYuanOperate.OperateType = JiaYuanOperateType.Pick;
                    jiaYuanOperate.UnitId = request.UnitId;
                    jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponent>().UserInfo.Name;
                    jiaYuanOperate.OperateId = boxUnit.ConfigId;
                    M2M_JiaYuanOperateMessage opmessage = new M2M_JiaYuanOperateMessage()
                    {
                        JiaYuanOperate = jiaYuanOperate,
                    };
                    MessageHelper.SendToLocationActor(request.MasterId, opmessage);
                }
                else
                {
                    jiaYuanComponent_2.OnRemoveUnit(request.UnitId);
                    await DBHelper.SaveComponentCache(unit.DomainZone(), request.MasterId, jiaYuanComponent_2);
                }
            }
            
            response.Error = ErrorCode.ERR_Success;
            reply();
            await ETTask.CompletedTask;
        }
    }
}
