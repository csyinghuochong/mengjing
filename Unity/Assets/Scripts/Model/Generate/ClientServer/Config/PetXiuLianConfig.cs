using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetXiuLianConfigCategory : Singleton<PetXiuLianConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetXiuLianConfig> dict = new();
		
        public void Merge(object o)
        {
            PetXiuLianConfigCategory s = o as PetXiuLianConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetXiuLianConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetXiuLianConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetXiuLianConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetXiuLianConfig> GetAll()
        {
            return this.dict;
        }

        public PetXiuLianConfig GetOne()
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

	public partial class PetXiuLianConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>图标显示</summary>
		public string Icon { get; set; }
		/// <summary>下一ID</summary>
		public int NextID { get; set; }
		/// <summary>等级</summary>
		public int Lv { get; set; }
		/// <summary>成功概率</summary>
		public string SuccessPro { get; set; }
		/// <summary>增加属性</summary>
		public string AddPro { get; set; }
		/// <summary>消耗金币</summary>
		public int CostMoney { get; set; }
		/// <summary>消耗道具</summary>
		public string CostItem { get; set; }
		/// <summary>描述</summary>
		public string Des { get; set; }
		/// <summary>描述2</summary>
		public string Des_EN { get; set; }

	}
}
