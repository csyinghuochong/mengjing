using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class StoreSellConfigCategory : Singleton<StoreSellConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, StoreSellConfig> dict = new();
		
        public void Merge(object o)
        {
            StoreSellConfigCategory s = o as StoreSellConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public StoreSellConfig Get(int id)
        {
            this.dict.TryGetValue(id, out StoreSellConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (StoreSellConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, StoreSellConfig> GetAll()
        {
            return this.dict;
        }

        public StoreSellConfig GetOne()
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

	public partial class StoreSellConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>下一级id</summary>
		public int NextID { get; set; }
		/// <summary>需要玩家显示最低等级</summary>
		public int ShowRoleLvMin { get; set; }
		/// <summary>需要玩家显示最高等级</summary>
		public int ShowRoleLvMax { get; set; }
		/// <summary>出售道具</summary>
		public int SellItemID { get; set; }
		/// <summary>出售道具</summary>
		public int SellItemNum { get; set; }
		/// <summary>出售货币种类</summary>
		public int SellType { get; set; }
		/// <summary>出售价格</summary>
		public int SellValue { get; set; }

	}
}
