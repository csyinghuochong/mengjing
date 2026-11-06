using System;
using System.Globalization;
using Unity.Mathematics;

namespace ET.Client
{
    public class Skill_SkyDive : SkillHandlerC
    {
        private static float[] Parameters(SkillConfig config)
        {
            string[] values = config.GameObjectParameter.Split(';');
            if (values.Length != 5) throw new ArgumentException("天穹俯冲参数应为5项。");
            float[] result = new float[5];
            for (int i = 0; i < result.Length; i++) result[i] = float.Parse(values[i], CultureInfo.InvariantCulture);
            return result;
        }

        // 与服务端保持相同曲线，不向Share添加类型。
        public static float3 FlightPosition(float3 origin, float3 landing, float seconds, float height,
                float rise, float hover, float dive, bool groundOnly = false)
        {
            if (seconds <= 0) return origin;
            if (seconds < rise)
            {
                float progress = math.saturate(seconds / rise);
                return origin + new float3(0, groundOnly ? 0 : height * progress * (2 - progress), 0);
            }
            if (seconds < rise + hover) return origin + new float3(0, groundOnly ? 0 : height, 0);
            float t = math.saturate((seconds - rise - hover) / dive);
            float accelerated = t * t;
            float3 ground = math.lerp(origin, landing, accelerated);
            return ground + new float3(0, groundOnly ? 0 : height * (1 - accelerated), 0);
        }

        public override void OnInit(SkillC skill, Unit caster)
        {
            skill.BaseOnInit(skill.SkillInfo, caster);
            skill.NowPosition = caster.Position;
            skill.SkillExcuteHurtTime = skill.SkillInfo.SkillBeginTime + (long)(skill.SkillConf.SkillDelayTime * 1000);
            skill.IsExcuteHurt = true;
            OnExecute(skill);
        }

        public override void OnExecute(SkillC skill)
        {
            skill.TheUnitFrom.GetComponent<MoveComponent>()?.Stop(false);
            skill.OnShowSkillIndicator(skill.SkillInfo);
            OnUpdate(skill);
        }

        public override void OnUpdate(SkillC skill)
        {
            Unit caster = skill.TheUnitFrom;
            if (caster.IsDisposed || caster.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_Dead) != 0)
            {
                skill.SetSkillState(SkillState.Finished);
                return;
            }
            long now = TimeHelper.ServerNow();
            if (skill.IsExcuteHurt)
            {
                float[] p = Parameters(skill.SkillConf);
                caster.Position = FlightPosition(skill.NowPosition, skill.TargetPosition,
                        (now - skill.SkillInfo.SkillBeginTime) * 0.001f, p[0], p[1], p[2], p[3]);
                caster.Rotation = quaternion.Euler(0, math.radians(skill.SkillInfo.TargetAngle), 0);
                if (now >= skill.SkillExcuteHurtTime && now < skill.SkillInfo.SkillEndTime)
                {
                    // 特效表延迟必须为0；统一由SkillBeginTime+SkillDelayTime控制。
                    skill.PlaySkillEffects(skill.TargetPosition);
                }
            }
            skill.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skill)
        {
            Unit caster = skill.TheUnitFrom;
            if (!caster.IsDisposed && skill.IsExcuteHurt)
            {
                float[] p = Parameters(skill.SkillConf);
                caster.Position = FlightPosition(skill.NowPosition, skill.TargetPosition,
                        (TimeHelper.ServerNow() - skill.SkillInfo.SkillBeginTime) * 0.001f,
                        p[0], p[1], p[2], p[3], true);
            }
            skill.EndSkillEffect();
        }
    }
}
