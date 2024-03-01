using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    public class C2F_FriendInfoRequest: MessageHandler<Scene,C2F_FriendInfoRequest,  F2C_FriendInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendInfoRequest request, F2C_FriendInfoResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            await ETTask.CompletedTask;
        }
    }
}
