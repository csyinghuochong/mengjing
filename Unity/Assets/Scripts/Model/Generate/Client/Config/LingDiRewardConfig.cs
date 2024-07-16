using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class LingDiRewardConfigCategory : Singleton<LingDiRewardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, LingDiRewardConfig> dict = new();
		
        public void Merge(object o)
        {
            LingDiRewardConfigCategory s = o as LingDiRewardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public LingDiRewardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out LingDiRewardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (LingDiRewardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, LingDiRewardConfig> GetAll()
        {
            return this.dict;
        }

        public LingDiRewardConfig GetOne()
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

	public partial class LingDiRewardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>下一个兑换ID</summary>
		public int NextID { get; set; }
		/// <summary>兑换道具名称</summary>
		public int ItemID { get; set; }
		/// <summary>兑换道具ID</summary>
		public int BuyItemID { get; set; }
		/// <summary>兑换道具价格</summary>
		public int BuyPrice { get; set; }
		/// <summary>角色等级限制</summary>
		public int RoseLvlimit { get; set; }
		/// <summary>国家等级限制</summary>
		public int CountryLvlimit { get; set; }

	}
}
