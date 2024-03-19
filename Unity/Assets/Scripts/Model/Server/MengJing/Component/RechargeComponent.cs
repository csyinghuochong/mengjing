using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class RechargeComponent: Entity, IAwake<long>, IDestroy
    {
        //已验证的支付订单
        public List<string> PayLoadList = new List<string>();
    }
}
