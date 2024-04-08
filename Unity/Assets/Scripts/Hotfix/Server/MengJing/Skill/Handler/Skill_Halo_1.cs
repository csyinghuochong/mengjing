namespace ET.Server
{
    //光环
    public class Skill_Halo_1 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            this.InitSelfBuff();
            this.OnUpdate();
        }

        public override void OnUpdate(SkillS skillS)
        {
            this.BaseOnUpdate();

            this.IsExcuteHurt = false;
            this.UpdateCheckPoint(this.TheUnitFrom.Position);
            for (int i = HurtIds.Count - 1; i >= 0; i--)
            {
                Unit unit = this.TheUnitFrom.Domain.GetComponent<UnitComponent>().Get(HurtIds[i]);
                if (unit == null || unit.IsDisposed)
                {
                    HurtIds.RemoveAt(i);
                    continue;
                }
                if (!this.CheckShape(unit.Position))
                {
                    unit.GetComponent<BuffManagerComponent>().BuffRemoveByUnit(0, SkillConf.BuffID[0]);
                    this.HurtIds.RemoveAt(i);
                    continue;
                }
                if (!unit.IsCanBeAttack())
                {
                    this.HurtIds.RemoveAt(i);
                    continue;
                }
            }
            this.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }

    }
}
