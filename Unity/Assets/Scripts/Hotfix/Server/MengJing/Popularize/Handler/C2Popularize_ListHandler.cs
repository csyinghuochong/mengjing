using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Popularize)]
    public class C2Popularize_ListHandler : MessageHandler<Scene, C2Popularize_ListRequest, Popularize2C_ListResponse>
    {
        protected override async ETTask Run(Scene scene, C2Popularize_ListRequest request, Popularize2C_ListResponse response)
        {
            Log.Warning($"C2Popularize_ListRequest:{request.ActorId}");
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Popularize, scene.Zone()))
            {
                
                DBPopularizeInfo dBPopularizeInfo = await UnitCacheHelper.GetComponent<DBPopularizeInfo>(scene.Root(), request.ActorId);
                if (dBPopularizeInfo == null)
                {
                    if (scene.GetChild<DBPopularizeInfo>(request.ActorId) != null)
                    {
                        return;
                    }

                    dBPopularizeInfo = scene.AddChildWithId<DBPopularizeInfo>(request.ActorId);

                    int newzone = scene.Zone();

                    DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
                    DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
                    
                    List<DBPopularizeInfo> dBPopularizeInfoList = await dbComponent.Query<DBPopularizeInfo>(newzone, d => d.Id > 0);
                    int xuindex = dBPopularizeInfoList.Count + 1;

                    //推广码生成规则
                    dBPopularizeInfo.PopularizeCode = newzone * 1000000 + xuindex;

                    await UnitCacheHelper.SaveComponent(scene.Root(), request.ActorId, dBPopularizeInfo);
                    dBPopularizeInfo.Dispose();
                }

                for (int i = 0; i < dBPopularizeInfo.MyPopularizeList.Count; i++)
                {
                    long unitid = dBPopularizeInfo.MyPopularizeList[i].UnitId;
                    
                    UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), unitid);
                    UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                    if (userInfoComponent == null)
                    {
                        continue;
                    }

                    dBPopularizeInfo.MyPopularizeList[i].Nmae = unionInfoCache.Name;
                    dBPopularizeInfo.MyPopularizeList[i].Level = unionInfoCache.Lv;
                    dBPopularizeInfo.MyPopularizeList[i].Occ = unionInfoCache.Occ;
                    dBPopularizeInfo.MyPopularizeList[i].OccTwo = unionInfoCache.OccTwo;
                }

                response.PopularizeCode = dBPopularizeInfo.PopularizeCode;
                response.BePopularizeId = dBPopularizeInfo.BePopularizeId;
                response.MyPopularizeList .AddRange(dBPopularizeInfo.MyPopularizeList); 

            }
            await ETTask.CompletedTask;
        }
    }
}
