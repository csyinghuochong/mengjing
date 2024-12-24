
using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 子弹1
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_1 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            //60; 5; 0.3; 3
            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split(';');//0;1;0.3;2  90011941
            if (paraminfos.Length >= 4)
            {
                skillS.SkillTriggerLastTime = 0;
                skillS.SkillTriggerInvelTime = (long)(float.Parse(paraminfos[2]) * 1000);
                skillS.SkillExcuteNum = int.Parse(paraminfos[3]);
            }
            else
            {
                skillS.SkillExcuteNum = 1;
            }
        }

        public float3 GetBulletTargetPoint(SkillS skillS, int angle)
        {
            float3 sourcePoint = skillS.TheUnitFrom.Position;
            quaternion rotation = quaternion.Euler(0, math.radians(angle), 0);
            
            float moveSpeed = skillS.SkillConf.SkillLiveTime * (float)skillS.SkillConf.SkillMoveSpeed * 0.001f;
            float3 normalizeSpeed = math.forward(math.normalize(rotation)).normalize();
            float3 TargetPoint = sourcePoint +  normalizeSpeed* moveSpeed;
            TargetPoint.y +=SkillHelp.GetCenterHigh(skillS.TheUnitFrom.Type, skillS.TheUnitFrom.ConfigId);
            return TargetPoint;
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
            long serverTime = TimeHelper.ServerNow();
            if (serverTime - skillS.SkillTriggerLastTime < skillS.SkillTriggerInvelTime)
            {
                return;
            }

            skillS.HurtIds.Clear();
            skillS.SkillTriggerLastTime = serverTime;
            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split(';');
            int angle = skillS.SkillInfo.TargetAngle;
            int range = paraminfos.Length > 1 ? int.Parse(paraminfos[0]) : 0;
            int number = paraminfos.Length > 1 ? int.Parse(paraminfos[1]) : 1;
            int delta = number > 1 ? range / (number - 1) : 0;
            int starAngle = angle - (int)(range * 0.5f);

            if (number > 100)
            {
                return;
            }
            for (int i = 0; i < number; i++)
            {
                float3 targetpos = this.GetBulletTargetPoint(skillS, starAngle + i * delta);
                Unit unit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 0, skillS.TheUnitFrom.Position, new CreateMonsterInfo());
                unit.AddComponent<RoleBullet1Componet>().OnBaseBulletInit(skillS, skillS.TheUnitFrom.Id);
                unit.BulletMoveToAsync(targetpos).Coroutine();
            }
            skillS.SkillExcuteNum--;
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();

            CreateBullet(skillS);

            OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            CreateBullet(skillS);

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
