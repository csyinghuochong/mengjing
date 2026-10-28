namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GemTalentReSetHandler : MessageLocationHandler<Unit, C2M_GemTalentReSetRequest, M2C_GemTalentReSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GemTalentReSetRequest request, M2C_GemTalentReSetResponse response)
        {
            GemTalentComponent gemTalentComponent = unit.GetComponent<GemTalentComponent>();

            response.Error = gemTalentComponent.OnResetGemTalent();
            response.Info = gemTalentComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
