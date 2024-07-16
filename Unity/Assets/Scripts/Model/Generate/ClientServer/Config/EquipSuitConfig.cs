using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipSuitConfigCategory : Singleton<EquipSuitConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipSuitConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipSuitConfigCategory s = o as EquipSuitConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipSuitConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipSuitConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipSuitConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipSuitConfig> GetAll()
        {
            return this.dict;
        }

        public EquipSuitConfig GetOne()
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

	public partial class EquipSuitConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>套装名称</summary>
		public string Name { get; set; }
		/// <summary>需要装备ID</summary>
		public int[] NeedEquipID { get; set; }
		/// <summary>套装属性</summary>
		public string SuitPropertyID { get; set; }
		/// <summary>套装类型</summary>
		public int SuitType { get; set; }
		/// <summary>职业</summary>
		public int Occ { get; set; }

	}
}
