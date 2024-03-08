namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
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

            UserInfo userInfo = root.GetComponent<UserInfoComponentClient>().UserInfo;
            C2C_SendChatRequest request = new C2C_SendChatRequest() { };
            request.ChatInfo = new ChatInfo();
            request.ChatInfo.PlayerLevel = userInfo.Lv;
            request.ChatInfo.Occ = userInfo.Occ;
            // switch (channelEnum)
            // {
            //     case ChannelEnum.Word:
            //         self.LastSendWord = TimeHelper.ClientNow();
            //         break;
            //     case ChannelEnum.Team:
            //         Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            //         NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            //         c2S_SendChatRequest.ChatInfo.ParamId = numericComponent.GetAsLong(NumericType.TeamId);
            //         break;
            //     case ChannelEnum.Union:
            //         unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            //         numericComponent = unit.GetComponent<NumericComponent>();
            //         c2S_SendChatRequest.ChatInfo.ParamId = numericComponent.GetAsLong(NumericType.UnionId_0);
            //         break;
            //     case ChannelEnum.Friend:
            //         c2S_SendChatRequest.ChatInfo.ParamId = paramId;
            //         break;
            // }
            //
            request.ChatInfo.UserId = userInfo.UserId;
            request.ChatInfo.ChannelId = (int)channelEnum;
            request.ChatInfo.ChatMsg = content;
            request.ChatInfo.PlayerName = userInfo.Name;
            C2C_SendChatResponse response =
                    (C2C_SendChatResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
    }
}