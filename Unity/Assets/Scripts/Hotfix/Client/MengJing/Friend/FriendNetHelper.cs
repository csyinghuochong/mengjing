using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (FriendComponent))]
    public static class FriendNetHelper
    {
        public static async ETTask<int> RequestFriendInfo(Scene root)
        {
            C2F_FriendInfoRequest request = new C2F_FriendInfoRequest() { UnitId = root.GetComponent<PlayerComponent>().CurrentRoleId };
            F2C_FriendInfoResponse response = (F2C_FriendInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            FriendComponent friendComponent = root.GetComponent<FriendComponent>();
            friendComponent.FriendList = response.FriendList;
            friendComponent.ApplyList = response.ApplyList;
            friendComponent.Blacklist = response.Blacklist;
            friendComponent.InitFrindChat(response.FriendChats);

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

        public static async ETTask<int> RequestRemoveBlack(Scene root, long friendId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2F_FriendBlacklistRequest request = new() { OperateType = 2, UnitId = userInfoComponent.UserInfo.UserId, FriendId = friendId };
            F2C_FriendBlacklistResponse response = (F2C_FriendBlacklistResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestAddBlack(Scene root, long friendId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2F_FriendBlacklistRequest request = new() { OperateType = 1, UnitId = userInfoComponent.UserInfo.UserId, FriendId = friendId };
            F2C_FriendBlacklistResponse response =
                    (F2C_FriendBlacklistResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestFriendApplyReply(Scene root, FriendInfo friendInfo, int code)
        {
            C2F_FriendApplyReplyRequest request = new()
            {
                UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id, FriendID = friendInfo.UserId, ReplyCode = code
            };
            F2C_FriendApplyReplyResponse response = (F2C_FriendApplyReplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FriendComponent friendComponent = root.GetComponent<FriendComponent>();
                if (code == 1)
                {
                    friendComponent.FriendList.Add(friendInfo);
                }

                for (int i = friendComponent.ApplyList.Count - 1; i >= 0; i--)
                {
                    if (friendComponent.ApplyList[i].UserId == friendInfo.UserId)
                    {
                        friendComponent.ApplyList.RemoveAt(i);
                        break;
                    }
                }

                EventSystem.Instance.Publish(root, new DataUpdate_FriendUpdate());
            }

            return response.Error;
        }

        public static async ETTask<int> RequestFriendApply(Scene root, long unitId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2F_FriendApplyRequest c2F_FriendApplyReplyRequest = new()
            {
                UnitId = unitId,
                FriendInfo = new FriendInfo()
                {
                    UserId = userInfoComponent.UserInfo.UserId,
                    PlayerName = userInfoComponent.UserInfo.Name,
                    PlayerLevel = userInfoComponent.UserInfo.Lv,
                    Occ = userInfoComponent.UserInfo.Occ,
                }
            };
            F2C_FriendApplyResponse response =
                    (F2C_FriendApplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2F_FriendApplyReplyRequest);
            return response.Error;
        }
    }
}