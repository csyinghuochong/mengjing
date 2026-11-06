using System;
using Unity.Mathematics;

namespace ET.Client
{
    // 与服务端同名，分别由各自的 SkillDispatcher 注册。
    public class Skill_CrystalSpikes : Skill_Action_Common
    {
        private static int[] GetAngles(SkillC skill, int spread, int count)
        {
            return Directions.Build(skill.SkillInfo.SkillBeginTime, skill.TheUnitFrom.Id,
                    skill.SkillConf.Id, skill.SkillInfo.TargetAngle, spread, count);
        }

        private static void ReadParameters(SkillC skill, out int spread, out int count)
        {
            string[] parameters = skill.SkillConf.GameObjectParameter.Split(';');
            if (parameters.Length != 2 || !int.TryParse(parameters[0], out spread)
                || !int.TryParse(parameters[1], out count)
                || spread < 0 || spread > 180 || count < 1 || count > 16
                || skill.SkillConf.DamgeRangeType != 2 || skill.SkillConf.DamgeRange.Length != 2
                || skill.SkillConf.DamgeRange[0] <= 0 || skill.SkillConf.DamgeRange[1] <= 0)
            {
                throw new ArgumentException($"水晶地刺客户端配置无效: {skill.SkillConf.Id}");
            }
        }

        public override void OnInit(SkillC skill, Unit theUnitFrom)
        {
            skill.BaseOnInit(skill.SkillInfo, theUnitFrom);
            // 命中时间和服务端共用 SkillBeginTime + SkillDelayTime。
            // 特效表的 SkillEffectDelayTime 必须为0，避免再次延迟。
            skill.SkillExcuteHurtTime = skill.SkillInfo.SkillBeginTime
                    + (long)(skill.SkillConf.SkillDelayTime * 1000);
            this.OnExecute(skill);
        }

        public override void OnExecute(SkillC skill)
        {
            ReadParameters(skill, out int spread, out int count);
            int[] angles = GetAngles(skill, spread, count);
            for (int i = 0; i < count; i++)
            {
                SkillInfo indicator = CommonHelp.DeepCopy<SkillInfo>(skill.SkillInfo);
                indicator.TargetAngle = angles[i];
                skill.OnShowSkillIndicator(indicator);
            }
            this.OnUpdate(skill);
        }

        public override void OnUpdate(SkillC skill)
        {
            long now = TimeHelper.ServerNow();
            if (skill.EffectId != 0 && skill.EffectInstanceId.Count == 0
                && now >= skill.SkillExcuteHurtTime && now < skill.SkillInfo.SkillEndTime)
            {
                ReadParameters(skill, out int spread, out int count);
                int[] angles = GetAngles(skill, spread, count);
                float distance = (float)skill.SkillConf.DamgeRange[1] * 0.5f;
                for (int i = 0; i < count; i++)
                {
                    int angle = angles[i];
                    float3 forward = math.mul(quaternion.Euler(0, math.radians(angle), 0), math.forward());
                    // 每个地刺组放在对应矩形伤害区域的中点，位置固定，不追踪目标。
                    // 通用特效加载器把0角度视为“沿用TargetAngle”，用等价的360度保留真正的0方向。
                    skill.PlaySkillEffects(skill.TargetPosition + forward * distance, angle == 0 ? 360f : angle);
                }
            }
            skill.BaseOnUpdate();
        }

        // 此算法在两端保持完全相同，不依赖Share新增文件。
        private static class Directions
        {
            public static int[] Build(long beginTime, long casterId, int skillId,
                    int centerAngle, int spread, int count)
            {
                if (spread < 0 || spread > 180 || count < 1 || count > 16 || count > spread + 1)
                {
                    throw new ArgumentException("地刺方向参数无效：数量不能超过扇面中可用的整数角度数量。");
                }

                uint state;
                unchecked
                {
                    state = (uint)beginTime ^ (uint)((ulong)beginTime >> 32);
                    state = (state ^ (uint)casterId) * 16777619u;
                    state = (state ^ (uint)((ulong)casterId >> 32)) * 16777619u;
                    state = (state ^ (uint)skillId) * 16777619u;
                }
                if (state == 0) state = 0x9E3779B9u;

                // 部分Fisher-Yates抽样，恰好选择count个不同的方向，允许覆盖区域重叠。
                int[] offsets = new int[spread + 1];
                for (int i = 0; i < offsets.Length; i++) offsets[i] = i - spread / 2;
                int[] angles = new int[count];
                for (int i = 0; i < count; i++)
                {
                    state ^= state << 13;
                    state ^= state >> 17;
                    state ^= state << 5;
                    int index = i + (int)(state % (uint)(offsets.Length - i));
                    int offset = offsets[index];
                    offsets[index] = offsets[i];
                    offsets[i] = offset;
                    angles[i] = centerAngle + offset;
                }
                Array.Sort(angles);
                return angles;
            }
        }
    }
}
