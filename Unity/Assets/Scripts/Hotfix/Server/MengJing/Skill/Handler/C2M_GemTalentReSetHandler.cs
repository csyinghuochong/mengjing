namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GemTalentReSetHandler : MessageLocationHandler<Unit, C2M_GemTalentReSetRequest, M2C_GemTalentReSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemTalentReSetRequest request, M2C_GemTalentReSetResponse response)
        {
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();

            response.Error = skillSetComponent.OnResetGemTalent();
            await ETTask.CompletedTask;
        }
    }
}
