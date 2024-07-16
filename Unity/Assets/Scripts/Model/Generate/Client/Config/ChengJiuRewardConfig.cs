using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ChengJiuRewardConfigCategory : Singleton<ChengJiuRewardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ChengJiuRewardConfig> dict = new();
		
        public void Merge(object o)
        {
            ChengJiuRewardConfigCategory s = o as ChengJiuRewardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ChengJiuRewardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ChengJiuRewardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ChengJiuRewardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ChengJiuRewardConfig> GetAll()
        {
            return this.dict;
        }

        public ChengJiuRewardConfig GetOne()
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

	public partial class ChengJiuRewardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>需要成就点</summary>
		public int NeedPoint { get; set; }
		/// <summary>奖励</summary>
		public string RewardItems { get; set; }
		/// <summary>成就Icon</summary>
		public int Icon { get; set; }
		/// <summary>成就描述</summary>
		public string Desc { get; set; }

	}
}
