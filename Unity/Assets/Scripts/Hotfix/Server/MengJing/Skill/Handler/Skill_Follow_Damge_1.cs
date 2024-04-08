﻿namespace ET.Server
{
    //量子导弹
    public class Skill_Follow_Damge_1 : SkillHandlerS
    {
        private Unit BulletUnit;

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
            this.SkillTriggerInvelTime = (long)(float.Parse(SkillConf.GameObjectParameter) * 1000);
            this.SkillTriggerLastTime = 0;
        }

        public override void OnExecute(SkillS skillS)
        {
            this.BulletUnit = UnitFactory.CreateBullet(this.TheUnitFrom.DomainScene(), this.TheUnitFrom.Id, this.SkillConf.Id, 0, this.NowPosition, new CreateMonsterInfo());
            this.BulletUnit.AddComponent<DeathTimeComponent, long>((long)(this.SkillConf.SkillLiveTime * 1000 + TimeHelper.Minute));

            this.GetTheUnitTarget();
            this.OnUpdate();
        }

        public void GetTheUnitTarget()
        {
            //寻找最近的可攻击对象
            this.TheUnitTarget = AIHelp.GetNearestEnemyByPosition(this.TheUnitFrom, this.BulletUnit.Position, 10);
        }

        public override void OnUpdate(SkillS skillS)
        {
            //this.BaseOnUpdate();
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < this.SkillExcuteHurtTime)
            {
                return;
            }
            //根据技能存在时间设置其结束状态
            if (serverNow > this.SkillEndTime)
            {
                this.SetSkillState(SkillState.Finished);
                return;
            }
            if (this.BulletUnit == null || this.BulletUnit.IsDisposed)
            {
                return;
            }
            if (this.TheUnitTarget == null || this.TheUnitTarget.IsDisposed)
            {
                this.GetTheUnitTarget();
                return;
            }
           
            if (serverNow - this.SkillTriggerLastTime < this.SkillTriggerInvelTime)
            {
                return;
            }
            this.SkillTriggerLastTime = serverNow;
            this.HurtIds.Clear();
            this.UpdateCheckPoint(this.BulletUnit.Position);
            this.ExcuteSkillAction();
            this.BulletUnit.BulletMoveToAsync(this.TheUnitTarget.Position).Coroutine();
        }

        public override void OnFinished(SkillS skillS)
        {
            //移除Unity
            if (this.BulletUnit != null && !this.BulletUnit.IsDisposed)
            {
                this.BulletUnit.GetParent<UnitComponent>().Remove(BulletUnit.Id);
            }
            this.Clear();
        }
    } 

}
