namespace ET.Server
{
    [Event(SceneType.Map)]
    public class UnitDisconnect_OnNotify : AEvent<Scene, UnitDisconnect>
    {
        protected override async ETTask Run(Scene scene, UnitDisconnect args)
        {
            long userId = args.UnitId;
            int sceneTypeEnum = scene.GetComponent<MapComponent>().SceneType;

            if (SceneConfigHelper.IsSingleFuben(sceneTypeEnum))
            {
                //动态删除副本
                TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
            }

            await ETTask.CompletedTask;
        }
    }
}