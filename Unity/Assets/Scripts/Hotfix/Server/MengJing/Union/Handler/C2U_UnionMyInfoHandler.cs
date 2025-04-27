using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionMyInfoHandler : MessageHandler<Scene, C2U_UnionMyInfoRequest, U2C_UnionMyInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionMyInfoRequest request, U2C_UnionMyInfoResponse response)
        {
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnionOperate, request.UnionId))
            {
                DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
                if (dBUnionInfo == null)
                {
                    response.Error = ErrorCode.ERR_Union_Not_Exist;
                    return;
                }

                List<long> allonlines = await UnitCacheHelper.GetOnLineUnits(scene.Root(), scene.Zone());

                ///1会长 2副会长  ///3长老
                for (int i = dBUnionInfo.UnionInfo.UnionPlayerList.Count - 1; i >= 0; i--)
                {
                    UnionPlayerInfo unionPlayerInfo = dBUnionInfo.UnionInfo.UnionPlayerList[i];
                    long userId = unionPlayerInfo.UserID;

                    UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), userId);
                    if (userInfoComponent == null)
                    {
                        dBUnionInfo.UnionInfo.UnionPlayerList.RemoveAt(i);
                        continue;
                    }
                    UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                    if (unionPlayerInfo.Position == 1 && unionPlayerInfo.UserID != dBUnionInfo.UnionInfo.LeaderId)
                    {
                        unionPlayerInfo.Position = 0;
                    }

                    if (unionPlayerInfo.UserID == dBUnionInfo.UnionInfo.LeaderId)
                    {
                        unionPlayerInfo.Position = 1;
                    }

                    unionPlayerInfo.Occ = unionInfoCache.Occ;
                    unionPlayerInfo.OccTwo = unionInfoCache.OccTwo; 
                    unionPlayerInfo.PlayerLevel = unionInfoCache.Lv;
                    unionPlayerInfo.PlayerName = unionInfoCache.Name;
                    unionPlayerInfo.Combat = unionInfoCache.Combat;

                    if (allonlines.Contains(userId))
                    {
                        unionPlayerInfo.LastLoginTime = 0;
                        response.OnLinePlayer.Add(userId);
                    }
                    else
                    {
                        NumericComponentS numericComponentS = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), userId);
                        unionPlayerInfo.LastLoginTime = numericComponentS.GetAsLong(NumericType.LastLoginTime);
                    }

                    if (dBUnionInfo.UnionInfo.LeaderId == userId)
                    {
                        dBUnionInfo.UnionInfo.LeaderName = unionInfoCache.Name;
                    }
                }

                long timeNow = TimeHelper.ServerNow();
                dBUnionInfo.UnionInfo.Level = Math.Max(1, dBUnionInfo.UnionInfo.Level);
                dBUnionInfo.MysteryFreshTime = 0;

                if (dBUnionInfo.UnionInfo.UnionKeJiList.Count < UnionKeJiConfigCategory.Instance.UnionQiangHuaList.Count)
                {
                    int curNumber = dBUnionInfo.UnionInfo.UnionKeJiList.Count;
                    int maxNumber = UnionKeJiConfigCategory.Instance.UnionQiangHuaList.Count;
                    for (int keji = curNumber; keji < maxNumber; keji++)
                    {
                        dBUnionInfo.UnionInfo.UnionKeJiList.Add(UnionKeJiConfigCategory.Instance.GetFristId(keji));
                    }
                }

                //检测是否有科技可以升级
                if (dBUnionInfo.UnionInfo.KeJiActiteTime > 0)
                {
                    int keijiId = dBUnionInfo.UnionInfo.UnionKeJiList[dBUnionInfo.UnionInfo.KeJiActitePos];
                    UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(keijiId);
                    long passTime = (timeNow - dBUnionInfo.UnionInfo.KeJiActiteTime) / 1000;
                    //Log.Console($"科技升级 {passTime} {unionKeJiConfig.NeedTime}");
                    if (unionKeJiConfig.NextID > 0 && passTime >= unionKeJiConfig.NeedTime)
                    {
                        dBUnionInfo.UnionInfo.UnionKeJiList[dBUnionInfo.UnionInfo.KeJiActitePos] = unionKeJiConfig.NextID;
                        dBUnionInfo.UnionInfo.KeJiActitePos = -1;
                        dBUnionInfo.UnionInfo.KeJiActiteTime = 0;
                    }
                }
                
                ///判断会长离线时间
                NumericComponentS numericComponent =
                        await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), dBUnionInfo.UnionInfo.LeaderId);

                if (dBUnionInfo.UnionInfo.JingXuanEndTime == 0 && numericComponent != null &&
                    timeNow - numericComponent.GetAsLong(NumericType.LastLoginTime) > TimeHelper.OneDay * 5)
                {
                    dBUnionInfo.UnionInfo.JingXuanEndTime = timeNow + TimeHelper.OneDay * 3;
                }

                ///判断竞选是否结束
                if (dBUnionInfo.UnionInfo.JingXuanEndTime != 0 && timeNow >= dBUnionInfo.UnionInfo.JingXuanEndTime)
                {
                    ///分配新会长
                    Log.Console("分配新会长！！");
                    List<UnionPlayerInfo> jingxuanPlayers = new List<UnionPlayerInfo>();
                    for (int i = dBUnionInfo.UnionInfo.UnionPlayerList.Count - 1; i >= 0; i--)
                    {
                        UnionPlayerInfo unionPlayerInfo = dBUnionInfo.UnionInfo.UnionPlayerList[i];
                        long userId = unionPlayerInfo.UserID;
                        if (dBUnionInfo.UnionInfo.JingXuanList.Contains(userId))
                        {
                            jingxuanPlayers.Add(unionPlayerInfo);
                        }
                    }

                    jingxuanPlayers.Sort(delegate(UnionPlayerInfo a, UnionPlayerInfo b)
                    {
                        int positiona = a.Position == 0 ? 10 : a.Position;
                        int positionb = b.Position == 0 ? 10 : b.Position;
                        int combata = a.Combat;
                        int combatb = b.Combat;

                        if (positiona == positionb)
                        {
                            return combatb - combata;
                        }
                        else
                        {
                            return positiona - positionb;
                        }
                    });
                    dBUnionInfo.UnionInfo.JingXuanList.Clear();
                    dBUnionInfo.UnionInfo.JingXuanEndTime = 0;

                    long newLeaderId = 0;
                    if (jingxuanPlayers.Count > 0)
                    {
                        newLeaderId = jingxuanPlayers[0].UserID;
                    }

                    if (newLeaderId != 0 && newLeaderId != dBUnionInfo.UnionInfo.LeaderId)
                    {
                        UnionPlayerInfo unionPlayerInfo_old =
                                UnionHelper.GetUnionPlayerInfo(dBUnionInfo.UnionInfo.UnionPlayerList, dBUnionInfo.UnionInfo.LeaderId);
                        UnionPlayerInfo unionPlayerInfo_new = UnionHelper.GetUnionPlayerInfo(dBUnionInfo.UnionInfo.UnionPlayerList, newLeaderId);

                        if (unionPlayerInfo_old != null && unionPlayerInfo_new != null)
                        {
                            long oldLeaderid = dBUnionInfo.UnionInfo.LeaderId;
                            dBUnionInfo.UnionInfo.LeaderId = newLeaderId;
                            unionPlayerInfo_new.Position = 1;
                            unionPlayerInfo_old.Position = 0;
                            dBUnionInfo.UnionInfo.LeaderName = unionPlayerInfo_new.PlayerName;
                            BroadCastHelper.NoticeUnionLeader(scene.Root(), newLeaderId, 1).Coroutine();

                            //通知旧会长
                            BroadCastHelper.NoticeUnionLeader(scene.Root(), oldLeaderid, 0).Coroutine();
                        }
                    }
                }
                response.UnionMyInfo = dBUnionInfo.UnionInfo;
                UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo).Coroutine();
            }
        }
    }
}