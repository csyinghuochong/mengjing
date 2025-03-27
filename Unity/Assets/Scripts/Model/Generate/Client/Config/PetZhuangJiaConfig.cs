using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetZhuangJiaConfigCategory : Singleton<PetZhuangJiaConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetZhuangJiaConfig> dict = new();
		
        public void Merge(object o)
        {
            PetZhuangJiaConfigCategory s = o as PetZhuangJiaConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetZhuangJiaConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetZhuangJiaConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetZhuangJiaConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetZhuangJiaConfig> GetAll()
        {
            return this.dict;
        }

        public PetZhuangJiaConfig GetOne()
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

	public partial class PetZhuangJiaConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>下一级强化</summary>
		public int NextID { get; set; }
		/// <summary>强化等级</summary>
		public int Lv { get; set; }
		/// <summary>消耗道具</summary>
		public string CostItem { get; set; }
		/// <summary>强化属性</summary>
		public string PropreAdd { get; set; }

	}
}
