namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggPutHandler : MessageLocationHandler<Unit, C2M_RolePetEggPut, M2C_RolePetEggPut>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggPut request, M2C_RolePetEggPut response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();

            if (request.Index < 0 || request.Index >= petComponent.RolePetEggs.Count)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (petComponent.RolePetEggs[request.Index].Value3 == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            
            KeyValuePairLong4 rolePetEgg = petComponent.RolePetEggs[request.Index];
            if (rolePetEgg.KeyId != 0)
            {
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            ItemInfo useBagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoId);
            if (useBagInfo == null)
            {
                return;
            }
            
            bagComponent.OnCostItemData(request.BagInfoId, 1);
            rolePetEgg.KeyId = useBagInfo.ItemID;   //道具Id
            rolePetEgg.Value = 0;                   //孵化時間
            rolePetEgg.Value2 = useBagInfo.FuLing;  //附灵
  
            response.RolePetEgg = rolePetEgg;
            await ETTask.CompletedTask;
        }
    }
}
