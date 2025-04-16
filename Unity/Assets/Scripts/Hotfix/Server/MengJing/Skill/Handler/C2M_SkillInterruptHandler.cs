namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SkillInterruptHandler : MessageLocationHandler<Unit, C2M_SkillInterruptRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillInterruptRequest request)
        {
            unit.GetComponent<SkillManagerComponentS>().InterruptSkill(request.SkillID);
            M2C_SkillInterruptResult m2C_SkillInterruptResult = M2C_SkillInterruptResult.Create();
            m2C_SkillInterruptResult.UnitId = unit.Id;
            m2C_SkillInterruptResult.SkillId = request.SkillID;
            MapMessageHelper.Broadcast(unit, m2C_SkillInterruptResult);
            await ETTask.CompletedTask;
        }
    }
}