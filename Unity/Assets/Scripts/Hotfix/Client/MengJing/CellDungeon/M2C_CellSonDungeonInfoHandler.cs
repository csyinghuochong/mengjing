
namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CellSonDungeonInfoHandler : MessageHandler<Scene, M2C_CellSonDungeonInfo>
    {
        protected override async ETTask Run(Scene root, M2C_CellSonDungeonInfo message)
        {
            CellDungeonComponentC fubenComponent = root.GetComponent<CellDungeonComponentC>();

            fubenComponent.SonFubenInfo = message.SonFubenInfo;
            fubenComponent.SetWalkedFlag(fubenComponent.SonFubenInfo.CurrentCell);
            fubenComponent.UpdateCellType(fubenComponent.SonFubenInfo.CurrentCell, fubenComponent.SonFubenInfo.PassableFlag);



            await ETTask.CompletedTask;
        }
    }
}