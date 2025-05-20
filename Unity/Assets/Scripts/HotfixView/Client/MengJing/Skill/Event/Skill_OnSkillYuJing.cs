namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Skill_OnSkillYuJing : AEvent<Scene, SkillYuJing>
    {
        protected override async ETTask Run(Scene scene, SkillYuJing args)
        {
            Unit unit = args.Unit;
            Unit mainUnit = UnitHelper.GetMyUnitFromClientScene(scene);
            bool canattack = mainUnit.IsCanAttackUnit(unit) || unit.IsCanAttackUnit(mainUnit);
            unit.GetComponent<SkillYujingComponent>()?.ShowMonsterSkillYujin(args.SkillInfo, args.SkillConfig.SkillDelayTime, canattack);

            await ETTask.CompletedTask;
        }
    }
}