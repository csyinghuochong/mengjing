namespace ET.Client
{
    
    /// <summary>
    /// 玩家离开副本 通知机器人下线
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonQuitHandler : MessageHandler<Scene, M2C_TeamDungeonQuitMessage>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonQuitMessage message)
        {
            EventSystem.Instance.Publish(root, new PlayerQuitDungeon() { M2CTeamDungeonQuitMessage = message });

            await ETTask.CompletedTask;
        }
    }
}