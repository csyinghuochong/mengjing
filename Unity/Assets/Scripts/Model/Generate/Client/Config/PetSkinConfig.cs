using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetSkinConfigCategory : Singleton<PetSkinConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetSkinConfig> dict = new();
		
        public void Merge(object o)
        {
            PetSkinConfigCategory s = o as PetSkinConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetSkinConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetSkinConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetSkinConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetSkinConfig> GetAll()
        {
            return this.dict;
        }

        public PetSkinConfig GetOne()
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

	public partial class PetSkinConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>图标图标</summary>
		public int IconID { get; set; }
		/// <summary>模型ID</summary>
		public int SkinID { get; set; }
		/// <summary>激活属性(暂时不用)</summary>
		public string PripertySet { get; set; }
		/// <summary>激活属性描述</summary>
		public string PripertyShow { get; set; }

	}
}
