
namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CellSonDungeonInfoHandler : MessageHandler<Scene, M2C_CellSonDungeonInfo>
    {
        protected override async ETTask Run(Scene root, M2C_CellSonDungeonInfo message)
        {
            MapComponent mapComponent = root.GetComponent<MapComponent>();      
            CellDungeonComponentC fubenComponent = root.GetComponent<CellDungeonComponentC>();

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            unit.GetComponent<StateComponentC>().StateTypeRemove(StateTypeEnum.NoMove);


            fubenComponent.SonFubenInfo = message.SonFubenInfo;
            fubenComponent.SetWalkedFlag(fubenComponent.SonFubenInfo.CurrentCell);
            fubenComponent.UpdateCellType(fubenComponent.SonFubenInfo.CurrentCell, fubenComponent.SonFubenInfo.PassableFlag);
            root.GetComponent<MapComponent>().SetMapInfo(mapComponent.SceneType, mapComponent.SceneId, message.SonFubenInfo.SonSceneId);

            ///需要无缝切换 加载新场景 
            await EventSystem.Instance.PublishAsync(root, new EnterCellDungeon()
            { 
                
            });

         

            unit.Position = message.Position;
            await ETTask.CompletedTask;
        }
    }
}