namespace ET.Server
{
    /// <summary>
    /// 光环技能
    /// </summary>
    public class Skill_Halo_1 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            skillS.BaseOnUpdate();

            skillS.IsExcuteHurt = false;
            skillS.UpdateCheckPoint(skillS.TheUnitFrom.Position);
            for (int i = skillS.HurtIds.Count - 1; i >= 0; i--)
            {
                Unit unit = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(skillS.HurtIds[i]);
                if (unit == null || unit.IsDisposed)
                {
                    skillS.HurtIds.RemoveAt(i);
                    continue;
                }
                if (!skillS.CheckShape(unit.Position))
                {
                    unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, skillS.SkillConf.BuffID[0]);
                    skillS.HurtIds.RemoveAt(i);
                    continue;
                }
                if (!unit.IsCanBeAttack())
                {
                    skillS.HurtIds.RemoveAt(i);
                    continue;
                }
            }
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }

    }
}
