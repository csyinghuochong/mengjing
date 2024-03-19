namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SkillOperationHandler : MessageLocationHandler<Unit, C2M_SkillOperation, M2C_SkillOperation>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillOperation request, M2C_SkillOperation response)
        {
            await ETTask.CompletedTask;
        }
    }
}