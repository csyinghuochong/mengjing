using System;
using System.Collections.Generic;

namespace ET.Client
{
    
    [FriendOf(typeof (FriendComponent))]
    public static class FriendNetHelper
    {
        public static async ETTask<int> RequestFriendInfo(Scene root)
        {
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
    }
}