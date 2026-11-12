namespace ET.Server
{
    /// <summary>
    /// 一枚技能符文实例。
    /// 技能符文可以升级（SkillRuneConfig.NextId 串下一级），也可以自由换装到任意主动技能上，
    /// 所以每获得一枚就生成一个独立实例，用 Id 区分，等级看 ConfigId 对应的配置行
    /// </summary>
    [EnableClass]
    public class SkillRuneData
    {
        /// <summary>
        /// 唯一 id
        /// </summary>
        public long Id;

        /// <summary>
        /// SkillRuneConfig.Id，当前等级那一行
        /// </summary>
        public int ConfigId;
    }
}
