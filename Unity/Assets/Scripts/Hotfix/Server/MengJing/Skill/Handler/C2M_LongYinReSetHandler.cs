namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_LongYinReSetHandler : MessageLocationHandler<Unit, C2M_LongYinReSetRequest, M2C_LongYinReSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_LongYinReSetRequest request, M2C_LongYinReSetResponse response)
        {
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();

            response.Error = skillSetComponent.OnResetLongYin();
            await ETTask.CompletedTask;
        }
    }
}
