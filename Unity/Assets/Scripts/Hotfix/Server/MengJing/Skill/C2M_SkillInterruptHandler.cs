namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof (TaskComponentServer))]
    public class C2M_SkillInterruptHandler: MessageLocationHandler<Unit, C2M_SkillInterruptRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillInterruptRequest request)
        {
            await ETTask.CompletedTask;
        }
    }
}