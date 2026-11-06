using System;

namespace ET.Server
{
    // 前方随机多方向地刺。参数：扇面角度;数量，例如120;3。
    public class Skill_CrystalSpikes : Skill_Action_Common
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            base.OnInit(skillS, theUnitFrom);
            string[] parameters = skillS.SkillConf.GameObjectParameter.Split(';');
            if (parameters.Length != 2 || !int.TryParse(parameters[0], out int spread)
                || !int.TryParse(parameters[1], out int count)
                || spread < 0 || spread > 180 || count < 1 || count > 16
                || skillS.SkillConf.DamgeRangeType != 2
                || skillS.SkillConf.DamgeRange.Length != 2
                || skillS.SkillConf.DamgeRange[0] <= 0 || skillS.SkillConf.DamgeRange[1] <= 0
                || skillS.SkillConf.SkillDelayTime < 0
                || skillS.SkillConf.SkillLiveTime <= skillS.SkillConf.SkillDelayTime * 1000)
            {
                throw new ArgumentException($"水晶地刺配置无效: {skillS.SkillConf.Id}; 参数应为角度;数量，范围应为矩形宽,长，存在时间须大于命中延迟。");
            }

            // 该时间随后由SkillManager写入并广播SkillInfo，客户端使用同一个种子。
            int[] angles = Directions.Build(skillS.SkillBeginTime, theUnitFrom.Id,
                    skillS.SkillConf.Id, skillS.SkillInfo.TargetAngle, spread, count);
            skillS.ICheckShape.Clear();
            for (int i = 0; i < angles.Length; i++)
            {
                skillS.ICheckShape.Add(skillS.CreateCheckShape(angles[i]));
            }
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
