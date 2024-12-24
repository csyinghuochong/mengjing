namespace ET.Server
{
    /// <summary>
    /// 光环2
    /// </summary>
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

       
        public override void OnUpdate(SkillS skillS,int updateMode)
        {
            if (updateMode == 1)
            {
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
