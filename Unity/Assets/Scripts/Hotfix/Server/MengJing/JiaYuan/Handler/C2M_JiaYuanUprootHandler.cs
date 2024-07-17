namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanUprootHandler : MessageLocationHandler<Unit, C2M_JiaYuanUprootRequest, M2C_JiaYuanUprootResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanUprootRequest request, M2C_JiaYuanUprootResponse response)
        {
            Unit unitPlan = unit.GetParent<UnitComponent>().Get(request.UnitId);
            if (unitPlan == null)
            {
                return;
            }
           
            switch (request.OperateType)
            {
                case 1:
                    unit.GetComponent<JiaYuanComponentS>().UprootPlant(request.CellIndex);
                    break;
                case 2:
                    JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(unitPlan.ConfigId);
                    unit.GetComponent<BagComponentS>().OnAddItemData($"13;{jiaYuanPastureConfig.SellGold}", $"{ItemGetWay.JiaYuanGather}_{TimeHelper.ServerFrameTime()}");
                    unit.GetComponent<JiaYuanComponentS>().UprootPasture(request.UnitId);

                    break;
            }

            unit.GetParent<UnitComponent>().Remove(request.UnitId);
            response.JiaYuanPastureList .AddRange(unit.GetComponent<JiaYuanComponentS>().JiaYuanPastureList_7); 
            UnitCacheHelper.SaveComponentCache(unit.Root(),  unit.GetComponent<JiaYuanComponentS>()).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
