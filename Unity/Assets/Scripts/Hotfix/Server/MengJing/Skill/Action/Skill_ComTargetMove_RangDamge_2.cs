namespace ET.Server
{
    /// <summary>
    /// 子弹2
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_2 : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            skillS.SkillExcuteNum = int.Parse(skillS.SkillConf.GameObjectParameter);
        }

        public override void OnExecute(SkillS skillS)
        {
            if (skillS.SkillExcuteNum > 100)
            {
                Log.Error($"Skill_ComTargetMove_RangDamge_2: {skillS.SkillConf.Id}");
                return;
            }

            for (int i = 0; i < skillS.SkillExcuteNum; i++)
            {
                Unit unit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id,
                    360 / skillS.SkillExcuteNum * i, skillS.TheUnitFrom.Position, new CreateMonsterInfo());
                unit.AddComponent<RoleBullet2Componnet>().OnBaseBulletInit(skillS, skillS.TheUnitFrom.Id);
            }

            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            if (TimeHelper.ServerNow() > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}