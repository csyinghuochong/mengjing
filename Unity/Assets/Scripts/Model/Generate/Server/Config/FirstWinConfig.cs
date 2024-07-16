using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class FirstWinConfigCategory : Singleton<FirstWinConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, FirstWinConfig> dict = new();
		
        public void Merge(object o)
        {
            FirstWinConfigCategory s = o as FirstWinConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public FirstWinConfig Get(int id)
        {
            this.dict.TryGetValue(id, out FirstWinConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (FirstWinConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, FirstWinConfig> GetAll()
        {
            return this.dict;
        }

        public FirstWinConfig GetOne()
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

	public partial class FirstWinConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>ChatperId</summary>
		public int ChatperId { get; set; }
		/// <summary>BossID</summary>
		public int BossID { get; set; }
		/// <summary>普通奖励</summary>
		public string RewardList_1 { get; set; }
		/// <summary>挑战奖励</summary>
		public string RewardList_2 { get; set; }
		/// <summary>地狱奖励</summary>
		public string RewardList_3 { get; set; }
		/// <summary>个人普通奖励</summary>
		public string Self_RewardList_1 { get; set; }
		/// <summary>个人挑战奖励</summary>
		public string Self_RewardList_2 { get; set; }
		/// <summary>个人地狱奖励</summary>
		public string Self_RewardList_3 { get; set; }

	}
}
