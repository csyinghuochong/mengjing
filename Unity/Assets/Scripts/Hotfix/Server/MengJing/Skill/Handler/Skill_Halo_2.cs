using System.Collections.Generic;
namespace ET.Server
{
    //光环2
    public class Skill_Halo_2 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            this.IsExcuteHurt = true;
            this.InitSelfBuff();
            this.OnUpdate();
        }

        public void Check_Map( )
        {
            List<Unit> entities = this.TheUnitFrom.DomainScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Type != UnitType.Player)
                {
                    continue;
                }
                if (this.TheUnitFrom.IsSameTeam(entities[i]))
                {
                    this.OnCollisionUnit(entities[i]);
                }
            }
        }

        public override void OnUpdate(SkillS skillS)
        {

            this.BaseOnUpdate();
            
            this.CheckChiXuHurt();

            //this.UpdateCheckPoint(this.TheUnitFrom.Position);
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }

    }
}
