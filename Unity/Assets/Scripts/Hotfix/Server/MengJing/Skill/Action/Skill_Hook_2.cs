using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 钩子技能:指定范围
    /// </summary>
    public class Skill_Hook_2 : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();

            List<EntityRef<Unit>> units = skillS.TheUnitFrom.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || skillS.TheUnitFrom.Id == unit.Id)
                {
                    continue;
                }
                if (!skillS.CheckShape(unit.Position))
                {
                    continue;
                }

                if (!skillS.TheUnitFrom.IsCanAttackUnit(unit))
                {
                    continue;
                }
                float3 dir = (unit.Position - skillS.TheUnitFrom.Position).normalize();

                unit.GetComponent<MoveComponent>().Stop(true);
                unit.Position = math.mul(dir ,new float3(1,1,1)) + skillS.TheUnitFrom.Position;
                unit.Stop(-2);
            }

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
