using System.Collections.Generic;

namespace ET.Server
{
    
    [EnableClass]
    public class InApp
    {
        /// <summary>
        /// 
        /// </summary>
        public string product_id { get; set; }
    }

    [EnableClass]
    public class Receipt
    {

        public List<InApp> in_app { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string original_purchase_date_pst { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string purchase_date_ms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string unique_identifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string original_transaction_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bvrs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string unique_vendor_identifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string item_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string original_purchase_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_in_intro_offer_period { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string purchase_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_trial_period { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string purchase_date_pst { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bundle_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string original_purchase_date_ms { get; set; }
    }

    [EnableClass]
    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public Receipt receipt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
    }

    
    [ComponentOf(typeof(Unit))]
    public class RechargeComponent   :     Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        //已验证的支付订单
        public List<string> PayLoadList = new List<string>();
    }
}
