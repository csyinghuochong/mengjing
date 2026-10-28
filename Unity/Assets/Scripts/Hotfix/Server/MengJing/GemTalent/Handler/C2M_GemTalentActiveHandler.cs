namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GemTalentActiveHandler : MessageLocationHandler<Unit, C2M_GemTalentActiveRequest, M2C_GemTalentActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemTalentActiveRequest request, M2C_GemTalentActiveResponse response)
        {
            GemTalentComponent gemTalentComponent = unit.GetComponent<GemTalentComponent>();

            response.Error = gemTalentComponent.OnActiveGemTalent(request.GemTalentId);
            response.Info = gemTalentComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
