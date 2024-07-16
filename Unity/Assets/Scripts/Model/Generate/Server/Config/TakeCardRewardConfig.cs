using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TakeCardRewardConfigCategory : Singleton<TakeCardRewardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TakeCardRewardConfig> dict = new();
		
        public void Merge(object o)
        {
            TakeCardRewardConfigCategory s = o as TakeCardRewardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TakeCardRewardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TakeCardRewardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TakeCardRewardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TakeCardRewardConfig> GetAll()
        {
            return this.dict;
        }

        public TakeCardRewardConfig GetOne()
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

	public partial class TakeCardRewardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>抽卡次数</summary>
		public int RoseLvLimit { get; set; }
		/// <summary>奖励道具</summary>
		public string RewardItems { get; set; }
		/// <summary>奖励钻石</summary>
		public int[] RewardDiamond { get; set; }

	}
}
