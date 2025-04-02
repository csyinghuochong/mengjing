using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class DragonChuansongComponent : Entity, IAwake, IDestroy
    {
        public long Timer;

        /// <summary>
        /// 出生在传送圈内的玩家 必须要先走出去再进来
        /// </summary>
        public List<long> InitInPlayers { get; set; } = new();
    }
}