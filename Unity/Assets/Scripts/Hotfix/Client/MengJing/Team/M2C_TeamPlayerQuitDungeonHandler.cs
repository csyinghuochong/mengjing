namespace ET.Client
{
    
    /// <summary>
    /// 玩家离开副本 通知机器人下线
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamPlayerQuitDungeonHandler : MessageHandler<Scene, M2C_TeamPlayerQuitDungeon>
    {
        protected override async ETTask Run(Scene root, M2C_TeamPlayerQuitDungeon message)
        {
            EventSystem.Instance.Publish(root, new PlayerQuitDungeon() { M2CTeamDungeonQuitMessage = message });

            await ETTask.CompletedTask;
        }
    }
}