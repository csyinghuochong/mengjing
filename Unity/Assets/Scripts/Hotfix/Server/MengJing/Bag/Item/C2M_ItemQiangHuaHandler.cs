namespace ET.Server
{

    [FriendOf(typeof(BagComponentS))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemQiangHuaHandler: MessageLocationHandler<Unit, C2M_ItemQiangHuaRequest, M2C_ItemQiangHuaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemQiangHuaRequest request, M2C_ItemQiangHuaResponse response)
        {
            int maxLevel = QiangHuaHelper.GetQiangHuaMaxLevel(request.WeiZhi);
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent.QiangHuaLevel[request.WeiZhi] >= maxLevel - 1)
            {
                return;
            }

            EquipQiangHuaConfig equipQiangHuaConfig = QiangHuaHelper.GetQiangHuaConfig(request.WeiZhi, bagComponent.QiangHuaLevel[request.WeiZhi]);
            string costItems = equipQiangHuaConfig.CostItem;
            costItems += $"@1;{equipQiangHuaConfig.CostGold}";

            if (request.UseLucky)
            {
                costItems += string.Format("@{0};1", ConfigData.QiangHuaLuckyCostId);
            }

            if (!bagComponent.OnCostItemData(costItems))
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            double addPro = equipQiangHuaConfig.AdditionPro * bagComponent.QiangHuaFails[request.WeiZhi];
            if ((float)equipQiangHuaConfig.SuccessPro + addPro >= RandomHelper.RandFloat01())
            {
                bagComponent.QiangHuaLevel[request.WeiZhi]++;
                bagComponent.QiangHuaFails[request.WeiZhi] = 0;
            }
            else
            {
                bagComponent.QiangHuaFails[request.WeiZhi] += request.UseLucky ? 2 : 1;
            }
            response.QiangHuaLevel = bagComponent.QiangHuaLevel[request.WeiZhi];
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.QiangHuaLevel_17, 0, response.QiangHuaLevel);
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            await ETTask.CompletedTask;
        }
    }
}