using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SpiritConfigCategory : Singleton<SpiritConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SpiritConfig> dict = new();
		
        public void Merge(object o)
        {
            SpiritConfigCategory s = o as SpiritConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SpiritConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SpiritConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SpiritConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SpiritConfig> GetAll()
        {
            return this.dict;
        }

        public SpiritConfig GetOne()
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

	public partial class SpiritConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>章节ID</summary>
		public int ChapterID { get; set; }
		/// <summary>精灵Icon</summary>
		public string Icon { get; set; }
		/// <summary>精灵类型</summary>
		public int Type { get; set; }
		/// <summary>精灵名称</summary>
		public string Name { get; set; }
		/// <summary>精灵模型</summary>
		public string ModelID { get; set; }
		/// <summary>精灵属性</summary>
		public string Proprety { get; set; }
		/// <summary>主动触发技能</summary>
		public string SkillID { get; set; }
		/// <summary>掉落怪物</summary>
		public int MonsterID { get; set; }
		/// <summary>精灵描述</summary>
		public string Des { get; set; }

	}
}
