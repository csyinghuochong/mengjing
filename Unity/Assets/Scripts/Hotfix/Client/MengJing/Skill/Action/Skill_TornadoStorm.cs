namespace ET.Client
{
    // 龙卷风画面由服务器生成的Bullet实体负责，避免在施法者脚下重复生成特效。
    public class Skill_TornadoStorm : SkillHandlerC
    {
        public override void OnInit(SkillC skill, Unit caster)
        {
            skill.BaseOnInit(skill.SkillInfo, caster);
            OnExecute(skill);
        }

        public override void OnExecute(SkillC skill)
        {
            OnUpdate(skill);
        }

        public override void OnUpdate(SkillC skill)
        {
            skill.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skill)
        {
        }
    }
}
