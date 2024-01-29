using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof(Scene))]
    public class BagComponentClient : Entity, IAwake, IDestroy
    {
        public List<BagInfo> BagItemList { get; set; } = new();
    }
}