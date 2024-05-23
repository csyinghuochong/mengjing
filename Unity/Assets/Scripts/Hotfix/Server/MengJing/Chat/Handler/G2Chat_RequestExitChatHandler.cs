namespace ET.Server
{
    [FriendOf(typeof (ChatInfoUnit))]
    [MessageHandler(SceneType.Chat)]
    public class G2Chat_RequestExitChatHandler: MessageHandler<ChatInfoUnit, G2Chat_RequestExitChat, Chat2G_RequestExitChat>
    {
        protected override async ETTask Run(ChatInfoUnit unit, G2Chat_RequestExitChat request, Chat2G_RequestExitChat response)
        {
            ChatSceneComponent chatInfoUnitsComponent = unit.Root().GetComponent<ChatSceneComponent>();

            chatInfoUnitsComponent.Remove(unit.Id);

            await ETTask.CompletedTask;
        }
    }
}