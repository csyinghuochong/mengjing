namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonApplyHandler : MessageHandler<Scene, M2C_TeamDungeonApplyResult>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonApplyResult message)
        {
            bool blackroom = UnitHelper.IsBackRoom(root);
            if (blackroom)
            {
                return;
            }

            root.GetComponent<TeamComponentC>().OnRecvTeamApply(message.TeamPlayerInfo);

            await ETTask.CompletedTask;
        }
    }
}