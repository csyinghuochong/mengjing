namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPlantHandler : MessageLocationHandler<Unit, C2M_JiaYuanPlantRequest, M2C_JiaYuanPlantResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPlantRequest request, M2C_JiaYuanPlantResponse response)
        {
            JiaYuanComponentS jianYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            if (jianYuanComponent.GetCellPlant(request.CellIndex)!=null)
            {
                response.Error = ErrorCode.ERR_AlreadyPlant;
                return;
            }
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent.GetItemNumber(request.ItemId) < 1)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            bagComponent.OnCostItemData($"{request.ItemId};1");
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(request.ItemId);
            JiaYuanPlant jiaYuanPlant = JiaYuanPlant.Create();
            jiaYuanPlant.CellIndex = request.CellIndex;
            jiaYuanPlant.ItemId = int.Parse(itemConfig.ItemUsePar);
            jiaYuanPlant.StartTime = TimeHelper.ServerNow();
            jiaYuanPlant.UnitId = IdGenerater.Instance.GenerateId();

            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JiaYuanPlantNumber_92, 0, 1);


            jianYuanComponent.JianYuanPlantList_7.Add(jiaYuanPlant);
            Unit plan = UnitFactory.CreatePlan( unit.Scene(), jiaYuanPlant, unit.Id);
            jiaYuanPlant.UnitId = plan.Id;
            UnitCacheHelper.SaveComponentCache(unit.Root(),  unit.GetComponent<JiaYuanComponentS>()).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
