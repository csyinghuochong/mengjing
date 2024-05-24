using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class PaiMaiSceneComponent : Entity, IAwake, IDestroy
    {
        public long Timer;
        /// <summary>
        /// 拍卖会
        /// </summary>
        public int AuctionItem{ get; set; }

        /// <summary>
        /// 0没开始 1开始 2结束
        /// </summary>
        public int AuctionStatus { get; set; }

        public long AuctionPrice{ get; set; }
        public long AuctionStart { get; set; } //起拍价
        public long AuctioUnitId{ get; set; }
        public int AuctionItemNum{ get; set; }
        public string AuctionPlayer{ get; set; }

        public List<long> AuctionJoinList  { get; set; } = new List<long>();

        //拍卖行存储列表
        public DBPaiMainInfo dBPaiMainInfo { get; set; } = new DBPaiMainInfo(); //废弃掉， 里面的数据分散到以下几个列表

        //Administrator:
        //1：消耗性道具
        //2：材料
        //3：装备
        //4：宝石
        //5：宠物之核
        /// <summary>
        /// 拍卖上架 id = 1000 + 道具类型(itemconfig.ItemType) 最多十个列表
        /// </summary>
        public DBPaiMainInfo dBPaiMainInfo_Consume { get; set; }= new DBPaiMainInfo();       //消耗品  dBPaiMainInfo.PaiMaiItemInfos里面的消耗品1
        public DBPaiMainInfo dBPaiMainInfo_Material { get; set; }= new DBPaiMainInfo();      //材料    dBPaiMainInfo.PaiMaiItemInfos里面的材料
        public DBPaiMainInfo dBPaiMainInfo_Equipment { get; set; }= new DBPaiMainInfo();     //装备    dBPaiMainInfo.PaiMaiItemInfos里面的装备
        public DBPaiMainInfo dBPaiMainInfo_Gemstone{ get; set; } = new DBPaiMainInfo();      //宝石    dBPaiMainInfo.PaiMaiItemInfos里面的宝石

        /// <summary>
        /// 拍卖商店 id = 1011
        /// </summary>
        public DBPaiMainInfo dBPaiMainInfo_Shop { get; set; }= new DBPaiMainInfo();      //拍卖商店   dBPaiMainInfo.PaiMaiShopItemInfos   

        /// <summary>
        /// 摆摊道具 id  = 1012
        /// </summary>
        public DBPaiMainInfo dBPaiMainInfo_Stall { get; set; }= new DBPaiMainInfo();         //摆摊    dBPaiMainInfo.PaiMaiItemInfos里面的摆摊

        //出价记录
        public List<PaiMaiAuctionRecord> AuctionRecords { get; set; }= new List<PaiMaiAuctionRecord>();
    }
    
}