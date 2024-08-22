using System;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonOpenHandler : MessageHandler<Scene, M2C_TeamDungeonOpenResult>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonOpenResult message)
        {
            EventSystem.Instance.Publish(root, new RecvTeamDungeonOpen() { TeamInfo = message.TeamInfo });

            await ETTask.CompletedTask;
        }
    }
}