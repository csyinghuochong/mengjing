using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 旋转攻击
    /// </summary>
    public class Skill_XuanZhuan_Attack_2 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            skillS.SkillTriggerInvelTime = 1000;
            skillS.SkillTriggerLastTime = TimeHelper.ServerNow();
            OnExecute(skillS);
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

            for (int i = 0; i < skillS.ICheckShape.Count; i++)
            {
                (skillS.ICheckShape[i] as Rectangle).s_forward = math.forward(skillS.TheUnitFrom.Rotation);
            }
            
            skillS.ExcuteSkillAction();
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
