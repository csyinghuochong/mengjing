using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class RechargeServerComponent: Entity, IAwake,IDestroy
    {
        //已验证的支付订单
        public List<string> PayLoadList = new List<string>();
    }

}
