using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(DBFriendInfo))]
    public class C2F_FriendInfoHandler: MessageHandler<Scene,C2F_FriendInfoRequest,  F2C_FriendInfoResponse>
    {
        
        public static async ETTask<List<FriendInfo>> GetFriendInfos(Scene root, List<long> friends)
        {
            List<FriendInfo> friendInfos = new List < FriendInfo >();
            for (int i = 0; i < friends.Count; i++)
            {
                long friendId = friends[i];
                UserInfoComponent_S userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponent_S>(root, friendId);
                if (userInfoComponent == null)
                {
                    continue;
                }

                //await  root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(friendId, new ILocationRequest());

                friendInfos.Add(new FriendInfo()
                {
                    UserId = friendId,
                    PlayerLevel = userInfoComponent.UserInfo.Lv,
                    //OnLineTime = g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0  ? 1 : 0,
                    PlayerName = userInfoComponent.UserInfo.Name,
                    Occ = userInfoComponent.UserInfo.Occ
                });
            }

            return friendInfos;
        }
        
        protected override async ETTask Run(Scene scene, C2F_FriendInfoRequest request, F2C_FriendInfoResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.UnitId);
            if (dbFriendInfos == null || dbFriendInfos.Count == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            DBFriendInfo dBFriendInfo = dbFriendInfos[0];
            
            response.FriendList = await GetFriendInfos( scene, dBFriendInfo.FriendList);
            response.ApplyList = await GetFriendInfos( scene,dBFriendInfo.ApplyList);
            response.Blacklist = await GetFriendInfos( scene,dBFriendInfo.Blacklist);


            ListComponent<long> friendids = ListComponent<long>.Create();
            for (int k = 0; k < response.FriendList.Count; k++)
            {
                friendids.Add(response.FriendList[k].UserId);
            }

            for (int i = dBFriendInfo.FriendChats.Count - 1;i >= 0; i-- )
            {
                if (!friendids.Contains(dBFriendInfo.FriendChats[i].UserId))
                {
                    dBFriendInfo.FriendChats.RemoveAt(i);   
                }
            }

            response.FriendChats = dBFriendInfo.FriendChats;

            if (response.FriendList.Count == 0)
            {
                response.FriendList.Add(new FriendInfo()
                {
                    PlayerName = "玩家1",
                    Occ = 1,
                    PlayerLevel = 1,
                    UserId = IdGenerater.Instance.GenerateId(),
                });
                response.FriendList.Add(new FriendInfo()
                {
                    PlayerName = "玩家2",
                    Occ = 1,
                    PlayerLevel = 1,
                    UserId = IdGenerater.Instance.GenerateId(),
                });
                
            }

           
            await ETTask.CompletedTask;
        }
    }
}
