using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 一个技能上的技能符文孔位。
    /// 孔位数量由 GlobalValueConfig.SkillRuneSlotCount 决定，孔位记的是 SkillRuneData.Id，
    /// 符文实例本身仍留在 SkillRuneComponent.RuneList 里
    /// </summary>
    [EnableClass]
    public class SkillRuneSlotData
    {
        /// <summary>
        /// 基础技能 id：同一条技能升级链共用这个 id，由 SkillConfigCategory.GetInitSkill 换算得到。
        /// 不存当前等级的技能 id，这样技能升级换 SkillID 后符文不会丢
        /// </summary>
        public int SkillId;

        /// <summary>
        /// 各孔位镶嵌的技能符文 id，下标 0 对应界面上的 1 号孔，0 表示空孔。
        /// 长度由 SkillRuneComponentSystem 按 GlobalValueConfig.SkillRuneSlotCount 保证
        /// </summary>
        public List<long> RuneIds = new List<long>();
    }
}
