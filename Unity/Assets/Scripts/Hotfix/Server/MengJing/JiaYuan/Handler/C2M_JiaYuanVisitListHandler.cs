using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanVisitListHandler : MessageLocationHandler<Unit, C2M_JiaYuanVisitListRequest, M2C_JiaYuanVisitListResponse>
    {

        private async ETTask<JiaYuanVisit> GetJiaYuanVisit(Scene root, long id)
        {
            DBManagerComponent dbManagerComponent = root.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(root.Zone());
            
            List<JiaYuanComponentS> resultJiaYuan = await dbComponent.Query<JiaYuanComponentS>(root.Zone(), _account => _account.Id == id);
            if (resultJiaYuan == null || resultJiaYuan.Count == 0)
            {
                return null;
            }

            List<UserInfoComponentS> resultUser = await dbComponent.Query<UserInfoComponentS>(root.Zone(), _account => _account.Id == id);
            if (resultUser[0].UserInfo.Lv < 10)
            {
                return null;
            }

            UserInfo userInfo = resultUser[0].ChildrenDB[0] as UserInfo;
            JiaYuanVisit jiaYuanVisit = JiaYuanVisit.Create();
            jiaYuanVisit.Occ = userInfo.Occ;
            jiaYuanVisit.OccTwo = userInfo.OccTwo;
            jiaYuanVisit.PlayerName = userInfo.Name;
            jiaYuanVisit.UnitId = resultJiaYuan[0].Id;
            jiaYuanVisit.Rubbish = resultJiaYuan[0].GetRubbishNumber();
            jiaYuanVisit.Gather = resultJiaYuan[0].GetCanGatherNumber();
            return jiaYuanVisit;
        }

        protected override async ETTask Run(Unit unit, C2M_JiaYuanVisitListRequest request, M2C_JiaYuanVisitListResponse response)
        {
            Log.Warning($"C2M_JiaYuanVisitListRequest:{request.ActorId}");
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.JiaYuan, unit.Id))
            {
                JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
                if (request.OperateType == 1)
                {
                    if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.JiaYuanVisitRefresh) >= 3)
                    {
                        return;
                    }
                    unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.JiaYuanVisitRefresh, 1);
                    jiaYuanComponent.JiaYuanFuJinTime_3 = 0;
                }


                DBFriendInfo dBFriendInfo = await UnitCacheHelper.GetComponent<DBFriendInfo>(unit.Root(), unit.Id);

                List<long> friendList = new List<long>();
                if (dBFriendInfo != null)
                {
                    friendList = dBFriendInfo.FriendList;
                    for (int i = 0; i < friendList.Count; i++)
                    {
                        if (friendList[i] == unit.Id)
                        {
                            continue;
                        }
                        JiaYuanVisit jiaYuanVisit = await GetJiaYuanVisit(unit.Root(), friendList[i]);
                        if (jiaYuanVisit != null)
                        {
                            response.JiaYuanVisit_1.Add(jiaYuanVisit);
                        }
                    }
                }

                //if (TimeHelper.ServerNow() - jiaYuanComponent.JiaYuanFuJinTime_3 > TimeHelper.Hour * 4)
                if (TimeHelper.ServerNow() - jiaYuanComponent.JiaYuanFuJinTime_3 > TimeHelper.Second * 4)
                {
                    jiaYuanComponent.JiaYuanFuJins_3.Clear();
                    M2M_AllPlayerListRequest M2M_AllPlayerListRequest = M2M_AllPlayerListRequest.Create();
                    ActorId mapInstanceId = UnitCacheHelper.MainCityServerId(unit.Zone());
                    M2M_AllPlayerListResponse reqEnter = (M2M_AllPlayerListResponse)await  unit.Root().GetComponent<MessageSender>().Call(mapInstanceId, M2M_AllPlayerListRequest);
                    List<long> allPlayers = new List<long>();
                    if (reqEnter.Error == ErrorCode.ERR_Success)
                    {
                        allPlayers = reqEnter.AllPlayers;
                    }

                    for (int i = allPlayers.Count - 1; i >= 0; i--)
                    {
                        if (allPlayers[i] == unit.Id || allPlayers[i] == request.MasterId)
                        {
                            allPlayers.RemoveAt(i);
                            continue;
                        }
                        if (friendList.Contains(allPlayers[i]))
                        {
                            allPlayers.RemoveAt(i);
                            continue;
                        }
                    }

                    List<long> destUserinfos = new List<long>();
                    RandomHelper.GetRandListByCount(allPlayers, destUserinfos, Math.Min(allPlayers.Count, 3));
                    jiaYuanComponent.JiaYuanFuJinTime_3 = TimeHelper.ServerNow();
                    jiaYuanComponent.JiaYuanFuJins_3 = destUserinfos;
                }

                for (int i = 0; i < jiaYuanComponent.JiaYuanFuJins_3.Count; i++)
                {
                    JiaYuanVisit jiaYuanVisit = await GetJiaYuanVisit(unit.Root(), jiaYuanComponent.JiaYuanFuJins_3[i]);
                    if (jiaYuanVisit != null)
                    {
                        response.JiaYuanVisit_2.Add(jiaYuanVisit);
                    }
                }
            }    
            await ETTask.CompletedTask;
        }
    }
}
