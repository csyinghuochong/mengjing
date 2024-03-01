using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    public class C2F_FriendApplyHandler: MessageHandler<Scene,C2F_FriendApplyRequest,  F2C_FriendApplyResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendApplyRequest request, F2C_FriendApplyResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            await ETTask.CompletedTask;
        }
    }
}
