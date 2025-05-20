using System;
using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    [FriendOf(typeof(DBFriendInfo))]
    public class C2F_FriendApplyHandler: MessageHandler<Scene,C2F_FriendApplyRequest,  F2C_FriendApplyResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendApplyRequest request, F2C_FriendApplyResponse response)
        {
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBFriendInfo> dbFriendInfos = await dbComponent.Query<DBFriendInfo>( scene.Zone(), d=> d.Id == request.UnitId);
            if (dbFriendInfos == null || dbFriendInfos.Count == 0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            DBFriendInfo dBFriendInfo = dbFriendInfos[0];

            Console.WriteLine($"C2F_FriendApplyHandler   request.FriendInfo.UserId == {request.FriendInfo.UserId}");

            if (dBFriendInfo.FriendList.Contains(request.FriendInfo.UserId))
            {
                return;
            }
            if (!dBFriendInfo.ApplyList.Contains(request.FriendInfo.UserId))
            {
                dBFriendInfo.ApplyList.Add(request.FriendInfo.UserId);
                
                await dbComponent.Save(scene.Zone(), dBFriendInfo);
                
                M2C_FriendApplyResult m2C_FriendApplyResult = M2C_FriendApplyResult.Create();
                m2C_FriendApplyResult.FriendInfo = request.FriendInfo;
                scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(request.UnitId, m2C_FriendApplyResult);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
