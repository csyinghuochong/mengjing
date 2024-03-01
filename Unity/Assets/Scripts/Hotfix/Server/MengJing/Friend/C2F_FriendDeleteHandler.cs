using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    public class C2F_FriendDeleteHandler: MessageHandler<Scene,C2F_FriendDeleteRequest,  F2C_FriendDeleteResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendDeleteRequest handler, F2C_FriendDeleteResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            await ETTask.CompletedTask;
        }
    }
}
