using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 宝石天赋：已激活的节点和历史最大宝石点数。
    /// 宝石点数由身上装备镶嵌的宝石实时换算，这里只存需要存档的结果
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class GemTalentComponent : Entity, IAwake, ITransfer, IDestroy, IUnitCache, IDeserialize
    {
        /// <summary>
        /// 已激活的宝石天赋节点id（GemTalentConfig.Id）
        /// </summary>
        public List<int> GemTalentList { get; set; } = new();

        /// <summary>
        /// 总宝石点数：由装备上的宝石换算出来的历史最大值，只增不减。
        /// 区域解锁和可用点数都按这个值算，卸下宝石后已解锁区域不会重新上锁、也不会退还点数
        /// </summary>
        public int GemTalentMaxPoint { get; set; }
    }
}
