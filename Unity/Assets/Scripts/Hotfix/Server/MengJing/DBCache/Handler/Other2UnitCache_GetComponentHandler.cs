namespace ET.Server
{
    [FriendOf(typeof(UnitCacheComponent))]
    [MessageHandler(SceneType.DBCache)]
    public class Other2UnitCache_GetComponentHandler: MessageHandler<Scene, Other2UnitCache_GetComponent, UnitCache2Other_GetComponent>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_GetComponent request, UnitCache2Other_GetComponent response)
        {
            UnitCacheComponent db = scene.Root().GetComponent<UnitCacheComponent>();
            Entity entity = await db.Get(request.UnitId, request.Component);
            if (entity != null)
            {
                response.Component = entity.ToBson();
            }

            await ETTask.CompletedTask;
        }
    }
}
