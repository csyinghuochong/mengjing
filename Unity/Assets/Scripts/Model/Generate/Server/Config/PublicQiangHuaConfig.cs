using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PublicQiangHuaConfigCategory : Singleton<PublicQiangHuaConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PublicQiangHuaConfig> dict = new();
		
        public void Merge(object o)
        {
            PublicQiangHuaConfigCategory s = o as PublicQiangHuaConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PublicQiangHuaConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PublicQiangHuaConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PublicQiangHuaConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PublicQiangHuaConfig> GetAll()
        {
            return this.dict;
        }

        public PublicQiangHuaConfig GetOne()
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

	public partial class PublicQiangHuaConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>图标</summary>
		public string Icon { get; set; }
		/// <summary>强化类型</summary>
		public int ItemSubType { get; set; }
		/// <summary>下一级强化</summary>
		public int NextID { get; set; }
		/// <summary>强化等级</summary>
		public int QiangHuaLv { get; set; }
		/// <summary>升级等级限制</summary>
		public int UpLvLimit { get; set; }
		/// <summary>成功概率</summary>
		public double SuccessPro { get; set; }
		/// <summary>消耗金币</summary>
		public int CostGold { get; set; }
		/// <summary>强化消耗</summary>
		public string CostItem { get; set; }
		/// <summary>强化属性</summary>
		public string EquipPropreAdd { get; set; }
		/// <summary>失败附加成功概率</summary>
		public double AdditionPro { get; set; }

	}
}
