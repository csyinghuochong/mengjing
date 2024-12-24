namespace ET.Server
{

    /// <summary>
    /// 闪现2(怪物技能)
    /// </summary>
    public class Skill_ShanXian_2 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            if (skillS.SkillConf.GameObjectParameter == "0")
            {
                //先跳过去再触发伤害
                this.SyncPostion(skillS);
                skillS.InitSelfBuff();
            }
            else
            {
                //先触发伤害再跳过去
                skillS.UpdateCheckPoint(skillS.TheUnitFrom.Position);
                skillS.InitSelfBuff();
            }

            this.OnUpdate(skillS, 0);
        }

        public void SyncPostion(SkillS skillS)
        {
            if (skillS.TheUnitFrom.GetComponent<StateComponentS>().CanMove() == ErrorCode.ERR_Success)
            {
                skillS.TheUnitFrom.Position = skillS.TargetPosition;
                skillS.TheUnitFrom.Stop(-3);
            }
            else
            {
                Log.Debug($"FsmStateEnum.ShanXian被定[S] {skillS.TargetPosition}");
            }
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            skillS.BaseOnUpdate();
            if (skillS.SkillConf.GameObjectParameter == "1" && serverNow > skillS.SkillExcuteHurtTime)
            {
                this.SyncPostion(skillS);
                skillS.SetSkillState(SkillState.Finished);
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
