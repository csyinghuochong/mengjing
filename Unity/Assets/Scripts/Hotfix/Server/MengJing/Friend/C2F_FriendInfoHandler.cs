using System.Collections.Generic;

namespace  ET.Server
{
    [MessageHandler(SceneType.Friend)]
    public class C2F_FriendInfoHandler: MessageHandler<Scene,C2F_FriendInfoRequest,  F2C_FriendInfoResponse>
    {
        protected override async ETTask Run(Scene scene, C2F_FriendInfoRequest handler, F2C_FriendInfoResponse response)
        {
            Log.Debug("1111111111111:C2A_ActivityInfoRequest");
            
            response.FriendList.Add(new FriendInfo()
            {
                PlayerName = "玩家1",
                Occ = 1,
                PlayerLevel = 1,
            });
            
            await ETTask.CompletedTask;
        }
    }
}
