using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{

	[ChildOf(typeof(ActivitySceneComponent))]
    [BsonIgnoreExtraElements]
	public class DBDayActivityInfo : Entity, IAwake
	{
		public int LastHour;

		/// <summary>
		/// 小龟历史胜利次数
		/// </summary>
		public List<int> TurtleWinTimes { get; set; } = new();

		//神秘商品
        public List<MysteryItemInfo> MysteryItemInfos  { get; set; }= new();

		//战区活动
		public List<ZhanQuReceiveNumber> ZhanQuReveives  { get; set; }= new();

		//首胜记录
		public List<FirstWinInfo> FirstWinInfos { get; set; } = new();

		//宠物矿场(矿场类型->玩家ID)
		public List<PetMingPlayerInfo> PetMingList{ get; set; } = new();

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<long, long> PetMingChanChu = new();

		//核心矿
		public List<KeyValuePairInt> PetMingHexinList= new();

		/// <summary>
		/// 竞猜数字->竞猜玩家列表
		/// </summary>
		[BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
		public Dictionary<int, List<long>> GuessPlayerList { get; set; } = new();

		
		/// <summary>
        /// 竞猜数字->中奖的玩家
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, List<long>> GuessRewardList { get; set; } = new();

        /// <summary>
        /// 喂食玩家列表
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<long, int> FeedPlayerList { get; set; } = new();
        
        public int FeedRewardKey  { get; set; }= 0;

        public int BaoShiDu { get; set; } = 0;

        /// <summary>
        /// 竞猜开奖的字
        /// </summary>
        public List<int> OpenGuessIds{ get; set; }  = new();
        
        /// <summary>
        /// 赛季领主
        /// </summary>
        public int CommonSeasonBossLevel { get; set; } = 0;
        public int CommonSeasonBossExp { get; set; } = 0;
        
        /// <summary>
        /// 击杀boss后置空   1
        /// </summary>
        public int CommonSeasonBossRefreshState { get; set; } = 0;
        
        public long CommonSeasonOpenTime  { get; set; } = 0;
    }

}
