using System.Collections.Generic;
namespace ET.Server
{
    //光环2
    public class Skill_Halo_2 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.IsExcuteHurt = true;
            skillS.InitSelfBuff();
            this.OnUpdate(skillS, 0);
        }

        public void Check_Map(SkillS skillS )
        {
            List<Unit> entities = skillS.TheUnitFrom.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Type != UnitType.Player)
                {
                    continue;
                }
                if (skillS.TheUnitFrom.IsSameTeam(entities[i]))
                {
                    skillS.OnCollisionUnit(entities[i]);
                }
            }
        }

        public override void OnUpdate(SkillS skillS,int updateMode)
        {
            if (updateMode == 1)
            {
                Check_Map(skillS);
                return;
            }


            skillS.BaseOnUpdate();
            
            skillS.CheckChiXuHurt();
            
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }

    }
}
