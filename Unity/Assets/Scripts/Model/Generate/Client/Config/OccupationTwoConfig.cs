using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class OccupationTwoConfigCategory : Singleton<OccupationTwoConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, OccupationTwoConfig> dict = new();
		
        public void Merge(object o)
        {
            OccupationTwoConfigCategory s = o as OccupationTwoConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public OccupationTwoConfig Get(int id)
        {
            this.dict.TryGetValue(id, out OccupationTwoConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (OccupationTwoConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, OccupationTwoConfig> GetAll()
        {
            return this.dict;
        }

        public OccupationTwoConfig GetOne()
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

	public partial class OccupationTwoConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>职业名称</summary>
		public string OccupationName { get; set; }
		/// <summary>职业特点描述</summary>
		public string OccDes { get; set; }
		/// <summary>初始化技能ID</summary>
		public int[] SkillID { get; set; }
		/// <summary>转职显示技能</summary>
		public int[] ShowTalentSkill { get; set; }
		/// <summary>职业能力</summary>
		public int[] Capacitys { get; set; }
		/// <summary>武器类型</summary>
		public int WeaponType { get; set; }
		/// <summary>护甲专精</summary>
		public int ArmorMastery { get; set; }
		/// <summary>转职显示被动技能</summary>
		public int[] ShowPassiveSkill { get; set; }
		/// <summary>觉醒技能</summary>
		public int[] JueXingSkill { get; set; }

	}
}
