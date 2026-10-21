namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_LongYinActiveHandler : MessageLocationHandler<Unit, C2M_LongYinActiveRequest, M2C_LongYinActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_LongYinActiveRequest request, M2C_LongYinActiveResponse response)
        {
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();

            response.Error = skillSetComponent.OnActiveLongYin(request.LongYinId);
            await ETTask.CompletedTask;
        }
    }
}
