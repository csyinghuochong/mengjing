using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class LifeShieldConfigCategory : Singleton<LifeShieldConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, LifeShieldConfig> dict = new();
		
        public void Merge(object o)
        {
            LifeShieldConfigCategory s = o as LifeShieldConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public LifeShieldConfig Get(int id)
        {
            this.dict.TryGetValue(id, out LifeShieldConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (LifeShieldConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, LifeShieldConfig> GetAll()
        {
            return this.dict;
        }

        public LifeShieldConfig GetOne()
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

	public partial class LifeShieldConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>生命之盾类型</summary>
		public int ShieldType { get; set; }
		/// <summary>名字</summary>
		public string ShieldName { get; set; }
		/// <summary>等级</summary>
		public int ShieldLevel { get; set; }
		/// <summary>生命之盾经验</summary>
		public int ShieldExp { get; set; }
		/// <summary>额外属性</summary>
		public string AddProperty { get; set; }
		/// <summary>额外描述</summary>
		public string Des { get; set; }

	}
}
