namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPickHandler : MessageLocationHandler<Unit, C2M_JiaYuanPickRequest, M2C_JiaYuanPickResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPickRequest request, M2C_JiaYuanPickResponse response)
        {
            Unit boxUnit = unit.GetParent<UnitComponent>().Get(request.UnitId);
            if (boxUnit == null)
            {
                response.Error = ErrorCode.ERR_PlantNotExist;
                return;
            }
            if (boxUnit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) == 1)
            {
                response.Error = ErrorCode.ERR_PlantNotExist;
                return;
            }
          
            if (unit.Id != request.MasterId)
            {
                NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                if (numericComponent.GetAsInt(NumericType.JiaYuanPickOther) >= 5)
                {
                    response.Error = ErrorCode.ERR_TimesIsNot;
                    return;
                }
            }

            boxUnit.GetComponent<HeroDataComponentS>().OnDead(unit);

            if (unit.Id == request.MasterId)
            {
                JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
                jiaYuanComponent.OnRemoveUnit(request.UnitId);

                await UnitCacheHelper.SaveComponentCache(unit.Root(), jiaYuanComponent);
            }
            else
            {
                unit.GetComponent<NumericComponentS>().ApplyChange(null, NumericType.JiaYuanPickOther, 1, 0);

                JiaYuanComponentS jiaYuanComponent_2 = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(unit.Root(), request.MasterId);
                ActorId gateServerId = UnitCacheHelper.GetGateServerId(unit.Zone());

                T2G_GateUnitInfoRequest T2G_GateUnitInfoRequest = T2G_GateUnitInfoRequest.Create();
                T2G_GateUnitInfoRequest.UserID = request.MasterId;
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (gateServerId, T2G_GateUnitInfoRequest);

                //玩家在线
                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    JiaYuanOperate jiaYuanOperate = JiaYuanOperate.Create();
                    jiaYuanOperate = JiaYuanOperate.Create();
                    jiaYuanOperate.OperateType = JiaYuanOperateType.Pick;
                    jiaYuanOperate.UnitId = request.UnitId;
                    jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    jiaYuanOperate.OperateId = boxUnit.ConfigId;
                    M2M_JiaYuanOperateMessage opmessage = M2M_JiaYuanOperateMessage.Create();
                    opmessage.JiaYuanOperate = jiaYuanOperate;
                    unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(request.MasterId, opmessage);
                }
                else
                {
                    jiaYuanComponent_2.OnRemoveUnit(request.UnitId);
                    await UnitCacheHelper.SaveComponentCache(unit.Root(),  jiaYuanComponent_2);
                }
            }
            
            response.Error = ErrorCode.ERR_Success;
            await ETTask.CompletedTask;
        }
    }
}
