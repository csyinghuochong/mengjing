using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PaiMaiSellConfigCategory : Singleton<PaiMaiSellConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PaiMaiSellConfig> dict = new();
		
        public void Merge(object o)
        {
            PaiMaiSellConfigCategory s = o as PaiMaiSellConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PaiMaiSellConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PaiMaiSellConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PaiMaiSellConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PaiMaiSellConfig> GetAll()
        {
            return this.dict;
        }

        public PaiMaiSellConfig GetOne()
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

	public partial class PaiMaiSellConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>拍卖类型</summary>
		public int PaiMaiType { get; set; }
		/// <summary>章节ID</summary>
		public int ChapterId { get; set; }
		/// <summary>购买等级</summary>
		public int BuyLv { get; set; }
		/// <summary>道具ID</summary>
		public int ItemID { get; set; }
		/// <summary>价格</summary>
		public int[] Price { get; set; }
		/// <summary>价格上限</summary>
		public int PriceMax { get; set; }
		/// <summary>价格下限</summary>
		public int PriceMin { get; set; }

	}
}
