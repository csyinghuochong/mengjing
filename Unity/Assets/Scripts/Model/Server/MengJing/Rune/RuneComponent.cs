using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 符文数据：符文碎片、拥有的符文、20 个槽位的解锁与镶嵌状态。
    /// 符文的等级、类型、属性查 RuneConfig（一行一级，NextId 串下一级）；
    /// 槽位的类型、解锁条件查 RuneSlotConfig
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class RuneComponent : Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
    {
        /// <summary>
        /// 符文碎片
        /// </summary>
        public int Shard { get; set; }

        /// <summary>
        /// 拥有的符文，已镶嵌的也在里面。槽位记的是 RuneData.Id，
        /// 背包里的 = 没有被任何槽位引用的那些
        /// </summary>
        public List<RuneData> RuneList { get; set; } = new List<RuneData>();

        /// <summary>
        /// 槽位状态。只记录解锁过或镶嵌过的槽位，缺的槽位就是没解锁、空槽
        /// </summary>
        public List<RuneSlotData> SlotList { get; set; } = new List<RuneSlotData>();
    }
}
