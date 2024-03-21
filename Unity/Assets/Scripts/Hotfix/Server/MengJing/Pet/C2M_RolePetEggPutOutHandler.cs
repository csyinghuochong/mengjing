using System;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggPutOutHandler : MessageLocationHandler<Unit, C2M_RolePetEggPutOut, M2C_RolePetEggPutOut>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggPutOut request, M2C_RolePetEggPutOut response)
        {
            PetComponentServer petComponent = unit.GetComponent<PetComponentServer>();
            KeyValuePairInt rolePetEgg = petComponent.RolePetEggs[request.Index];
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            bagComponent.OnAddItemData($"{rolePetEgg.KeyId};1", $"{ItemGetWay.PetEggDuiHuan}_{TimeHelper.ServerNow()}");
            rolePetEgg.KeyId = 0;
            rolePetEgg.Value = 0;
            response.RolePetEgg = rolePetEgg;
            await ETTask.CompletedTask;
        }
    }
}
