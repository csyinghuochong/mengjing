namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanWatchHandler : MessageLocationHandler<Unit, C2M_JiaYuanWatchRequest, M2C_JiaYuanWatchResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanWatchRequest request, M2C_JiaYuanWatchResponse response)
        {
            Unit boxUnit = unit.GetParent<UnitComponent>().Get(request.OperateId);
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

            if (unit.Id == request.MasterId)
            {
                JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
                JiaYuanPlant jiaYuanPlant = jiaYuanComponent.GetJiaYuanPlant(request.OperateId);

                response.JiaYuanRecord .AddRange(jiaYuanPlant.GatherRecord); 
            }
            else
            {
                JiaYuanComponentS jiaYuanComponent_2 = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(unit.Root(), request.MasterId);
                JiaYuanPlant jiaYuanPlant_2 = jiaYuanComponent_2.GetJiaYuanPlant(request.OperateId);

                response.JiaYuanRecord .AddRange(jiaYuanPlant_2.GatherRecord); 
            }
            
            await ETTask.CompletedTask;
        }
    }
}
