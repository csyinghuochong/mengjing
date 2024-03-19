namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SkillInterruptHandler : MessageLocationHandler<Unit, C2M_SkillInterruptRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillInterruptRequest request)
        {
            unit.GetComponent<SkillComponentServer>().InterruptSkill(request.SkillID);
            M2C_SkillInterruptResult m2C_SkillInterruptResult = new M2C_SkillInterruptResult() { UnitId = unit.Id, SkillId=request.SkillID };
            MapMessageHelper.Broadcast(unit, m2C_SkillInterruptResult);
            await ETTask.CompletedTask;
        }
    }
}