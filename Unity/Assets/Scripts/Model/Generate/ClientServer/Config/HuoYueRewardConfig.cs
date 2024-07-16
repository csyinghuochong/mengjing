using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class HuoYueRewardConfigCategory : Singleton<HuoYueRewardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, HuoYueRewardConfig> dict = new();
		
        public void Merge(object o)
        {
            HuoYueRewardConfigCategory s = o as HuoYueRewardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public HuoYueRewardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out HuoYueRewardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (HuoYueRewardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, HuoYueRewardConfig> GetAll()
        {
            return this.dict;
        }

        public HuoYueRewardConfig GetOne()
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

	public partial class HuoYueRewardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>需要活跃点数</summary>
		public int NeedPoint { get; set; }
		/// <summary>奖励</summary>
		public string RewardItems { get; set; }
		/// <summary>Icon</summary>
		public int Icon { get; set; }
		/// <summary>描述</summary>
		public string Desc { get; set; }

	}
}
