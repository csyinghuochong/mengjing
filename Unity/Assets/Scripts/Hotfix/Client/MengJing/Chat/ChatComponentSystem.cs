using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (FriendComponent))]
    [FriendOf(typeof (ChatComponent))]
    [EntitySystemOf(typeof (ChatComponent))]
    public static partial class ChatComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ChatComponent self)
        {
            self.ChatTypeList.Clear();
            self.ChatTypeList.Add(ChannelEnum.Word, new List<ChatInfo>());
            self.ChatTypeList.Add(ChannelEnum.Team, new List<ChatInfo>());
            self.ChatTypeList.Add(ChannelEnum.System, new List<ChatInfo>());
            self.ChatTypeList.Add(ChannelEnum.Union, new List<ChatInfo>());
            self.ChatTypeList.Add(ChannelEnum.Friend, new List<ChatInfo>());
            self.ChatTypeList.Add(ChannelEnum.Pick, new List<ChatInfo>());
            self.ChatTypeList.Add(ChannelEnum.PaiMai, new List<ChatInfo>());
        }

        public static List<ChatInfo> GetChatListByType(this ChatComponent self, int channelEnum)
        {
            if (channelEnum == ChannelEnum.Word)
            {
                List<ChatInfo> chatInfos = new List<ChatInfo>();
                chatInfos.AddRange(self.ChatTypeList[ChannelEnum.Word]);
                chatInfos.AddRange(self.ChatTypeList[ChannelEnum.System]);
                chatInfos.AddRange(self.ChatTypeList[ChannelEnum.Union]);
                chatInfos.Sort(delegate(ChatInfo a, ChatInfo b) { return (int)(a.Time - b.Time); });

                return chatInfos;
            }

            if (channelEnum == ChannelEnum.System)
            {
                List<ChatInfo> chatInfos = new List<ChatInfo>();
                chatInfos.AddRange(self.ChatTypeList[ChannelEnum.System]);
                chatInfos.AddRange(self.ChatTypeList[ChannelEnum.Pick]);
                chatInfos.Sort(delegate(ChatInfo a, ChatInfo b) { return (int)(a.Time - b.Time); });

                return chatInfos;
            }

            return self.ChatTypeList[channelEnum];
        }

        public static void OnRecvChat(this ChatComponent self, ChatInfo chatInfo)
        {
            // 在黑名单的玩家发言不显示
            if (chatInfo.ChannelId == (int)ChannelEnum.Word)
            {
                foreach (FriendInfo friendInfo in self.Root().GetComponent<FriendComponent>().Blacklist)
                {
                    if (friendInfo.UserId == chatInfo.UserId)
                    {
                        return;
                    }
                }
            }

            switch (chatInfo.ChannelId)
            {
                case ChannelEnum.Word:
                    self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.WordChat);
                    break;
                case ChannelEnum.Team:
                    self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.TeamChat);
                    break;
                case ChannelEnum.Union:
                    self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.UnionChat);
                    break;
                case ChannelEnum.System:
                    self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.SystemChat);
                    break;
                case ChannelEnum.PaiMai:
                    self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.PaiMaiChat);
                    break;
            }

            self.LastChatInfo = chatInfo;
            List<ChatInfo> chatInfos = self.ChatTypeList[chatInfo.ChannelId];
            if (chatInfos.Count >= 20)
            {
                chatInfos.RemoveAt(0);
            }

            chatInfos.Add(chatInfo);
            
            EventSystem.Instance.Publish(self.Root(), new OnRecvChat());
        }
    }
}