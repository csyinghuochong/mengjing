namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class C2C_SyncChatInfoHandler : MessageHandler<Scene, C2C_SyncChatInfo>
    {
        protected override async ETTask Run(Scene root, C2C_SyncChatInfo message)
        {
            HintHelp.ShowHint(root, $"收到 频道：{message.ChatInfo.ChannelId} 玩家：{message.ChatInfo.PlayerName} 消息：{message.ChatInfo.ChatMsg}");

            if (message.ChatInfo.ChannelId == (int)ChannelEnum.Friend)
            {
                root.GetComponent<FriendComponent>().OnRecvChat(message.ChatInfo);
            }
            else
            {
                root.GetComponent<ChatComponent>().OnRecvChat(message.ChatInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}