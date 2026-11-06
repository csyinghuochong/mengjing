using System;
using System.Globalization;
using Unity.Mathematics;

namespace ET.Server
{
    public class Skill_SkyDive : SkillHandlerS
    {
        private static float[] Parameters(SkillConfig config)
        {
            string[] values = config.GameObjectParameter.Split(';');
            if (values.Length != 5) throw new ArgumentException("天穹俯冲参数：高度;升空秒数;停留秒数;俯冲秒数;落点后退距离");
            float[] result = new float[5];
            for (int i = 0; i < result.Length; i++) result[i] = float.Parse(values[i], CultureInfo.InvariantCulture);
            if (!math.all(math.isfinite(new float4(result[0], result[1], result[2], result[3])))
                || !float.IsFinite(result[4]) || result[0] <= 0 || result[1] <= 0 || result[2] < 0
                || result[3] <= 0 || result[4] < 0
                || math.abs(result[1] + result[2] + result[3] - (float)config.SkillDelayTime) > 0.001f
                || config.SkillLiveTime <= config.SkillDelayTime * 1000
                || config.DamgeRangeType != 3 || config.DamgeRange.Length != 2
                || config.DamgeRange[0] <= 0 || config.DamgeRange[1] <= 0 || config.DamgeRange[1] > 90)
                throw new ArgumentException("天穹俯冲高度、时间、扇形范围配置无效。");
            return result;
        }

        // 客户端使用相同曲线。当前位置是空中坐标，伤害始终只在落地执行。
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

        public override void OnInit(SkillS skill, Unit caster)
        {
            skill.BaseOnInit(skill.SkillInfo, caster);
            float[] p = Parameters(skill.SkillConf);
            if (caster.Type != UnitType.Monster) throw new ArgumentException("天穹俯冲用于怪物。");
            skill.NowPosition = caster.Position;
            float3 difference = skill.TargetPosition - caster.Position;
            difference.y = 0;
            float distance = math.length(difference);
            float3 direction = distance > 0.001f ? difference / distance
                    : math.mul(quaternion.Euler(0, math.radians(skill.SkillInfo.TargetAngle), 0), math.forward());
            // 此版最后一项配0：主角施法瞬间的位置就是圆心和实际落点。
            float3 requested = skill.TargetPosition - direction * math.min(p[4], distance * 0.5f);
            // 俯冲可越过地面路径阻挡，不用地面冲撞寻路把圆心截到半路。
            skill.TargetPosition = requested;
            skill.SkillInfo.PosX = skill.TargetPosition.x;
            skill.SkillInfo.PosY = skill.TargetPosition.y;
            skill.SkillInfo.PosZ = skill.TargetPosition.z;
            skill.SkillInfo.TargetAngle = (int)math.round(math.degrees(math.atan2(direction.x, direction.z)));
            skill.UpdateCheckPoint(skill.TargetPosition);
            skill.UpdateCheckRotation(skill.SkillInfo.TargetAngle);
        }

        private static bool ActiveInvulnerability(BuffS buff, long now)
        {
            return buff.BuffState == BuffState.Running && buff.IsTrigger && buff.BuffEndTime > now
                    && buff.mBuffConfig.BuffType == 2 && buff.mBuffConfig.buffParameterType == 18;
        }

        public override void OnExecute(SkillS skill)
        {
            Unit caster = skill.TheUnitFrom;
            caster.Stop(-3);
            BuffManagerComponentS manager = caster.GetComponent<BuffManagerComponentS>();
            bool hasBuff = false;
            foreach (BuffS buff in manager.m_Buffs) hasBuff |= ActiveInvulnerability(buff, TimeHelper.ServerNow());
            // 保留非Buff来源的既有无敌状态；普通Buff来源则按剩余有效Buff恢复。
            skill.SpeedAddValue = caster.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.WuDi) && !hasBuff ? 1 : 0;
            // 明确加给施法怪物；不受通用SkillBuff中“当前不可被攻击”的过滤影响。
            foreach (int buffId in skill.SkillConf.InitBuffID)
            {
                if (buffId != 0) manager.BuffFactory(new BuffData { SkillId = skill.SkillConf.Id, BuffId = buffId }, caster, skill);
            }
            OnUpdate(skill, 0);
        }

        private static void RemoveFlightBuff(SkillS skill)
        {
            Unit caster = skill.TheUnitFrom;
            if (caster.IsDisposed) return;
            BuffManagerComponentS manager = caster.GetComponent<BuffManagerComponentS>();
            bool removed = false;
            foreach (BuffS buff in manager.m_Buffs)
            {
                if (buff.TheUnitFrom.Id == caster.Id && buff.BuffData.SkillId == skill.SkillConf.Id
                    && Array.IndexOf(skill.SkillConf.InitBuffID, buff.mBuffConfig.Id) >= 0)
                {
                    buff.BuffState = BuffState.WaitRemove;
                    removed = true;
                }
            }
            if (manager.Checking) return;
            if (removed) manager.Check();
            bool retain = skill.SpeedAddValue == 1;
            foreach (BuffS buff in manager.m_Buffs) retain |= ActiveInvulnerability(buff, TimeHelper.ServerNow());
            if (retain) caster.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.WuDi);
            else caster.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.WuDi);
        }

        public override void OnUpdate(SkillS skill, int updateMode)
        {
            Unit caster = skill.TheUnitFrom;
            long now = TimeHelper.ServerNow();
            if (caster.IsDisposed || caster.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) != 0)
            {
                skill.SetSkillState(SkillState.Finished);
                return;
            }
            if (skill.IsExcuteHurt)
            {
                if (now >= skill.SkillEndTime) skill.SetSkillState(SkillState.Finished);
                return;
            }
            if (now >= skill.SkillEndTime)
            {
                skill.SetSkillState(SkillState.Finished);
                return;
            }
            float[] p = Parameters(skill.SkillConf);
            // 避免其他同状态Buff到期移除状态位后，腾空期间出现无敌空档。
            StateComponentS state = caster.GetComponent<StateComponentS>();
            if (!state.StateTypeGet(StateTypeEnum.WuDi)) state.StateTypeAdd(StateTypeEnum.WuDi);
            caster.Position = FlightPosition(skill.NowPosition, skill.TargetPosition,
                    (now - skill.SkillBeginTime) * 0.001f, p[0], p[1], p[2], p[3]);
            caster.Rotation = quaternion.Euler(0, math.radians(skill.SkillInfo.TargetAngle), 0);
            if (now < skill.SkillExcuteHurtTime) return;

            caster.Position = skill.TargetPosition;
            skill.IsExcuteHurt = true;
            RemoveFlightBuff(skill);
            caster.Stop(-3);
            skill.UpdateCheckPoint(caster.Position);
            // 通用Fan对零向量归一化会得到NaN，落点正中心单独补判一次。
            foreach (EntityRef<Unit> reference in caster.GetParent<UnitComponent>().GetAll())
            {
                Unit target = reference;
                if (target == null || target.IsDisposed || target.Type == UnitType.Npc || target.Type == UnitType.Transfers
                    || math.distancesq(target.Position, caster.Position) > 0.000001f || skill.IfHaveHurtId(target.Id)) continue;
                skill.OnAddHurtIds(target.Id);
                skill.OnCollisionUnit(target);
            }
            skill.ExcuteSkillAction();
        }

        public override void OnFinished(SkillS skill)
        {
            Unit caster = skill.TheUnitFrom;
            if (!caster.IsDisposed && !skill.IsExcuteHurt)
            {
                float[] p = Parameters(skill.SkillConf);
                caster.Position = FlightPosition(skill.NowPosition, skill.TargetPosition,
                        (TimeHelper.ServerNow() - skill.SkillBeginTime) * 0.001f, p[0], p[1], p[2], p[3], true);
                caster.Stop(-3);
            }
            if (!skill.IsExcuteHurt) RemoveFlightBuff(skill);
            skill.Clear();
        }
    }
}
