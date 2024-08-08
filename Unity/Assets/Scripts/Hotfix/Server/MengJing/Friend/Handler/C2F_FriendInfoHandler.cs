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
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(root, friendId);
                if (userInfoComponent == null)
                {
                    continue;
                }

                //await  root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(friendId, new ILocationRequest());
                ChatSceneComponent chatSceneComponent = root.GetComponent<ChatSceneComponent>();
                FriendInfo FriendInfo = FriendInfo.Create();
                FriendInfo.UserId = friendId;
                FriendInfo.PlayerLevel = userInfoComponent.UserInfo.Lv;
                FriendInfo.OnLineTime = chatSceneComponent.GetChild<ChatInfoUnit>(friendId)!=null ? 1 : 0;
                FriendInfo.PlayerName = userInfoComponent.UserInfo.Name;
                FriendInfo.Occ = userInfoComponent.UserInfo.Occ;
                friendInfos.Add(FriendInfo);
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
            
            await ETTask.CompletedTask;
        }
    }
}
