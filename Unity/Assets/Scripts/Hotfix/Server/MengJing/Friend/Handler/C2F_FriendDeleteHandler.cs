using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(DBFriendInfo))]
    public class C2F_FriendDeleteHandler: MessageHandler<Scene,C2F_FriendDeleteRequest,  F2C_FriendDeleteResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendDeleteRequest request, F2C_FriendDeleteResponse response)
        {
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.UnitId);
            if (dbFriendInfos == null || dbFriendInfos.Count == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            DBFriendInfo dBFriendInfo = dbFriendInfos[0];
            
            if (dBFriendInfo == null || !dBFriendInfo.FriendList.Contains(request.FriendID))
            {
                return;
            }

            dBFriendInfo.FriendList.Remove(request.FriendID);
            await dbComponent.Save(scene.Zone(), dBFriendInfo);
            
            List<DBFriendInfo> dbFriendInfosOther = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.FriendID);
            if (dbFriendInfosOther.Count > 0)
            {
                DBFriendInfo dBFriendInfo_2 = dbFriendInfosOther[0];
                dBFriendInfo_2.FriendList.Remove(request.FriendID);
                await dbComponent.Save(scene.Zone(), dBFriendInfo_2);
            }
            await ETTask.CompletedTask;
        }
    }
}
