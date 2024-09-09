using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof(FriendComponent))]
    [FriendOf(typeof(FriendComponent))]
    public static partial class FriendComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FriendComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this FriendComponent self)
        {
        }

        public static void OnFriendDelelte(this FriendComponent self, long friendId)
        {
            for (int i = self.FriendList.Count - 1; i >= 0; i--)
            {
                if (self.FriendList[i].UserId == friendId)
                {
                    self.FriendList.RemoveAt(i);
                }
            }
        }

        public static void SetChatData(this FriendComponent self, ChatInfo chatInfo)
        {
            long friendId = 0;
            long myUserId = UnitHelper.GetMyUnitFromClientScene(self.Root()).Id;
            bool othertoself = false;
            if (chatInfo.UserId == myUserId)
            {
                friendId = chatInfo.ParamId; //我对别人的私聊
            }
            else
            {
                friendId = chatInfo.UserId; //别人对我的私聊
                othertoself = true;
            }

            if (othertoself)
            {
                self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.FriendChat);
            }

            if (!self.ChatMsgList.ContainsKey(friendId))
            {
                self.ChatMsgList.Add(friendId, new List<ChatInfo>());
            }

            if (!self.FriendChatId.Contains(chatInfo.UserId))
            {
                self.FriendChatId.Add(chatInfo.UserId);
            }

            List<ChatInfo> chatInfoList = self.ChatMsgList[friendId];
            for (int i = 0; i < chatInfoList.Count; i++)
            {
                if (chatInfoList[i].Time > 0 && chatInfoList[i].Time == chatInfo.Time)
                {
                    return;
                }
            }

            chatInfoList.Add(chatInfo);
        }

        public static void OnRecvChat(this FriendComponent self, ChatInfo chatInfo)
        {
            self.SetChatData(chatInfo);
            EventSystem.Instance.Publish(self.Root(), new FriendChat());
        }

        public static void InitFrindChat(this FriendComponent self, List<ChatInfo> chatlist)
        {
            for (int i = 0; i < chatlist.Count; i++)
            {
                self.SetChatData(chatlist[i]);
            }
        }

        /// <summary>
        /// 1 好友  2黑名单
        /// </summary>
        /// <param name="self"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetFriendType(this FriendComponent self, long userId)
        {
            for (int i = 0; i < self.FriendList.Count; i++)
            {
                if (self.FriendList[i].UserId == userId)
                {
                    return 1;
                }
            }

            for (int i = 0; i < self.Blacklist.Count; i++)
            {
                if (self.Blacklist[i].UserId == userId)
                {
                    return 2;
                }
            }

            return 0;
        }

        public static void OnRecvFriendApplyResult(this FriendComponent self, M2C_FriendApplyResult message)
        {
            bool have = false;
            for (int i = 0; i < self.ApplyList.Count; i++)
            {
                if (self.ApplyList[i].UserId == message.FriendInfo.UserId)
                {
                    have = true;
                    break;
                }
            }

            if (!have)
            {
                self.ApplyList.Add(message.FriendInfo);
            }

            self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.FriendApply);
        }
    }
}