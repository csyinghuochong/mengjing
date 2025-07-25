using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class DataCollationComponent:       Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        //    userid,

        //名称
        public string Name;

        //等级
        public int Level;

        //第一职业（用文字 法师/战士）
        public string Occ;

        //转职（用文字 元素剑士/驭剑士……）
        public string OccTwo;

        //战斗力
        public int Combat;

        //金币额度
        public long Gold;

        //钻石额度
        public long Diamond;

        //充值额度
        public long Recharge;

        //当天在线时间
        public long TodayOnLine;

        //总共在线时间
        public long TotalOnLine;

        //创建角色时间
        public string CreateRoleTime;

        //上次登录时间
        public string LastLoginTime;

        //当前主线ID
        public string MainTask;

        //宠物ID {宠物ID,宠物评分
        //}
        public string PetPingfen;

        //公会名称
        public string UnionName;

        //家园等级
        public int JiaYuanLv;

        //家园资金
        public long JiaYuanFund;

        //体力值
        public long PiLao;

        //活力值
        public int Vitality;

        //当前生活技能类型 (这里最好用文字表示  炼金 锻造)
        public string MakeSkill;

        //生活技能熟练度
        public int MakeShuLiandu;

        //宠物探险关卡
        public int PetFubenId;

        //试炼之地关卡
        public int TrialFubenId;

        //(幸运探宝)抽奖次数
        public int ChouKaTimes { get; set; }

        //宠物探索次数
        public int PetChouKaTimes;

        //宠物兑换次数
        public int PetDuiHuanTimes;

        //当前身上橙色装备数量
        public int ChengZhuangNumber;

        //洗炼经验
        public int XiLianExp;

        //洗练次数
        public int XiLianTimes;

        //钻石洗练次数
        public int DiamondXiLianTimes { get; set; }

        //上次封印之塔层数（不是最高, 上一次即可）
        public int LastSealTowerId;


        //（单独处理一下两个, 花费类型高的排在前面）
        //金币消耗
        public string GoldCost;

        [BsonIgnore]
        public List<KeyValuePairInt> GoldCostList = new List<KeyValuePairInt>();

        //钻石消耗
        public string DiamondCost;

        [BsonIgnore]
        public List<KeyValuePairInt> DiamondCostList = new List<KeyValuePairInt>();


        //金币获取列表
        public string GoldGet;
        [BsonIgnore]
        public List<KeyValuePairInt> GoldGetList = new List<KeyValuePairInt>();

        //平台
        public string Platform;

        public string DeviceName;

        //秒傷
        public long SceondHurt;

        public string Account;

        public int PetHeCheng { get; set; }

        //模拟器
        public int Simulator;

        public long PaiMaiGold;

        public int JinZhiPaiMai;

        public int IsRoot;

        public string DeviceID;
        
        
        /// <summary>
        /// 购买自己的玩家列表
        /// </summary>
        public List<KeyValuePairLong> BuySelfPlayerList = new List<KeyValuePairLong>();

        
        //今日拍卖花费金币
        public long PaiMaiCostGoldToday { get; set; }


        public List<KeyValuePairLong4> SingleHappyDropList { get; set; } = new List<KeyValuePairLong4>();
    }
}
