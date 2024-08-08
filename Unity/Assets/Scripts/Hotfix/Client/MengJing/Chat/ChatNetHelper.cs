namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    public static class ChatNetHelper
    {
        public static async ETTask<int> RequestSendChat(Scene root, int channelEnum, string content, long paramId = 0)
        {
            // if (channelEnum == ChannelEnum.Word && TimeHelper.ClientNow() - self.LastSendWord < 20 * TimeHelper.Second)
            // {
            //     return ErrorCode.ERR_WordChat;
            // }
            //
            // if ((channelEnum == ChannelEnum.Team || channelEnum == ChannelEnum.Union) &&
            //     TimeHelper.ClientNow() - self.LastSendWord < 5 * TimeHelper.Second)
            // {
            //     return ErrorCode.ERR_UnionChatLimit;
            // }

            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            C2C_SendChatRequest request = C2C_SendChatRequest.Create();
            request.ChatInfo = ChatInfo.Create();
            request.ChatInfo.PlayerLevel = userInfo.Lv;
            request.ChatInfo.Occ = userInfo.Occ;
            switch (channelEnum)
            {
                case ChannelEnum.Word:
                    // self.LastSendWord = TimeHelper.ClientNow();
                    break;
                case ChannelEnum.Team:
                    Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
                    NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
                    request.ChatInfo.ParamId = numericComponent.GetAsLong(NumericType.TeamId);
                    break;
                case ChannelEnum.Union:
                    unit = UnitHelper.GetMyUnitFromClientScene(root);
                    numericComponent = unit.GetComponent<NumericComponentC>();
                    request.ChatInfo.ParamId = numericComponent.GetAsLong(NumericType.UnionId_0);
                    break;
                case ChannelEnum.Friend:
                    request.ChatInfo.ParamId = paramId;
                    break;
            }

            request.ChatInfo.UserId = userInfo.UserId;
            request.ChatInfo.ChannelId = (int)channelEnum;
            request.ChatInfo.ChatMsg = content;
            request.ChatInfo.PlayerName = userInfo.Name;
            C2C_SendChatResponse response =
                    (C2C_SendChatResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> SendBroadcast(Scene root, int zoneType, ChatInfo chatInfo)
        {
            C2C_SendBroadcastRequest request = new() { ZoneType = zoneType };
            request.ChatInfo = chatInfo;
            C2C_SendBroadcastResponse response = (C2C_SendBroadcastResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> ChatJinYanRequest(Scene root, long jinYanId, string jinYanPlayer, long unitId)
        {
            C2C_ChatJinYanRequest reuqest = C2C_ChatJinYanRequest.Create();
            reuqest.JinYanId = jinYanId;
            reuqest.JinYanPlayer = jinYanPlayer;
            reuqest.UnitId = unitId;
            C2C_ChatJinYanResponse response = (C2C_ChatJinYanResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);
            return response.Error;
        }
    }
}