using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(DBFriendInfo))]
    public class C2F_FriendChatReadHandler: MessageHandler<Scene,C2F_FriendChatRead,  F2C_FriendChatRead>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendChatRead request, F2C_FriendChatRead response)
        {
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.UnitId);
            if (dbFriendInfos == null || dbFriendInfos.Count == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            DBFriendInfo dBFriendInfo = dbFriendInfos[0];
            for (int i = dBFriendInfo.FriendChats.Count - 1; i >= 0; i-- )
            {
                if (dBFriendInfo.FriendChats[i].UserId == request.FriendID)
                {
                    dBFriendInfo.FriendChats.RemoveAt(i);   
                }
            }
            await dbComponent.Save(scene.Zone(), dBFriendInfo);
        }
    }
}
