namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CellDungeonInfoHandler : MessageHandler<Scene, M2C_CellDungeonInfo>
    {
        protected override async ETTask Run(Scene root, M2C_CellDungeonInfo message)
        {
            CellDungeonComponentC fubenComponent = root.GetComponent<CellDungeonComponentC>();

            //进入第一个格子
            fubenComponent.InitFubenCell(message.SceneId);
            fubenComponent.FubenDifficulty = message.Difficulty;
            fubenComponent.FubenInfo = message.FubenInfo;
            fubenComponent.SonFubenInfo = message.SonFubenInfo;

            fubenComponent.SetStartedFlag(fubenComponent.FubenInfo.StartCell);
            fubenComponent.SetEndedFlag(fubenComponent.FubenInfo.EndCell);
            fubenComponent.UpdateCellType(fubenComponent.SonFubenInfo.CurrentCell, fubenComponent.SonFubenInfo.PassableFlag);

            await ETTask.CompletedTask;
        }
    }
}