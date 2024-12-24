using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 旋转攻击
    /// </summary>
    public class Skill_XuanZhuan_Attack : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            skillS.ICheckShape.Clear();
            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split(';');
            int angle = skillS.SkillInfo.TargetAngle;
            int range = paraminfos.Length > 1 ? int.Parse(paraminfos[0]) : 0;
            int number = paraminfos.Length > 1 ? int.Parse(paraminfos[1]) : 1;
            int delta = number > 1 ? range / (number - 1) : 0;
            int starAngle = angle - (int)(range * 0.5f);
            /// 写死3 错误做法 
            for (int i = 0; i < number; i++)
            {
                skillS.ICheckShape.Add(skillS.CreateCheckShape(starAngle + i * delta));
            }
            OnExecute(skillS);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
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
            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split(';');
            int angle = skillS.SkillInfo.TargetAngle;
            int speed = paraminfos.Length > 1 ? int.Parse(paraminfos[0]) : 0;   //每秒转多少角度
            int number = paraminfos.Length > 1 ? int.Parse(paraminfos[1]) : 1;

            //两条线的间隔
            int delta = 0;
            int starAngle = angle;
            if (number > 1)
            {
                delta = (int)math.floor(360f / number);
                starAngle = angle - 180;
            }
            long passTime = serverNow - skillS.SkillBeginTime;
            int addrangle = (int)(passTime * speed * 0.001f );
            for (int i = 0; i < skillS.ICheckShape.Count; i++)
            {
                int anglea_1 = starAngle + i * delta + addrangle;
                (skillS.ICheckShape[i] as Rectangle).s_forward = math.mul(quaternion.Euler(0, math.radians(anglea_1), 0), new float3(0, 0, 1));
            }
            skillS.TheUnitFrom.Rotation = quaternion.Euler(0, math.radians(angle + addrangle), 0);

            skillS.ExcuteSkillAction();
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
