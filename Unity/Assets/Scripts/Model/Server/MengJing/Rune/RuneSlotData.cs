namespace ET.Server
{
    /// <summary>
    /// 一个符文槽位的状态
    /// </summary>
    [EnableClass]
    public class RuneSlotData
    {
        /// <summary>
        /// 槽位配置 id（RuneSlotConfig.Id）
        /// </summary>
        public int SlotId;

        /// <summary>
        /// 是否已解锁。解锁是永久的，条件满足后不会再锁回去
        /// </summary>
        public bool Unlocked;

        /// <summary>
        /// 镶嵌的符文 id（RuneData.Id），0 表示空槽
        /// </summary>
        public long RuneId;
    }
}
