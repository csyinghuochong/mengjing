using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MysteryConfigCategory : Singleton<MysteryConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MysteryConfig> dict = new();
		
        public void Merge(object o)
        {
            MysteryConfigCategory s = o as MysteryConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MysteryConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MysteryConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MysteryConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MysteryConfig> GetAll()
        {
            return this.dict;
        }

        public MysteryConfig GetOne()
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

	public partial class MysteryConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>NextId</summary>
		public int NextId { get; set; }
		/// <summary>随机数量</summary>
		public int[] NumberLimit { get; set; }
		/// <summary>出售道具</summary>
		public int SellItemID { get; set; }
		/// <summary>出售货币种类</summary>
		public int SellType { get; set; }
		/// <summary>出售价格</summary>
		public int SellValue { get; set; }
		/// <summary>出现权重</summary>
		public int ShowPro { get; set; }
		/// <summary>出现服务器时间(天)</summary>
		public int ShowServerDay { get; set; }
		/// <summary>限购数量</summary>
		public int BuyNumMax { get; set; }
		/// <summary>家园等级</summary>
		public int JiaYuanLv { get; set; }

	}
}
