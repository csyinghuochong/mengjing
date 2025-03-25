using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class UnionKeJiConfigCategory : Singleton<UnionKeJiConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, UnionKeJiConfig> dict = new();
		
        public void Merge(object o)
        {
            UnionKeJiConfigCategory s = o as UnionKeJiConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public UnionKeJiConfig Get(int id)
        {
            this.dict.TryGetValue(id, out UnionKeJiConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (UnionKeJiConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, UnionKeJiConfig> GetAll()
        {
            return this.dict;
        }

        public UnionKeJiConfig GetOne()
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

	public partial class UnionKeJiConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>装备名称</summary>
		public string EquipSpaceName { get; set; }
		/// <summary>图标</summary>
		public string Icon { get; set; }
		/// <summary>前置id</summary>
		public int[] PreId { get; set; }
		/// <summary>下一级强化</summary>
		public int NextID { get; set; }
		/// <summary>等级</summary>
		public int QiangHuaLv { get; set; }
		/// <summary>需要家族等级</summary>
		public int NeedUnionLv { get; set; }
		/// <summary>升级需要时间（单位:s）</summary>
		public int NeedTime { get; set; }
		/// <summary>升级消耗家族金币</summary>
		public int CostUnionGold { get; set; }
		/// <summary>消耗科技点数</summary>
		public int Point { get; set; }
		/// <summary>学习消耗道具</summary>
		public string LearnCost { get; set; }
		/// <summary>强化属性</summary>
		public string EquipPropreAdd { get; set; }

	}
}
