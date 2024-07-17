namespace ET.Server
{
    /// <summary>
    /// 怪物连击
    /// </summary>
    public class Skill_Monster_Combo : SkillHandlerS
    {
        
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            //1;0@2;0                   时间;参数(保留字段)@ 时间;参数
            //1;90010503@2;90010503     时间;技能@ 时间;技能
            skillS.ComboTimeList.Clear();
            string[] skillparams = SkillConfigCategory.Instance.Get(skillS.SkillInfo.WeaponSkillID).GameObjectParameter.Split('@');
            for (int i = 0; i < skillparams.Length; i++)
            {
                string[] comboinfo = skillparams[i].Split(';');
                skillS.ComboTimeList.Add((long)(float.Parse(comboinfo[0]) * 1000));
            }
        }

        public override void OnExecute(SkillS skillS)
        {
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            //this.BaseOnUpdate();
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }
            skillS.HurtIds.Clear();  
            skillS.UpdateCheckPoint(skillS.TheUnitFrom.Position);
            skillS.ExcuteSkillAction();

            if (skillS.ComboTimeList.Count > 0)
            {
                skillS.SkillExcuteHurtTime = serverNow + skillS.ComboTimeList[0];
                skillS.ComboTimeList.RemoveAt(0); 
            }
            if (serverNow > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
            }
        }


        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }

    }
}
