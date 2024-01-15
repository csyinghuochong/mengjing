using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ChapterConfigCategory : Singleton<ChapterConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ChapterConfig> dict = new();
		
        public void Merge(object o)
        {
            ChapterConfigCategory s = o as ChapterConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ChapterConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ChapterConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ChapterConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ChapterConfig> GetAll()
        {
            return this.dict;
        }

        public ChapterConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class ChapterConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>章节名称</summary>
		public string ChapterName { get; set; }
		/// <summary>音乐</summary>
		public string Music { get; set; }
		/// <summary>生成范围</summary>
		public int[] InitSize { get; set; }
		/// <summary>起始地块</summary>
		public int StartArea { get; set; }
		/// <summary>终点地块</summary>
		public int EndArea { get; set; }
		/// <summary>禁止通行地块</summary>
		public int StopArea { get; set; }
		/// <summary>奇遇房间概率</summary>
		public double[] SpecialRoomPro { get; set; }
		/// <summary>奇遇房间</summary>
		public int[] SpecialRoom { get; set; }
		/// <summary>禁止通行地块</summary>
		public int StopAreaNum { get; set; }
		/// <summary>随机地块</summary>
		public int[] RandomArea { get; set; }
		/// <summary>进入等级限制</summary>
		public int EnterLv { get; set; }
		/// <summary>章节BossIcon</summary>
		public int BossIcon { get; set; }
		/// <summary>章节文本描述</summary>
		public string ChapterDes { get; set; }
		/// <summary>通关经验奖励</summary>
		public int RewardExp { get; set; }
		/// <summary>通关金币奖励</summary>
		public int RewardGold { get; set; }
		/// <summary>翻卡掉落ID</summary>
		public int BoxDropID { get; set; }

	}
}
