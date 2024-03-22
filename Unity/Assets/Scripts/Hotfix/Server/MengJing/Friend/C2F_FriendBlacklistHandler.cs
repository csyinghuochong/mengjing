using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(DBFriendInfo))]
    public class C2F_FriendBlacklistHandler: MessageHandler<Scene,C2F_FriendBlacklistRequest,  F2C_FriendBlacklistResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendBlacklistRequest request, F2C_FriendBlacklistResponse response)
        {
          
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.UnitId);
            if (dbFriendInfos == null || dbFriendInfos.Count == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            DBFriendInfo dBFriendInfo = dbFriendInfos[0];
            if (dBFriendInfo.FriendList.Contains(request.FriendId))
            {
                //在好友列表
                return;
            }

            if (request.OperateType == 1)
            {
                if (dBFriendInfo.Blacklist.Contains(request.FriendId))
                {
                    return;
                }
                dBFriendInfo.Blacklist.Add(request.FriendId);
            }
            if (request.OperateType == 2)
            {
                if (!dBFriendInfo.Blacklist.Contains(request.FriendId))
                {
                    return;
                }
                dBFriendInfo.Blacklist.Remove(request.FriendId);
            }
           
            await  dbComponent.Save(scene.Zone(), dBFriendInfo);
        }
    }
}
