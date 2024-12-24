using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 钩子技能:指定目标
    /// </summary>
    public class Skill_Hook_1 : SkillHandlerS
    {
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            skillS.TheUnitTarget = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(skillS.SkillInfo.TargetID);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();

            float3 dir = (skillS.TheUnitTarget.Position - skillS.TheUnitFrom.Position).normalize();

            skillS.TheUnitTarget.GetComponent<MoveComponent>().Stop(true);
            skillS.TheUnitTarget.Position =  math.mul(dir, new float3(1,1,1)) + skillS.TheUnitFrom.Position;
            skillS.TheUnitTarget.Stop(-2);

            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            skillS.BaseOnUpdate();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
