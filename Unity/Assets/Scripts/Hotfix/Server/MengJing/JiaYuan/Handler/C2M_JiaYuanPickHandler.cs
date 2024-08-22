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
                unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.JiaYuanPickOther, 1);

                JiaYuanComponentS jiaYuanComponent_2 = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(unit.Root(), request.MasterId);

                JiaYuanOperate jiaYuanOperate = JiaYuanOperate.Create();
                jiaYuanOperate = JiaYuanOperate.Create();
                jiaYuanOperate.OperateType = JiaYuanOperateType.Pick;
                jiaYuanOperate.UnitId = request.UnitId;
                jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                jiaYuanOperate.OperateId = boxUnit.ConfigId;
                ActorId jiayuanactor = UnitCacheHelper.GetJiaYuanServerId(unit.Zone());
                M2J_JiaYuanOperateRequest opmessage = M2J_JiaYuanOperateRequest.Create();
                opmessage.JiaYuanOperate = jiaYuanOperate;
                J2M_JiaYuanOperateResponse m2JJiaYuanOperateResponse = (J2M_JiaYuanOperateResponse) await unit.Root().GetComponent<MessageSender>().Call(jiayuanactor, opmessage);
                if (m2JJiaYuanOperateResponse.Error != ErrorCode.ERR_Success)
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
