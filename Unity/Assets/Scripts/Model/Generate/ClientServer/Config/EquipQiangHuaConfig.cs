using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipQiangHuaConfigCategory : Singleton<EquipQiangHuaConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipQiangHuaConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipQiangHuaConfigCategory s = o as EquipQiangHuaConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipQiangHuaConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipQiangHuaConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipQiangHuaConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipQiangHuaConfig> GetAll()
        {
            return this.dict;
        }

        public EquipQiangHuaConfig GetOne()
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

	public partial class EquipQiangHuaConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
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
		/// <summary>强化属性</summary>
		public string AddPropreListStr { get; set; }
		/// <summary>武器部位</summary>
		public int ItemSubType { get; set; }
		/// <summary>失败附加成功概率</summary>
		public double AdditionPro { get; set; }

	}
}
