using System;
using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(DBFriendInfo))]
    public class C2F_FriendInfoHandler: MessageHandler<Scene,C2F_FriendInfoRequest,  F2C_FriendInfoResponse>
    {

        protected override async ETTask Run(Scene scene, C2F_FriendInfoRequest request, F2C_FriendInfoResponse response)
        {
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.UnitId);
            if (dbFriendInfos == null || dbFriendInfos.Count == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            DBFriendInfo dBFriendInfo = dbFriendInfos[0];

            Console.WriteLine($"C2F_FriendInfoHandler.dBFriendInfo111");

            List<long> allonline = await UnitCacheHelper.GetOnLineUnits(scene.Root(), scene.Zone());

            Console.WriteLine($"C2F_FriendInfoHandler.allonline:  {allonline.Count}");

            dBFriendInfo.FriendList.RemoveAll(item => item == 0);
            dBFriendInfo.ApplyList.RemoveAll(item => item == 0);
            dBFriendInfo.Blacklist.RemoveAll(item => item == 0);
            await dbComponent.Save(scene.Zone(), dBFriendInfo);

            response.FriendList = await GetFriendInfos( scene.Root(), dBFriendInfo.FriendList, allonline);

            Console.WriteLine($"C2F_FriendInfoHandler. response.FriendList:  {response.FriendList.Count}");

            response.ApplyList = await GetFriendInfos( scene.Root(),dBFriendInfo.ApplyList, allonline);
            response.Blacklist = await GetFriendInfos( scene.Root(),dBFriendInfo.Blacklist, allonline);
            
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

        public static async ETTask<List<FriendInfo>> GetFriendInfos(Scene root, List<long> friends, List<long> onlines)
        {
            List<FriendInfo> friendInfos = new List<FriendInfo>();
            for (int i = 0; i < friends.Count; i++)
            {
                long friendId = friends[i];
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(root, friendId);


                if (userInfoComponent == null)
                {
                    Console.WriteLine($"userInfoComponent == nul:  {friendId}");
                    continue;
                }
                if (userInfoComponent.ChildrenDB == null )
                {
                    Console.WriteLine($"userInfoComponent.ChildrenDB == nul:  {friendId}");
                    continue;
                }
                if ( userInfoComponent.ChildrenDB.Count < 1)
                {
                    Console.WriteLine($"userInfoComponent.ChildrenDB.Count < 1:  {friendId}");
                    continue;
                }

                UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                if (userInfoComponent == null)
                {
                    continue;
                }

                //await  root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(friendId, new ILocationRequest());
               
                FriendInfo FriendInfo = FriendInfo.Create();
                FriendInfo.UserId = friendId;
                FriendInfo.PlayerLevel = unionInfoCache.Lv;
                FriendInfo.OnLineTime = onlines.Contains(friendId) ? 1 : 0;
                FriendInfo.PlayerName = unionInfoCache.Name;
                FriendInfo.Occ = unionInfoCache.Occ;
                friendInfos.Add(FriendInfo);
            }

            return friendInfos;
        }

        
    }
}
