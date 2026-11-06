using System;

namespace ET.Server
{
    // 静止的多方向地刺。参数：扇面角度;方向数量，例如 120;3。
    // 参考 Skill_XuanZhuan_Attack 的方向展开，复用通用技能的一次命中逻辑。
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

            skillS.ICheckShape.Clear();
            for (int i = 0; i < count; i++)
            {
                int angle = count == 1 ? skillS.SkillInfo.TargetAngle
                        : skillS.SkillInfo.TargetAngle - spread / 2 + i * spread / (count - 1);
                skillS.ICheckShape.Add(skillS.CreateCheckShape(angle));
            }
        }
    }
}
