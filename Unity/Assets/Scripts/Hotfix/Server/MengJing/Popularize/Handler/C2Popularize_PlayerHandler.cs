using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2Popularize_PlayerHandler : MessageHandler<Scene, C2Popularize_PlayerRequest, Popularize2C_PlayerResponse>
    {
        protected override async ETTask Run(Scene scene, C2Popularize_PlayerRequest request, Popularize2C_PlayerResponse response)
        {
            Log.Warning($"C2Popularize_PlayerRequest:{request.ActorId}");
            using (await  scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Popularize, request.ActorId))
            {
                DBPopularizeInfo dBPopularizeInfo = await UnitCacheHelper.GetComponent<DBPopularizeInfo>(scene.Root(), request.ActorId);
                if (dBPopularizeInfo == null)
                {
                    return;
                }
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), request.ActorId);
                UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                if (userInfoComponent == null)
                {
                    return;
                }

                int oldzone = (int)request.PopularizeId / 1000000;
                int xuhao = (int)request.PopularizeId % 1000000;
                int newzone = ServerHelper.GetNewServerId(oldzone);
                if (newzone < 5)
                {
                    return;
                }
                if (newzone > ConfigData.ServerItems.Count + 10)
                {
                    Log.Warning($"C2Popularize_PlayerRequest: {request.PopularizeId}");
                    return;
                }

                DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
                DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
                
                List<DBPopularizeInfo> dBPopularizeInfoList = await dbComponent.Query<DBPopularizeInfo>(newzone, d => d.PopularizeCode == request.PopularizeId);
                if (dBPopularizeInfoList.Count == 0)
                {
                    response.Error = ErrorCode.ERR_PopularizeNot;
                    return;
                }

                long puserid = dBPopularizeInfoList[0].Id;
                UserInfoComponentS userInfoComponent_2 = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), puserid);
                UserInfo unionInfoCache_2 = userInfoComponent_2.ChildrenDB[0] as UserInfo;
                if (userInfoComponent_2 == null)
                {
                    response.Error = ErrorCode.ERR_PopularizeNot;
 
                    return;
                }
                if (unionInfoCache.AccInfoID == unionInfoCache_2.AccInfoID)
                {
                    response.Error = ErrorCode.ERR_PopularizeThe;
                    return;
                }

                if (dBPopularizeInfoList[0].MyPopularizeList.Count >= 10)
                {
                    response.Error = ErrorCode.ERR_PopularizeMax;
                    return;
                }

                PopularizeInfo PopularizeInfo = PopularizeInfo.Create();
                PopularizeInfo.UnitId = request.ActorId;
                dBPopularizeInfoList[0].MyPopularizeList.Add(PopularizeInfo);
                await UnitCacheHelper.SaveComponent(scene.Root(), dBPopularizeInfoList[0].Id, dBPopularizeInfoList[0]);

                dBPopularizeInfo.BePopularizeId = request.PopularizeId;
                await UnitCacheHelper.SaveComponent(scene.Root(), dBPopularizeInfo.Id, dBPopularizeInfo);

            }
        }
    }
}
