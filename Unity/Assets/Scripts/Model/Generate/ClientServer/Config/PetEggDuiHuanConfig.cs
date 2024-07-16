using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetEggDuiHuanConfigCategory : Singleton<PetEggDuiHuanConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetEggDuiHuanConfig> dict = new();
		
        public void Merge(object o)
        {
            PetEggDuiHuanConfigCategory s = o as PetEggDuiHuanConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetEggDuiHuanConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetEggDuiHuanConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetEggDuiHuanConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetEggDuiHuanConfig> GetAll()
        {
            return this.dict;
        }

        public PetEggDuiHuanConfig GetOne()
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

	public partial class PetEggDuiHuanConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>消耗</summary>
		public string CostItems { get; set; }
		/// <summary>掉落ID</summary>
		public int DropID { get; set; }

	}
}
