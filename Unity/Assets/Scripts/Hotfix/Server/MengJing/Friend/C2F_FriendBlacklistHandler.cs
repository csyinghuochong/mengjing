using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    public class C2F_FriendBlacklistHandler: MessageHandler<Scene,C2F_FriendBlacklistRequest,  F2C_FriendBlacklistResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendBlacklistRequest request, F2C_FriendBlacklistResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            await ETTask.CompletedTask;
        }
    }
}
