using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 客户端的符文数据：碎片、拥有的符文、20 个槽位的解锁与镶嵌状态。
    /// 登录时由服务端下发，符文配置查 RuneConfig，槽位配置查 RuneSlotConfig
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class RuneComponentC : Entity, IAwake, IDestroy
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
        /// 所有槽位，服务端按配置顺序全发，没解锁的 Unlocked 是 false
        /// </summary>
        public List<RuneSlotInfo> SlotList { get; set; } = new List<RuneSlotInfo>();

        /// <summary>
        /// 符文总等级：只算已镶嵌的，服务端算好下发
        /// </summary>
        public int TotalRuneLv { get; set; }
    }
}
