using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SkillWeaponConfigCategory : Singleton<SkillWeaponConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SkillWeaponConfig> dict = new();
		
        public void Merge(object o)
        {
            SkillWeaponConfigCategory s = o as SkillWeaponConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SkillWeaponConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillWeaponConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillWeaponConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillWeaponConfig> GetAll()
        {
            return this.dict;
        }

        public SkillWeaponConfig GetOne()
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

	public partial class SkillWeaponConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>技能名称</summary>
		public string Name { get; set; }
		/// <summary>默认技能ID</summary>
		public int InitSkillID { get; set; }
		/// <summary>剑武器技能</summary>
		public int InitSkillID_1 { get; set; }
		/// <summary>刀武器技能</summary>
		public int InitSkillID_2 { get; set; }
		/// <summary>法杖</summary>
		public int InitSkillID_3 { get; set; }
		/// <summary>魔法书</summary>
		public int InitSkillID_4 { get; set; }
		/// <summary>弓箭</summary>
		public int InitSkillID_5 { get; set; }

	}
}
