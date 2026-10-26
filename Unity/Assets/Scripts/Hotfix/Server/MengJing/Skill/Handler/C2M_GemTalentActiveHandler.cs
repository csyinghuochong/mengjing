namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GemTalentActiveHandler : MessageLocationHandler<Unit, C2M_GemTalentActiveRequest, M2C_GemTalentActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemTalentActiveRequest request, M2C_GemTalentActiveResponse response)
        {
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();

            response.Error = skillSetComponent.OnActiveGemTalent(request.GemTalentId);
            await ETTask.CompletedTask;
        }
    }
}
