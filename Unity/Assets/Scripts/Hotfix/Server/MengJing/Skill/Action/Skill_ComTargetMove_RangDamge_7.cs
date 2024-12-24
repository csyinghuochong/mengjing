using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 立即对目标释放一个燃烧种子造成120%伤害,并持续燃烧对附近单位每秒造成70%伤害,持续5秒
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_7 : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            skillS.SkillTriggerInvelTime = 1000;
            skillS.SkillExcuteNum = 1;
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            this.CreateBullet(skillS);

            if (skillS.BulletUnit!= null && skillS.TheUnitTarget!=null)
            {
                skillS.BulletUnit.Position = skillS.TheUnitTarget.Position;
            }
            if (skillS.BulletUnit!= null && skillS.TheUnitTarget==null)
            {
                skillS.BulletUnit.GetParent<UnitComponent>().Remove(skillS.BulletUnit.Id);
                skillS.BulletUnit = null;
            }

            if (TimeHelper.ServerNow() > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }

            //skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            if (skillS.BulletUnit!= null )
            {
                skillS.BulletUnit.GetParent<UnitComponent>().Remove(skillS.BulletUnit.Id);
                skillS.BulletUnit = null;
            }
            skillS.Clear();
        }

        public void CreateBullet(SkillS skillS)
        {
            if (skillS.SkillExcuteNum <= 0)
            {
                return;
            }

            if (TimeHelper.ServerNow() < skillS.SkillExcuteHurtTime)
            {
                return;
            }
            
            Unit target = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(skillS.SkillInfo.TargetID);
            Unit unit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.SkillInfo.TargetID, skillS.SkillConf.Id, 0,
                target.Position,  new CreateMonsterInfo());
            unit.AddComponent<RoleBullet7Componnet>().OnBaseBulletInit(skillS, skillS.TheUnitFrom.Id);
            skillS.BulletUnit = unit;
            skillS.TheUnitTarget = target;
            skillS.SkillExcuteNum--;
        }
    }
}