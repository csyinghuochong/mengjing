using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 客户端的宝石天赋数据：已激活的节点和历史最大宝石点数，由服务端下发
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class GemTalentComponentC : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 已激活的宝石天赋节点id（GemTalentConfig.Id）
        /// </summary>
        public List<int> GemTalentList { get; set; } = new();

        /// <summary>
        /// 总宝石点数：服务端算好下发，客户端不自己统计。
        /// 只增不减，区域解锁和可用点数都按它算
        /// </summary>
        public int GemTalentMaxPoint { get; set; }
    }
}
