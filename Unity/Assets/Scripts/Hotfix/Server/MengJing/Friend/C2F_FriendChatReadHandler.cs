using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    public class C2F_FriendChatReadHandler: MessageHandler<Scene,C2F_FriendChatRead,  F2C_FriendChatRead>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendChatRead request, F2C_FriendChatRead response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            await ETTask.CompletedTask;
        }
    }
}
