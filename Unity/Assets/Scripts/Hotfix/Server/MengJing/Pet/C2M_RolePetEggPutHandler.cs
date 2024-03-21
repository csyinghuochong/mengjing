using System;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggPutHandler : MessageLocationHandler<Unit, C2M_RolePetEggPut, M2C_RolePetEggPut>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggPut request, M2C_RolePetEggPut response)
        {
            PetComponentServer petComponent = unit.GetComponent<PetComponentServer>();
            KeyValuePairInt rolePetEgg = petComponent.RolePetEggs[request.Index];
            if (rolePetEgg.KeyId != 0)
            {
                return;
            }

            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
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
