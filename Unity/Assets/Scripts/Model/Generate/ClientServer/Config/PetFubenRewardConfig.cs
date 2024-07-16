using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetFubenRewardConfigCategory : Singleton<PetFubenRewardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetFubenRewardConfig> dict = new();
		
        public void Merge(object o)
        {
            PetFubenRewardConfigCategory s = o as PetFubenRewardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetFubenRewardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetFubenRewardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetFubenRewardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetFubenRewardConfig> GetAll()
        {
            return this.dict;
        }

        public PetFubenRewardConfig GetOne()
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

	public partial class PetFubenRewardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>需要副本星数</summary>
		public int NeedStar { get; set; }
		/// <summary>奖励</summary>
		public string RewardItems { get; set; }
		/// <summary>Icon</summary>
		public int Icon { get; set; }
		/// <summary>描述</summary>
		public string Desc { get; set; }

	}
}
