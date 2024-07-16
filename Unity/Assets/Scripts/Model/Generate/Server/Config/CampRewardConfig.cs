using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class CampRewardConfigCategory : Singleton<CampRewardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, CampRewardConfig> dict = new();
		
        public void Merge(object o)
        {
            CampRewardConfigCategory s = o as CampRewardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public CampRewardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out CampRewardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (CampRewardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, CampRewardConfig> GetAll()
        {
            return this.dict;
        }

        public CampRewardConfig GetOne()
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

	public partial class CampRewardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名次</summary>
		public int[] RankRange { get; set; }
		/// <summary>胜利奖励</summary>
		public string Win_RewardList { get; set; }
		/// <summary>失败奖励</summary>
		public string Fail_RewardList { get; set; }

	}
}
