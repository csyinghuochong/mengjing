using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    [FriendOf(typeof(DBDayActivityInfo))]
    [FriendOf(typeof(PetComponentS))]
    [FriendOf(typeof(UserInfoComponentS))]
    public class C2A_PetMingListHandler : MessageHandler<Scene, C2A_PetMingListRequest, A2C_PetMingListResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_PetMingListRequest request, A2C_PetMingListResponse response)
        {
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.PetMine, scene.Zone()))
            {
                List<PetMingPlayerInfo> selfMinelist = new List<PetMingPlayerInfo>();

                ActivitySceneComponent activitySceneComponent = scene.GetComponent<ActivitySceneComponent>();
                List<PetMingPlayerInfo> minglist = activitySceneComponent.DBDayActivityInfo.PetMingList;

                if (TimeHelper.ServerNow() - activitySceneComponent.PetMingLastTime < TimeHelper.Minute)
                {
                    response.PetMingPlayerInfos .AddRange(activitySceneComponent.PetMingList); 
                }
                else
                {
                    activitySceneComponent.PetMingList.Clear();

                    for (int i = 0; i < minglist.Count; i++)
                    {
                        long enemyId = minglist[i].UnitId;
                        UserInfoComponentS userInfoComponentS = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), enemyId);
                        UserInfo unionInfoCache = userInfoComponentS.ChildrenDB[0] as UserInfo;
                        if (userInfoComponentS == null)
                        {
                            continue;
                        }

                        PetComponentS petComponent = await UnitCacheHelper.GetComponentCache<PetComponentS>(scene.Root(), enemyId);
                        if (petComponent == null)
                        {
                            continue;
                        }

                        int teamid = minglist[i].TeamId;
                        List<int> petconfidds = new List<int>();
                        List<long> petidlist = new List<long>();
                        for (int p = teamid * 5; p < (teamid + 1) * 5; p++)
                        {
                            RolePetInfo rolePetInfo = petComponent.GetPetInfo(petComponent.PetMingList[p]);
                            if (rolePetInfo != null)
                            {
                                petidlist.Add(rolePetInfo.Id);
                                petconfidds.Add(rolePetInfo.ConfigId);
                            }
                            else
                            {
                                petidlist.Add(0);
                                petconfidds.Add(0);
                            }
                        }

                        PetMingPlayerInfo PetMingPlayerInfo = PetMingPlayerInfo.Create();
                        PetMingPlayerInfo.MineType = minglist[i].MineType;
                        PetMingPlayerInfo.Postion = minglist[i].Postion;
                        PetMingPlayerInfo.TeamId = teamid;
                        PetMingPlayerInfo.PlayerName = unionInfoCache.Name;
                        PetMingPlayerInfo.PetConfig = petconfidds;
                        PetMingPlayerInfo.PetIdList = petidlist;
                        PetMingPlayerInfo.UnitId = minglist[i].UnitId;
                        activitySceneComponent.PetMingList.Add(PetMingPlayerInfo);
                    }

                    activitySceneComponent.PetMingLastTime = TimeHelper.ServerNow();
                    response.PetMingPlayerInfos .AddRange(activitySceneComponent.PetMingList); 
                }

                if (activitySceneComponent.DBDayActivityInfo.PetMingChanChu.ContainsKey(request.ActorId))
                {
                    response.ChanChu = activitySceneComponent.DBDayActivityInfo.PetMingChanChu[request.ActorId];
                }

                //计算自己的矿
                for (int i = 0; i < response.PetMingPlayerInfos.Count; i++)
                {
                    if (response.PetMingPlayerInfos[i].UnitId == request.ActorId)
                    {
                        selfMinelist.Add(response.PetMingPlayerInfos[i]);
                    }
                }
                // A2M_PetMingLoginRequest a2M_PetMing = new A2M_PetMingLoginRequest()
                // {
                //     UnitID = request.ActorId,
                //     PetMineList = selfMinelist,
                //     PetMingExtend = activitySceneComponent.DBDayActivityInfo.PetMingHexinList,
                // };
                //
                // M2A_PetMingLoginResponse m2G_RechargeResponse = (M2A_PetMingLoginResponse)await ActorLocationSenderComponent.Instance.Call(request.ActorId, a2M_PetMing);
                // if (m2G_RechargeResponse.Error == ErrorCode.ERR_Success)
                // {
                // }

                response.PetMineExtend.AddRange(activitySceneComponent.DBDayActivityInfo.PetMingHexinList);
            }

            await ETTask.CompletedTask;
        }
    }
}