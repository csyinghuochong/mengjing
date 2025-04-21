namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggOpenSlotHandler: MessageLocationHandler<Unit, C2M_RolePetEggOpenSlot, M2C_RolePetEggOpenSlot>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggOpenSlot request, M2C_RolePetEggOpenSlot response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            if (petComponent.RolePetEggUnlockedSlotsCount >= 4)
            {
                return;
            }

            string[] costItemsList = GlobalValueConfigCategory.Instance.Get(134).Value.Split('@');
            string costItems = costItemsList[petComponent.RolePetEggUnlockedSlotsCount];
            if (!unit.GetComponent<BagComponentS>().OnCostItemData(costItems))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            petComponent.RolePetEggUnlockedSlotsCount++;
            
            await ETTask.CompletedTask;
        }
    }
}