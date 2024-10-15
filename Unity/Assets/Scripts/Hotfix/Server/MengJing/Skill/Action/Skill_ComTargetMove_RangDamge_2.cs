
namespace ET.Server
{

    //子弹2
    public class Skill_ComTargetMove_RangDamge_2 : SkillHandlerS
    {
      
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            skillS.SkillExcuteNum = int.Parse(skillS.SkillConf.GameObjectParameter);
        }

        public override void OnExecute(SkillS skillS)
        {
            if (skillS.SkillExcuteNum > 100)
            {
                Log.Error($"Skill_ComTargetMove_RangDamge_2: {skillS.SkillConf.Id}");
                return;
            }

            for (int i = 0; i < skillS.SkillExcuteNum; i++)
            {
                //BuffData buffData = new BuffData();
                //buffData.BuffId = 7;
                //buffData.SkillId = this.SkillConf.Id;
                //buffData.TargetAngle = 360 / SkillExcuteNum * i;      //设置旋转球出现的位置
                //this.TheUnitFrom.GetComponent<BuffManagerComponent>().BulletFactory(buffData, TheUnitFrom, this);

                Unit unit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(),  skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 360 / skillS.SkillExcuteNum * i, skillS.TheUnitFrom.Position, new CreateMonsterInfo());
                //unit.AddComponent<RoleBullet2Componnet>().OnBaseBulletInit(this, this.TheUnitFrom.Id);  //类似这种注释都要解开并测试
            }

            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            if (TimeHelper.ServerNow() > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
