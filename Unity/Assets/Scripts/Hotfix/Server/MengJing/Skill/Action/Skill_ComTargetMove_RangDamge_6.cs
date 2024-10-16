using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 向前方释放一个火球火球移动过程造成一次伤害，移动x秒后位置固定，并且对周围造成持续伤害持续伤害间隔时间，中途碰撞时是否停下
    /// 参数（移动时间，伤害间隔时间，碰撞是否停下）
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_6 : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split(';');
            skillS.MoveTime = (long)(float.Parse(paraminfos[0]) * 1000);
            skillS.SkillTriggerInvelTime = (long)(float.Parse(paraminfos[1]) * 1000);
            skillS.IsStop = int.Parse(paraminfos[2]);

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

        public void CreateBullet(SkillS skillS)
        {
            if (TimeHelper.ServerNow() < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            if (skillS.SkillExcuteNum <= 0)
            {
                return;
            }

            Unit unit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 0,
                skillS.TheUnitFrom.Position,
                new CreateMonsterInfo());
            unit.AddComponent<RoleBullet6Componnet>().OnBaseBulletInit(skillS, skillS.TheUnitFrom.Id, skillS.IsStop);
            float3 sourcePoint = skillS.TheUnitFrom.Position;
            quaternion rotation = quaternion.Euler(0, math.radians(skillS.SkillInfo.TargetAngle), 0);
            float3 TargetPoint = sourcePoint +
                    math.mul(rotation, new float3(0, 0, 1)) * skillS.MoveTime * (float)skillS.SkillConf.SkillMoveSpeed * 0.001f;
            unit.BulletMoveToAsync(TargetPoint).Coroutine();
            skillS.SkillExcuteNum--;
        }
    }
}