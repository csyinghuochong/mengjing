using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class JiaYuanConfigCategory : Singleton<JiaYuanConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, JiaYuanConfig> dict = new();
		
        public void Merge(object o)
        {
            JiaYuanConfigCategory s = o as JiaYuanConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public JiaYuanConfig Get(int id)
        {
            this.dict.TryGetValue(id, out JiaYuanConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (JiaYuanConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, JiaYuanConfig> GetAll()
        {
            return this.dict;
        }

        public JiaYuanConfig GetOne()
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

	public partial class JiaYuanConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>下一级ID</summary>
		public int NextID { get; set; }
		/// <summary>等级</summary>
		public int Lv { get; set; }
		/// <summary>升级经验</summary>
		public int Exp { get; set; }
		/// <summary>人口上限</summary>
		public int PeopleNumMax { get; set; }
		/// <summary>需要玩家等级</summary>
		public int NeedRoseLv { get; set; }
		/// <summary>农场种植上限</summary>
		public int FarmNumMax { get; set; }
		/// <summary>农场描述</summary>
		public string JiaYuanDes { get; set; }
		/// <summary>兑换经验消耗资金</summary>
		public int ExchangeExpCostZiJin { get; set; }
		/// <summary>兑换获得经验</summary>
		public int ExchangeExp { get; set; }
		/// <summary>兑换获得资金消耗金币</summary>
		public int ExchangeZiJinCostGold { get; set; }
		/// <summary>兑换获得资金</summary>
		public int ExchangeZiJin { get; set; }
		/// <summary>家园每小时产出经验</summary>
		public int JiaYuanAddExp { get; set; }
		/// <summary>宠物栏位</summary>
		public int PetNum { get; set; }
		/// <summary>属性上限</summary>
		public string ProMax { get; set; }

	}
}
