namespace ET.Server
{

    /// <summary>
    /// 多条裂地斩
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_3 : SkillHandlerS
    {
        
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            skillS.ICheckShape.Clear();
            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split(';');
            int angle = skillS.SkillInfo.TargetAngle;
            int range = paraminfos.Length > 1 ? int.Parse(paraminfos[0]) : 0;
            int number = paraminfos.Length > 1 ? int.Parse(paraminfos[1]) : 1;
            int delta = number > 1 ? range / (number - 1) : 0;
            int starAngle = angle - (int)(range * 0.5f);

            for (int i = 0; i < 3; i++)
            {
                skillS.ICheckShape.Add(skillS.CreateCheckShape(starAngle + i * delta));
            }
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();

            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }
            //根据技能存在时间设置其结束状态
            if (serverNow > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
            if (!skillS.IsExcuteHurt)
            {
                skillS.IsExcuteHurt= true;
                skillS.ExcuteSkillAction();
                skillS.CheckChiXuHurt();
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }

    }
}
