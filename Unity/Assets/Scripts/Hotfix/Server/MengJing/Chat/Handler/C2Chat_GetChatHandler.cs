namespace ET.Server
{

    [MessageHandler(SceneType.Chat)]
    public class C2Chat_GetChatHandler : MessageLocationHandler<ChatInfoUnit, C2Chat_GetChatRequest, Chat2C_GetChatResponse>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2Chat_GetChatRequest request, Chat2C_GetChatResponse response)
        {
            long serverTime = TimeHelper.ServerNow();
            ChatSceneComponent chatInfoUnitsComponent = chatInfoUnit.Root().GetComponent<ChatSceneComponent>();

            for (int i = 0; i < chatInfoUnitsComponent.WordChatInfos.Count; i++)
            {
                ChatInfo chatInfo = chatInfoUnitsComponent.WordChatInfos[i];
                if (serverTime - chatInfo.Time < TimeHelper.OneDay)
                {
                    response.ChatInfos.Add(chatInfo);
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
