namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggPutHandler : MessageLocationHandler<Unit, C2M_RolePetEggPut, M2C_RolePetEggPut>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggPut request, M2C_RolePetEggPut response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            KeyValuePairInt rolePetEgg = petComponent.RolePetEggs[request.Index];
            if (rolePetEgg.KeyId != 0)
            {
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            BagInfo useBagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoId);
            if (useBagInfo == null)
            {
                return;
            }
            
            bagComponent.OnCostItemData(request.BagInfoId, 1);
            rolePetEgg.KeyId = useBagInfo.ItemID;
            rolePetEgg.Value = 0;
            response.RolePetEgg = rolePetEgg;
            await ETTask.CompletedTask;
        }
    }
}
