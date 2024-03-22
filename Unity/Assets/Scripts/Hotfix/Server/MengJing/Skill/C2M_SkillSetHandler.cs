namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SkillSetHandler : MessageLocationHandler<Unit, C2M_SkillSet, M2C_SkillSet>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillSet request, M2C_SkillSet response)
        {
            unit.GetComponent<SkillSetComponent_S>().SetSkillIdByPosition(request);
            await ETTask.CompletedTask;
        }
    }
}