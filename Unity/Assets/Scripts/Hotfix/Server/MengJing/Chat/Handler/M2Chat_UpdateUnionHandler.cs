namespace ET.Server
{
    [MessageHandler(SceneType.Chat)]
    public class M2Chat_UpdateUnionHandler : MessageHandler<Scene, M2Chat_UpdateUnion, Chat2M_UpdateUnion>
    {
        protected override async ETTask Run(Scene scene, M2Chat_UpdateUnion request, Chat2M_UpdateUnion response)
        {
          
            ChatSceneComponent chatInfoUnitsComponent = scene.Root().GetComponent<ChatSceneComponent>();
            ChatInfoUnit chatInfoUnit = chatInfoUnitsComponent.Get(request.UnitId);
            if (chatInfoUnit == null)
            {
                Log.Warning($"chatInfoUnit == null; {request.UnitId}");

                return;
            }

            chatInfoUnit.UnionId = request.UnionId;
            await ETTask.CompletedTask;
        }
    }
}
