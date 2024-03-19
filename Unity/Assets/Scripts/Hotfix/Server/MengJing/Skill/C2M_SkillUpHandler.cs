namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentServer))]
    public class C2M_SkillUpHandler : MessageLocationHandler<Unit, C2M_SkillUp, M2C_SkillUp>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillUp request, M2C_SkillUp response)
        {
            await ETTask.CompletedTask;
        }
    }
}

