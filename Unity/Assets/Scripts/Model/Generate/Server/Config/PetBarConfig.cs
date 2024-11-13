using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetBarConfigCategory : Singleton<PetBarConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetBarConfig> dict = new();
		
        public void Merge(object o)
        {
            PetBarConfigCategory s = o as PetBarConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetBarConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetBarConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetBarConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetBarConfig> GetAll()
        {
            return this.dict;
        }

        public PetBarConfig GetOne()
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

	public partial class PetBarConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>技能栏名字</summary>
		public string Name { get; set; }
		/// <summary>等级</summary>
		public int Level { get; set; }
		/// <summary>升级消耗</summary>
		public string CostItems { get; set; }
		/// <summary>激活技能</summary>
		public int[] ActiveSkills { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }

	}
}
