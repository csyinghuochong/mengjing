using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class TalentConfigCategory : Singleton<TalentConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, TalentConfig> dict = new();
		
        public void Merge(object o)
        {
            TalentConfigCategory s = o as TalentConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public TalentConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TalentConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TalentConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TalentConfig> GetAll()
        {
            return this.dict;
        }

        public TalentConfig GetOne()
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

	public partial class TalentConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>天赋名称</summary>
		public string Name { get; set; }
		/// <summary>职业</summary>
		public int Occ { get; set; }
		/// <summary>天赋类型</summary>
		public int TalentType { get; set; }
		/// <summary>天赋位置</summary>
		public int Position { get; set; }
		/// <summary>天赋等级</summary>
		public int Lv { get; set; }
		/// <summary>前置id</summary>
		public int[] PreId { get; set; }
		/// <summary>需要当前类型已使用天赋点</summary>
		public int NeedUseNumber { get; set; }
		/// <summary>学习等级</summary>
		public int LearnRoseLv { get; set; }
		/// <summary>Icon</summary>
		public int Icon { get; set; }
		/// <summary>天赋描述</summary>
		public string talentDes { get; set; }
		/// <summary>附加</summary>
		public string AddPropreListStr { get; set; }

	}
}
