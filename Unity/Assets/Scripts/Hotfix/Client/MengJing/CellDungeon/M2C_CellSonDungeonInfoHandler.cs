
namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CellSonDungeonInfoHandler : MessageHandler<Scene, M2C_CellSonDungeonInfo>
    {
        protected override async ETTask Run(Scene root, M2C_CellSonDungeonInfo message)
        {
            MapComponent mapComponent = root.GetComponent<MapComponent>();      
            CellDungeonComponentC fubenComponent = root.GetComponent<CellDungeonComponentC>();

            Unit unitmain = UnitHelper.GetMyUnitFromClientScene(root);
            UnitComponent  unitComponent = unitmain.GetParent<UnitComponent>();
            for (int i = 0; i < message.UnitIds.Count; i++)
            {
                Unit unit = unitComponent.Get(message.UnitIds[i]);
                unit.GetComponent<MoveComponent>().Stop(true);
            }
            
            fubenComponent.SonFubenInfo = message.SonFubenInfo;
            fubenComponent.SetWalkedFlag(fubenComponent.SonFubenInfo.CurrentCell);
            fubenComponent.UpdateCellType(fubenComponent.SonFubenInfo.CurrentCell, fubenComponent.SonFubenInfo.PassableFlag);
            root.GetComponent<MapComponent>().SetMapInfo(mapComponent.MapType, mapComponent.SceneId, message.SonFubenInfo.SonSceneId);

            ///需要无缝切换 加载新场景 
            await EventSystem.Instance.PublishAsync(root, new EnterCellDungeon()
            { 
                
            });


            unitComponent = unitmain.GetParent<UnitComponent>();
            for (int i = 0; i < message.UnitIds.Count; i++)
            {
                Unit unit = unitComponent.Get(message.UnitIds[i]);
                if (unit != null)
                {
                    unit.Position = message.Positions[i];
                }
            }
            await ETTask.CompletedTask;
        }
    }
}