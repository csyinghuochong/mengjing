namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class EnterCellDungeon_OnLoadScene : AEvent<Scene, EnterCellDungeon>
    {
        protected override async ETTask Run(Scene scene, EnterCellDungeon args)
        {
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            await scene.GetComponent<SceneManagerComponent>().ChangeCellSonScene(mapComponent.SceneType,
                mapComponent.SceneType,
                mapComponent.SonSceneId);

            scene.GetComponent<CellDungeonComponentC>().CheckChuansongOpen();

            await ETTask.CompletedTask;
        }
    }
}