using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class RankRewardConfigCategory : Singleton<RankRewardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, RankRewardConfig> dict = new();
		
        public void Merge(object o)
        {
            RankRewardConfigCategory s = o as RankRewardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public RankRewardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out RankRewardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (RankRewardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, RankRewardConfig> GetAll()
        {
            return this.dict;
        }

        public RankRewardConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            
            var enumerator = this.dict.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current; 
        }
    }

	public partial class RankRewardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>排名类型</summary>
		public int Type { get; set; }
		/// <summary>排行名次</summary>
		public int[] NeedPoint { get; set; }
		/// <summary>奖励</summary>
		public string RewardItems { get; set; }

	}
}
