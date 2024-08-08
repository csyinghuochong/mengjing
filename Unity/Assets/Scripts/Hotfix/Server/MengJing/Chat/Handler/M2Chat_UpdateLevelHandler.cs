namespace ET.Server
{
    [MessageHandler(SceneType.Chat)]
    public class M2Chat_UpdateLevelHandler : MessageHandler<Scene, M2Chat_UpdateLevel, Chat2M_UpdateLevel>
    {
        protected override async ETTask Run(Scene scene, M2Chat_UpdateLevel request, Chat2M_UpdateLevel response)
        {
            ChatSceneComponent chatInfoUnitsComponent = scene.Root().GetComponent<ChatSceneComponent>();
            ChatInfoUnit chatInfoUnit = chatInfoUnitsComponent.Get(request.UnitId);
            if(chatInfoUnit != null ) 
            {
                chatInfoUnit.Level = request.Level;
            }

            await ETTask.CompletedTask;
        }
    }
}
