namespace ET.Client
{
    [FriendOf(typeof(FriendComponent))]
    public static class FriendNetHelper
    {
        public static async ETTask<int> RequestFriendInfo(Scene root)
        {
            C2F_FriendInfoRequest request = C2F_FriendInfoRequest.Create();
            request.UnitId = root.GetComponent<PlayerInfoComponent>().CurrentRoleId;

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
            C2F_FriendDeleteRequest request = C2F_FriendDeleteRequest.Create();
            request.UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id;
            request.FriendID = friendId;

            F2C_FriendDeleteResponse response = (F2C_FriendDeleteResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FriendComponent friendComponent = root.GetComponent<FriendComponent>();
                friendComponent.OnFriendDelelte(friendId);
            }

            return response.Error;
        }

        public static async ETTask<F2C_WatchPlayerResponse> RequestWatchPlayer(Scene root, long userId, int watchType)
        {
            C2F_WatchPlayerRequest request = C2F_WatchPlayerRequest.Create();
            request.UserId = userId;
            request.WatchType = watchType;

            F2C_WatchPlayerResponse response = (F2C_WatchPlayerResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> RequestFriendChatRead(Scene root, long friendId)
        {
            C2F_FriendChatRead request = C2F_FriendChatRead.Create();
            request.UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id;
            request.FriendID = friendId;

            F2C_FriendChatRead response = (F2C_FriendChatRead)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> RequestRemoveBlack(Scene root, long friendId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2F_FriendBlacklistRequest request = C2F_FriendBlacklistRequest.Create();
            request.OperateType = 2;
            request.UnitId = userInfoComponent.UserInfo.UserId;
            request.FriendId = friendId;

            F2C_FriendBlacklistResponse response = (F2C_FriendBlacklistResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestAddBlack(Scene root, long friendId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2F_FriendBlacklistRequest request = C2F_FriendBlacklistRequest.Create();
            request.OperateType = 1;
            request.UnitId = userInfoComponent.UserInfo.UserId;
            request.FriendId = friendId;

            F2C_FriendBlacklistResponse response = (F2C_FriendBlacklistResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestFriendApplyReply(Scene root, FriendInfo friendInfo, int code)
        {
            C2F_FriendApplyReplyRequest request = C2F_FriendApplyReplyRequest.Create();
            request.UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id;
            request.FriendID = friendInfo.UserId;
            request.ReplyCode = code;

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

                EventSystem.Instance.Publish(root, new FriendUpdate());
            }

            return response.Error;
        }

        public static async ETTask<int> RequestFriendApply(Scene root, long unitId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2F_FriendApplyRequest request = C2F_FriendApplyRequest.Create();
            request.UnitId = unitId;
            FriendInfo friendInfo = FriendInfo.Create();
            friendInfo.UserId = userInfoComponent.UserInfo.UserId;
            friendInfo.PlayerName = userInfoComponent.UserInfo.Name;
            friendInfo.PlayerLevel = userInfoComponent.UserInfo.Lv;
            friendInfo.Occ = userInfoComponent.UserInfo.Occ;
            request.FriendInfo = friendInfo;

            F2C_FriendApplyResponse response = (F2C_FriendApplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<F2C_WatchPetResponse> RequestWatchPet(Scene root, long unitID, long petId)
        {
            C2F_WatchPetRequest request = C2F_WatchPetRequest.Create();
            request.UnitID = unitID;
            request.PetId = petId;

            F2C_WatchPetResponse response = (F2C_WatchPetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> OneChallengeRequest(Scene root, int operatate, long otherId)
        {
            C2M_OneChallengeRequest request = C2M_OneChallengeRequest.Create();
            request.Operatate = operatate;
            request.OtherId = otherId;

            M2C_OneChallengeResponse response = (M2C_OneChallengeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }
    }
}