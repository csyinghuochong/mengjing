using System.Collections.Generic;
namespace ET.Server
{

    //钩子技能:指定目标
    public class Skill_Hook_1 : SkillHandlerS
    {
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
            this.TheUnitTarget = this.TheUnitFrom.GetParent<UnitComponent>().Get(this.SkillInfo.TargetID);
        }

        public override void OnExecute(SkillS skillS)
        {
            this.InitSelfBuff();

            Vector3 dir = (this.TheUnitTarget.Position - this.TheUnitFrom.Position ).normalized;

            this.TheUnitTarget.GetComponent<MoveComponent>().Clear();
            this.TheUnitTarget.Position = dir * Vector3.one + this.TheUnitFrom.Position;
            this.TheUnitTarget.Stop(-2);

            this.OnUpdate();
        }

        public override void OnUpdate(SkillS skillS)
        {
            this.BaseOnUpdate();
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }
    }
}
