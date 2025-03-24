namespace ET.Server
{

    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(NumericComponentS))]
    public class C2F_WatchPetHandler : MessageHandler<Scene, C2F_WatchPetRequest, F2C_WatchPetResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_WatchPetRequest request, F2C_WatchPetResponse response)
        {
            PetComponentS petComponent = await UnitCacheHelper.GetComponentCache<PetComponentS>(scene.Root(), request.UnitID);
            if (petComponent == null)
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }
            
            BagComponentS bagComponents = await UnitCacheHelper.GetComponentCache<BagComponentS>(scene.Root(), request.UnitID);
            bagComponents.DeserializeDB();
            response.RolePetInfos = petComponent.GetPetInfo( request.PetId );
            foreach (ItemInfo itemInfo in bagComponents.GetItemByLoc(ItemLocType.ItemPetHeXinEquip))
            {
                response.PetHeXinList.Add(itemInfo.ToMessage());
            }

            NumericComponentS numericComponent =  await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), request.UnitID);
            foreach ((int key, long value) in numericComponent.NumericDic)
            {
                if (key >= (int)NumericType.Max)
                {
                    continue;
                }
                response.Ks.Add(key);
                response.Vs.Add(value);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
