namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggOpenSlotHandler: MessageLocationHandler<Unit, C2M_RolePetEggOpenSlot, M2C_RolePetEggOpenSlot>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggOpenSlot request, M2C_RolePetEggOpenSlot response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            if (request.Index < 0 || request.Index >= petComponent.RolePetEggs.Count)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (petComponent.RolePetEggs[request.Index].Value3 != 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            string[] costItemsList = GlobalValueConfigCategory.Instance.Get(135).Value.Split('@');
            string costItems = costItemsList[request.Index];
            if (!unit.GetComponent<BagComponentS>().OnCostItemData(costItems))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            petComponent.RolePetEggs[request.Index].Value3 = 1;
            
            await ETTask.CompletedTask;
        }
    }
}