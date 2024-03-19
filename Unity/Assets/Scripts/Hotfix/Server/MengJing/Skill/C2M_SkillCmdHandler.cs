namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentServer))]
    public class C2M_SkillCmdHandler : MessageLocationHandler<Unit, C2M_SkillCmd, M2C_SkillCmd>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillCmd request, M2C_SkillCmd response)
        {
            await ETTask.CompletedTask;
        }
    }
}