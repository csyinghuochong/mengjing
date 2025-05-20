using System;
using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(DBFriendInfo))]
    public class C2F_FriendApplyReplyHandler: MessageHandler<Scene,C2F_FriendApplyReplyRequest,  F2C_FriendApplyReplyResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendApplyReplyRequest request, F2C_FriendApplyReplyResponse response)
        {
            
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.UnitId);
            if (dbFriendInfos == null || dbFriendInfos.Count == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            DBFriendInfo dBFriendInfo = dbFriendInfos[0];
            
            dBFriendInfo.ApplyList.Remove(request.FriendID);

            if (request.FriendID == 0)
            {
                Console.WriteLine("C2F_FriendApplyReplyHandler   request.FriendID == 0");
            }

            if (request.ReplyCode == 1) //同意
            {
                if (!dBFriendInfo.FriendList.Contains(request.FriendID))
                {
                    dBFriendInfo.FriendList.Add(request.FriendID);
                }
                //对方也同样标记
                List<DBFriendInfo> dbFriendInfosOther = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.FriendID);
                if (dbFriendInfosOther != null && dbFriendInfosOther.Count > 0)
                {
                    DBFriendInfo dBFriendInfo_2 = dbFriendInfosOther[0];
                    if (!dBFriendInfo_2.FriendList.Contains(request.UnitId))
                    {
                        dBFriendInfo_2.FriendList.Add(request.UnitId);
                    }
                    await dbComponent.Save(scene.Zone(), dBFriendInfo_2);
                }
            }

            dBFriendInfo.FriendList.RemoveAll(item => item == 0);
            dBFriendInfo.ApplyList.RemoveAll(item => item == 0);
            dBFriendInfo.Blacklist.RemoveAll(item => item == 0);
            await dbComponent.Save(scene.Zone(), dBFriendInfo);
            await ETTask.CompletedTask;
        }
    }
}
