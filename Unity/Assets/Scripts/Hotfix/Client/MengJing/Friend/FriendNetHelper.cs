using System;
using System.Collections.Generic;

namespace ET.Client
{
    
    [FriendOf(typeof (FriendComponent))]
    public static class FriendNetHelper
    {
        public static async ETTask<int> RequestFriendInfo(Scene root)
        {
            C2F_FriendInfoRequest request = new C2F_FriendInfoRequest();
            F2C_FriendInfoResponse response = (F2C_FriendInfoResponse) await root.GetComponent<ClientSenderCompnent>().Call(request);
            return ErrorCode.ERR_Success;
        }
    }
}