namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SyncChatInfoHandler : MessageHandler<Scene, M2C_SyncChatInfo>
    {
        protected override async ETTask Run(Scene root, M2C_SyncChatInfo message)
        {
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