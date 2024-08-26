namespace ET.Server
{
    [MessageHandler(SceneType.Chat)]
    public class G2Chat_RequestExitChatHandler: MessageLocationHandler<ChatInfoUnit, G2Chat_RequestExitChat, Chat2G_RequestExitChat>
    {
        protected override async ETTask Run(ChatInfoUnit unit, G2Chat_RequestExitChat request, Chat2G_RequestExitChat response)
        {
            
            ChatSceneComponent chatInfoUnitsComponent = unit.Root().GetComponent<ChatSceneComponent>();

            chatInfoUnitsComponent.Remove(unit.Id);

            await ETTask.CompletedTask;
        }
    }
}