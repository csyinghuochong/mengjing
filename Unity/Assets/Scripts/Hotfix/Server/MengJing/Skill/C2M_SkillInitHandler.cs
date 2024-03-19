namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof (TaskComponentServer))]
    public class C2M_SkillInitHandler: MessageLocationHandler<Unit, C2M_SkillInitRequest, M2C_SkillInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillInitRequest request, M2C_SkillInitResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}