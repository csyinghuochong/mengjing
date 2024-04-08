
using System.Collections.Generic;

namespace ET.Server
{

    //旋风斩
    public class Skill_Other_XuanFengZhan_1 : SkillHandlerS
    {
      
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
            this.SkillTriggerLastTime = TimeHelper.ServerNow();
        }

        public override void OnExecute(SkillS skillS)
        {
            this.InitSelfBuff();

            this.OnUpdate();
        }

        public override void OnUpdate(SkillS skillS)
        {
            //每间隔一段时间触发一次伤害
            long serverNow = TimeHelper.ServerNow();
            if (serverNow - this.SkillTriggerLastTime >= 250)
            {
                SkillTriggerLastTime = TimeHelper.ServerNow();
                HurtIds.Clear();
                this.UpdateCheckPoint(this.TheUnitFrom.Position);
                this.ExcuteSkillAction();
            }

            //技能存在时间
            if (serverNow > this.SkillEndTime)
            {
                this.SetSkillState(SkillState.Finished);
                return;
            }

            this.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }
    }
}
