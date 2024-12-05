using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetMagicCardConfigCategory : Singleton<PetMagicCardConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetMagicCardConfig> dict = new();
		
        public void Merge(object o)
        {
            PetMagicCardConfigCategory s = o as PetMagicCardConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetMagicCardConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetMagicCardConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetMagicCardConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetMagicCardConfig> GetAll()
        {
            return this.dict;
        }

        public PetMagicCardConfig GetOne()
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

	public partial class PetMagicCardConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>获取方式</summary>
		public int GetWay { get; set; }
		/// <summary>获取参数</summary>
		public int[] GetValue { get; set; }
		/// <summary>激活点数</summary>
		public int NeedPoint { get; set; }
		/// <summary>激活概率</summary>
		public double ActivePro { get; set; }
		/// <summary>类型</summary>
		public int Type { get; set; }
		/// <summary>召唤消耗</summary>
		public int Cost { get; set; }
		/// <summary>图标显示</summary>
		public int Icon { get; set; }
		/// <summary>技能Id</summary>
		public int SkillId { get; set; }
		/// <summary>只出现一次</summary>
		public int IsOnly { get; set; }

	}
}
