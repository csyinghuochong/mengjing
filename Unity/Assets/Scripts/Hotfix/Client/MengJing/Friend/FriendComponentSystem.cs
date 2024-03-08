using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof (FriendComponent))]
    [FriendOf(typeof (FriendComponent))]
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
                // self.ZoneScene().GetComponent<ReddotComponent>().AddReddont(ReddotType.FriendChat);
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
            EventSystem.Instance.Publish(self.Root(), new DataUpdate_FriendChat());
        }
    }
}