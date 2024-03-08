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
            F2C_FriendInfoResponse response = (F2C_FriendInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            friendComponent.FriendList = response.FriendList;

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestFriendDelete(Scene root, long friendId)
        {
            C2F_FriendDeleteRequest request = new() { UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id, FriendID = friendId };
            F2C_FriendDeleteResponse response = (F2C_FriendDeleteResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FriendComponent friendComponent = root.GetComponent<FriendComponent>();
                friendComponent.OnFriendDelelte(friendId);
            }

            return response.Error;
        }

        public static async ETTask<F2C_FriendDeleteResponse> RequestWatchPlayer(Scene root, long friendId)
        {
            C2F_FriendDeleteRequest request = new() { UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id, FriendID = friendId };
            F2C_FriendDeleteResponse response = (F2C_FriendDeleteResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RequestFriendChatRead(Scene root, long friendId)
        {
            C2F_FriendChatRead request = new() { UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id, FriendID = friendId };
            F2C_FriendChatRead response = (F2C_FriendChatRead)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
    }
}