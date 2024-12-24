namespace ET.Server
{
    /// <summary>
    /// 量子导弹
    /// </summary>
    public class Skill_Follow_Damge_1 : SkillHandlerS
    {
        
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            skillS.SkillTriggerInvelTime = (long)(float.Parse(skillS.SkillConf.GameObjectParameter) * 1000);
            skillS.SkillTriggerLastTime = 0;
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.BulletUnit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 0, skillS.NowPosition, new CreateMonsterInfo());
            skillS.BulletUnit.AddComponent<DeathTimeComponent, long>((long)(skillS.SkillConf.SkillLiveTime * 1000 + TimeHelper.Minute));

            this.GetTheUnitTarget(skillS);
            this.OnUpdate(skillS, 0);
        }

        public void GetTheUnitTarget(SkillS skillS)
        {
            //寻找最近的可攻击对象
            skillS.TheUnitTarget = GetTargetHelpS.GetNearestEnemyByPosition(skillS.TheUnitFrom, skillS.BulletUnit.Position, 10);
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
            //根据技能存在时间设置其结束状态
            if (serverNow > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
            if (skillS.BulletUnit == null || skillS.BulletUnit.IsDisposed)
            {
                return;
            }
            if (skillS.TheUnitTarget == null || skillS.TheUnitTarget.IsDisposed)
            {
                this.GetTheUnitTarget(skillS);
                return;
            }
           
            if (serverNow - skillS.SkillTriggerLastTime < skillS.SkillTriggerInvelTime)
            {
                return;
            }
            skillS.SkillTriggerLastTime = serverNow;
            skillS.HurtIds.Clear();
            skillS.UpdateCheckPoint(skillS.BulletUnit.Position);
            skillS.ExcuteSkillAction();
            skillS.BulletUnit.BulletMoveToAsync(skillS.TheUnitTarget.Position).Coroutine();
        }

        public override void OnFinished(SkillS skillS)
        {
            //移除Unity
            if (skillS.BulletUnit != null && !skillS.BulletUnit.IsDisposed)
            {
                skillS.BulletUnit.GetParent<UnitComponent>().Remove(skillS.BulletUnit.Id);
            }
            skillS.Clear();
        }
    } 

}
