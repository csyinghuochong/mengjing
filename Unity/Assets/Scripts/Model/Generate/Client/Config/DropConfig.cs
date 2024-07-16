using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class DropConfigCategory : Singleton<DropConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, DropConfig> dict = new();
		
        public void Merge(object o)
        {
            DropConfigCategory s = o as DropConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public DropConfig Get(int id)
        {
            this.dict.TryGetValue(id, out DropConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (DropConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, DropConfig> GetAll()
        {
            return this.dict;
        }

        public DropConfig GetOne()
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

	public partial class DropConfig: ProtoObject, IConfig
	{
		/// <summary>id</summary>
		public int Id { get; set; }
		/// <summary>掉落类型</summary>
		public int DropType { get; set; }
		/// <summary>掉落限制</summary>
		public int DropLimit { get; set; }
		/// <summary>是否直接进入背包</summary>
		public int ifEnterBag { get; set; }
		/// <summary>继承掉落ID</summary>
		public int DropSonID { get; set; }
		/// <summary>掉落道具1概率</summary>
		public int DropChance1 { get; set; }
		/// <summary>掉落道具1ID</summary>
		public int DropItemID1 { get; set; }
		/// <summary>掉落道具1最小数量</summary>
		public int DropItemMinNum1 { get; set; }
		/// <summary>掉落道具1最大数量</summary>
		public int DropItemMaxNum1 { get; set; }
		/// <summary>掉落道具2概率</summary>
		public int DropChance2 { get; set; }
		/// <summary>掉落道具2ID</summary>
		public int DropItemID2 { get; set; }
		/// <summary>掉落道具2最小数量</summary>
		public int DropItemMinNum2 { get; set; }
		/// <summary>掉落道具2最大数量</summary>
		public int DropItemMaxNum2 { get; set; }
		/// <summary>掉落道具3概率</summary>
		public int DropChance3 { get; set; }
		/// <summary>掉落道具3ID</summary>
		public int DropItemID3 { get; set; }
		/// <summary>掉落道具3最小数量</summary>
		public int DropItemMinNum3 { get; set; }
		/// <summary>掉落道具3最大数量</summary>
		public int DropItemMaxNum3 { get; set; }
		/// <summary>掉落道具4概率</summary>
		public int DropChance4 { get; set; }
		/// <summary>掉落道4ID</summary>
		public int DropItemID4 { get; set; }
		/// <summary>掉落道具4最小数量</summary>
		public int DropItemMinNum4 { get; set; }
		/// <summary>掉落道具4最大数量</summary>
		public int DropItemMaxNum4 { get; set; }
		/// <summary>掉落道具5概率</summary>
		public int DropChance5 { get; set; }
		/// <summary>掉落道具5ID</summary>
		public int DropItemID5 { get; set; }
		/// <summary>掉落道具5最小数量</summary>
		public int DropItemMinNum5 { get; set; }
		/// <summary>掉落道具5最大数量</summary>
		public int DropItemMaxNum5 { get; set; }
		/// <summary>掉落道具6概率</summary>
		public int DropChance6 { get; set; }
		/// <summary>掉落道具6ID</summary>
		public int DropItemID6 { get; set; }
		/// <summary>掉落道具6最小数量</summary>
		public int DropItemMinNum6 { get; set; }
		/// <summary>掉落道具6最大数量</summary>
		public int DropItemMaxNum6 { get; set; }
		/// <summary>掉落道具7概率</summary>
		public int DropChance7 { get; set; }
		/// <summary>掉落道具7ID</summary>
		public int DropItemID7 { get; set; }
		/// <summary>掉落道具7最小数量</summary>
		public int DropItemMinNum7 { get; set; }
		/// <summary>掉落道具7最大数量</summary>
		public int DropItemMaxNum7 { get; set; }
		/// <summary>掉落道具8概率</summary>
		public int DropChance8 { get; set; }
		/// <summary>掉落道具8ID</summary>
		public int DropItemID8 { get; set; }
		/// <summary>掉落道具8最小数量</summary>
		public int DropItemMinNum8 { get; set; }
		/// <summary>掉落道具8最大数量</summary>
		public int DropItemMaxNum8 { get; set; }
		/// <summary>掉落道具9概率</summary>
		public int DropChance9 { get; set; }
		/// <summary>掉落道具9ID</summary>
		public int DropItemID9 { get; set; }
		/// <summary>掉落道具9最小数量</summary>
		public int DropItemMinNum9 { get; set; }
		/// <summary>掉落道具9最大数量</summary>
		public int DropItemMaxNum9 { get; set; }
		/// <summary>掉落道具10概率</summary>
		public int DropChance10 { get; set; }
		/// <summary>掉落道具10ID</summary>
		public int DropItemID10 { get; set; }
		/// <summary>掉落道具10最小数量</summary>
		public int DropItemMinNum10 { get; set; }
		/// <summary>掉落道具10最大数量</summary>
		public int DropItemMaxNum10 { get; set; }

	}
}
