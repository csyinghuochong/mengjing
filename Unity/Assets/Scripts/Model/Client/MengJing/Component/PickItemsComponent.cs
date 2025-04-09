using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 将短时间内拾取道具的消息合并，防止一瞬间发送太多
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class PickItemsComponent : Entity, IAwake, IDestroy
    {
        public List<Unit> UnitDrops { get; set; } = new();
        public long SyncTime = 0;
        public long SyncTimerId = 0;
        public long LastSendTime = 0;
    }
}