namespace ET.Server
{
    [MessageHandler(SceneType.EMail)]
    public class C2E_AccountWarehousInfoHandler : MessageHandler<Scene, C2E_AccountWarehousInfoRequest, E2C_AccountWarehousInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2E_AccountWarehousInfoRequest request, E2C_AccountWarehousInfoResponse response)
        {
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount, request.AccInfoID))
            {
                DBAccountBagInfo dBAccountWarehouse = await UnitCacheHelper.GetComponent<DBAccountBagInfo>(scene.Root(), request.AccInfoID);
                if (dBAccountWarehouse != null)
                {
                    foreach (ItemInfo itemInfo in dBAccountWarehouse.BagInfoList)
                    {
                        response.BagInfos.Add(itemInfo.ToMessage());
                    }
                }
                else
                {
                    DBAccountBagInfo dBAccountBagInfo = scene.AddChildWithId<DBAccountBagInfo>(request.AccInfoID);
                    UnitCacheHelper.SaveComponent(scene.Root(), request.AccInfoID, dBAccountBagInfo).Coroutine();

                    foreach (ItemInfo itemInfo in dBAccountWarehouse.BagInfoList)
                    {
                        response.BagInfos.Add(itemInfo.ToMessage());
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}