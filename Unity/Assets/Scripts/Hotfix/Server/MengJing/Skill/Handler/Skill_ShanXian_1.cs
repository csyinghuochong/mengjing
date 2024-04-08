namespace ET.Server
{

    //闪现(玩家技能）
    public class Skill_ShanXian_1 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            if (this.SkillConf.GameObjectParameter == "0")
            {
                //先跳过去再触发伤害
                this.SyncPostion();
                this.InitSelfBuff();
            }
            else
            {
                //先触发伤害再跳过去
                this.UpdateCheckPoint(this.TheUnitFrom.Position);
                this.InitSelfBuff();
            }

            this.OnUpdate();
        }

        public void SyncPostion()
        {
            if (this.TheUnitFrom.GetComponent<StateComponent>().CanMove() == ErrorCode.ERR_Success)
            {
                TheUnitFrom.Position = this.TargetPosition;
                TheUnitFrom.Stop(-3);
            }
            else
            {
                Log.Debug($"FsmStateEnum.ShanXian被定[S] {TargetPosition}");
            }
        }

        public override void OnUpdate(SkillS skillS)
        {
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < this.SkillExcuteHurtTime)
            {
                return;
            }

            this.BaseOnUpdate();
            if (this.SkillConf.GameObjectParameter == "1"  && serverNow > this.SkillExcuteHurtTime)
            {
                this.SyncPostion();
                this.SetSkillState( SkillState.Finished);
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }
    }
}
