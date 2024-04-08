
namespace ET.Server
{

    //子弹2
    public class Skill_ComTargetMove_RangDamge_2 : SkillHandlerS
    {
      
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);

            this.SkillExcuteNum = int.Parse(this.SkillConf.GameObjectParameter);
        }

        public override void OnExecute(SkillS skillS)
        {
            if (this.SkillExcuteNum > 100)
            {
                Log.Error($"Skill_ComTargetMove_RangDamge_2: {this.SkillConf.Id}");
                return;
            }

            for (int i = 0; i < this.SkillExcuteNum; i++)
            {
                //BuffData buffData = new BuffData();
                //buffData.BuffId = 7;
                //buffData.SkillId = this.SkillConf.Id;
                //buffData.TargetAngle = 360 / SkillExcuteNum * i;      //设置旋转球出现的位置
                //this.TheUnitFrom.GetComponent<BuffManagerComponent>().BulletFactory(buffData, TheUnitFrom, this);

                Unit unit = UnitFactory.CreateBullet(this.TheUnitFrom.DomainScene(),  this.TheUnitFrom.Id, this.SkillConf.Id, 360 / SkillExcuteNum * i, this.TheUnitFrom.Position, new CreateMonsterInfo());
                unit.AddComponent<RoleBullet2Componnet>().OnBaseBulletInit(this, this.TheUnitFrom.Id);
            }

            this.OnUpdate();
        }

        public override void OnUpdate(SkillS skillS)
        {
            if (TimeHelper.ServerNow() > SkillEndTime)
            {
                this.SetSkillState(SkillState.Finished);
                return;
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }
    }
}
