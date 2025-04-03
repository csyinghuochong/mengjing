namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class EnterCellDungeon_OnLoadScene : AEvent<Scene, EnterCellDungeon>
    {
        protected override async ETTask Run(Scene scene, EnterCellDungeon args)
        {
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.ResetJoystick();
            
            Unit unit = UnitHelper.GetMyUnitFromClientScene(scene);
            unit.UpdateMainHeroPath(mapComponent);
            
            await scene.GetComponent<SceneManagerComponent>().ChangeCellSonScene(mapComponent.MapType,
                mapComponent.MapType,
                mapComponent.SonSceneId);
   
            scene.GetComponent<CellDungeonComponentC>().CheckChuansongOpen();

            await ETTask.CompletedTask;
        }
    }
}