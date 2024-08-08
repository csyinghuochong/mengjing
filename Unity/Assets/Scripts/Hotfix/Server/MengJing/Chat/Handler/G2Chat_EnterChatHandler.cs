namespace ET.Server
{
    [FriendOf(typeof (ChatInfoUnit))]
    [MessageHandler(SceneType.Chat)]
    public class G2Chat_EnterChatHandler: MessageHandler<Scene, G2Chat_EnterChat, Chat2G_EnterChat>
    {
        protected override async ETTask Run(Scene scene, G2Chat_EnterChat request, Chat2G_EnterChat response)
        {
            ChatSceneComponent chatInfoUnitsComponent = scene.Root().GetComponent<ChatSceneComponent>();
            ChatInfoUnit chatInfoUnit = chatInfoUnitsComponent.Get(request.UnitId);

            if (chatInfoUnit != null && !chatInfoUnit.IsDisposed)
            {
                chatInfoUnit.Name = request.Name;
                chatInfoUnit.UnionId = request.UnionId;
                chatInfoUnit.GateSessionActorId = request.GateSessionActorId;
                response.ChatInfoUnitInstanceId = chatInfoUnit.Id;
                return;
            }

            ChatInfoUnit chatInfoUnit1 = chatInfoUnitsComponent.GetChild<ChatInfoUnit>(request.UnitId);
            chatInfoUnit1?.Dispose();

            chatInfoUnit = chatInfoUnitsComponent.AddChildWithId<ChatInfoUnit>(request.UnitId);
            
            chatInfoUnit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            await chatInfoUnit.AddLocation(LocationType.Chat);

            chatInfoUnit.Name = request.Name;
            chatInfoUnit.UnionId = request.UnionId;
            chatInfoUnit.GateSessionActorId = request.GateSessionActorId;
            response.ChatInfoUnitInstanceId = chatInfoUnit.Id;
            chatInfoUnitsComponent.Add(chatInfoUnit);

            await ETTask.CompletedTask;
        }
    }
}