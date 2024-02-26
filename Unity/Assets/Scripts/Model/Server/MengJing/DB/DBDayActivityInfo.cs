﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.Collections.Generic;


namespace ET.Server
{

	[ChildOf(typeof(ActivityServerComponent))]
    [BsonIgnoreExtraElements]
	public class DBDayActivityInfo : Entity, IAwake
	{
		public int LastHour;
		
		/// <summary>
		/// 小龟历史胜利次数
		/// </summary>
		public List<int> TurtleWinTimes = new List<int>() { }; 

        //神秘商品
        public List<MysteryItemInfo> MysteryItemInfos = new List<MysteryItemInfo>();

		//战区活动
		public List<ZhanQuReceiveNumber> ZhanQuReveives = new List<ZhanQuReceiveNumber>();

		//首胜记录
		public List<FirstWinInfo> FirstWinInfos = new List<FirstWinInfo>();

		//宠物矿场(矿场类型->玩家ID)
		public List<PetMingPlayerInfo> PetMingList = new List<PetMingPlayerInfo>();

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<long, long> PetMingChanChu = new Dictionary<long, long>();

		//核心矿
		public List<KeyValuePairInt> PetMingHexinList = new List<KeyValuePairInt> { };

        /// <summary>
        /// 竞猜数字->竞猜玩家列表
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, List<long>> GuessPlayerList = new Dictionary<int, List<long>>();

        

        /// <summary>
        /// 竞猜数字->中奖的玩家
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, List<long>> GuessRewardList = new Dictionary<int, List<long>>();
      
        /// <summary>
        /// 喂食玩家列表
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<long, int> FeedPlayerList = new Dictionary<long, int>();

        public int FeedRewardKey = 0;

        public int BaoShiDu = 0;

        /// <summary>
        /// 竞猜开奖的字
        /// </summary>
        public List<int> OpenGuessIds = new List<int>() { };
    }

}
