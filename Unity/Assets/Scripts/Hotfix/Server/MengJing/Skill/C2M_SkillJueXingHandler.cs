namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SkillJueXingHandler : MessageLocationHandler<Unit, C2M_SkillJueXingRequest, M2C_SkillJueXingResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillJueXingRequest request, M2C_SkillJueXingResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}