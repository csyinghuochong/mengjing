using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ET.Server
{
    
    [ChildOf(typeof(ReChargeQDComponent))]
    public class QudaoOrderInfo : Entity, IAwake
    {
        public int amount { get; set; }
        public int objID{ get; set; }
        public int zone{ get; set; }
        public long userId{ get; set; }
        public string UnitName{ get; set; }
    }
    
    [ComponentOf(typeof(Scene))]
    public class ReChargeQDComponent: Entity, IAwake,IDestroy
    {
        public string callbackkey = "79732310199972304452069037663031";
        public string md5Key = "16ujpemxehsnxls0eyijzgos41xn6ru7";
        public string httpListenerUrl = @"http://172.17.94.25:20008/"; //47.94.107.92
        public HttpListener httpListener;
        public object listenLocker = new object();

        public Dictionary<string, EntityRef<QudaoOrderInfo>> OrderDic = new Dictionary<string, EntityRef<QudaoOrderInfo>>();

        //订单序号ID
        public int dingdanXuHao;
        public string dingdanlastTime;
    }

}
