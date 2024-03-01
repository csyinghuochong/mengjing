using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    public class C2F_FriendApplyReplyHandler: MessageHandler<Scene,C2F_FriendApplyReplyRequest,  F2C_FriendApplyReplyResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendApplyReplyRequest request, F2C_FriendApplyReplyResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            await ETTask.CompletedTask;
        }
    }
}
