using NLog.Targets;
using System.Collections.Generic;
namespace ET.Server
{
    //钩子技能:指定范围
    public class Skill_Hook_2 : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            this.InitSelfBuff();

            List<Unit> units = this.TheUnitFrom.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || this.TheUnitFrom.Id == unit.Id)
                {
                    continue;
                }
                if (!this.CheckShape(unit.Position))
                {
                    continue;
                }

                if (!this.TheUnitFrom.IsCanAttackUnit(unit))
                {
                    continue;
                }
                Vector3 dir = (unit.Position - this.TheUnitFrom.Position).normalized;

                unit.GetComponent<MoveComponent>().Clear();
                unit.Position = dir * Vector3.one + this.TheUnitFrom.Position;
                unit.Stop(-2);
            }

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
