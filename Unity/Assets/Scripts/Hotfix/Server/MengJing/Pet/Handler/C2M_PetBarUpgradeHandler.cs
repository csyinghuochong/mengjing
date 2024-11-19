namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetBarUpgradeHandler : MessageLocationHandler<Unit, C2M_PetBarUpgradeRequest, M2C_PetBarUpgradeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetBarUpgradeRequest request, M2C_PetBarUpgradeResponse response)
        {
            if (request.Index < 1 || request.Index > 3)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            int nowConfig = petComponentS.PetBarConfigList[request.Index - 1];
            if (!PetBarConfigCategory.Instance.Contain(nowConfig + 1))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            PetBarConfig petBarConfig = PetBarConfigCategory.Instance.Get(nowConfig + 1);
            BagComponentS bagComponents = unit.GetComponent<BagComponentS>();
            if (!bagComponents.OnCostItemData(petBarConfig.CostItems))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            petComponentS.PetBarConfigList[request.Index - 1] = nowConfig + 1;
            // TODO 加属性

            await ETTask.CompletedTask;
        }
    }
}