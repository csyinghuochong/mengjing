using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class OccupationConfigCategory : Singleton<OccupationConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, OccupationConfig> dict = new();
		
        public void Merge(object o)
        {
            OccupationConfigCategory s = o as OccupationConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public OccupationConfig Get(int id)
        {
            this.dict.TryGetValue(id, out OccupationConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (OccupationConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, OccupationConfig> GetAll()
        {
            return this.dict;
        }

        public OccupationConfig GetOne()
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

	public partial class OccupationConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>职业名称</summary>
		public string OccupationName { get; set; }
		/// <summary>模型</summary>
		public string ModelAsset { get; set; }
		/// <summary>支持换装</summary>
		public int ChangeEquip { get; set; }
		/// <summary>初始血量</summary>
		public long BaseHp { get; set; }
		/// <summary>初始攻击最小值</summary>
		public long BaseMinAct { get; set; }
		/// <summary>初始攻击最大值</summary>
		public long BaseMaxAct { get; set; }
		/// <summary>初始物防最小值</summary>
		public long BaseMinDef { get; set; }
		/// <summary>初始物防最大值</summary>
		public long BaseMaxDef { get; set; }
		/// <summary>初始魔防最小值</summary>
		public long BaseMinAdf { get; set; }
		/// <summary>初始魔防最大值</summary>
		public long BaseMaxAdf { get; set; }
		/// <summary>初始移动速度</summary>
		public double BaseMoveSpeed { get; set; }
		/// <summary>初始暴击值</summary>
		public double BaseCri { get; set; }
		/// <summary>初始命中值</summary>
		public double BaseHit { get; set; }
		/// <summary>初始闪避值</summary>
		public double BaseDodge { get; set; }
		/// <summary>初始物理免伤</summary>
		public double BaseDefAdd { get; set; }
		/// <summary>初始魔法免伤</summary>
		public double BaseAdfAdd { get; set; }
		/// <summary>初始免伤</summary>
		public double DamgeAdd { get; set; }
		/// <summary>每级血量成长</summary>
		public long LvUpHp { get; set; }
		/// <summary>每级攻击最小级成长</summary>
		public long LvUpMinAct { get; set; }
		/// <summary>每级攻击最大值成长</summary>
		public long LvUpMaxAct { get; set; }
		/// <summary>每级攻击最小级成长</summary>
		public long LvUpMinMagAct { get; set; }
		/// <summary>每级攻击最大值成长</summary>
		public long LvUpMaxMagAct { get; set; }
		/// <summary>初始物防最小值</summary>
		public long LvUpMinDef { get; set; }
		/// <summary>初始物防最大值</summary>
		public long LvUpMaxDef { get; set; }
		/// <summary>初始魔防最小值</summary>
		public long LvUpMinAdf { get; set; }
		/// <summary>初始魔防最大值</summary>
		public long LvUpMaxAdf { get; set; }
		/// <summary>初始化普通攻击</summary>
		public int InitActSkillID { get; set; }
		/// <summary>初始化技能ID</summary>
		public int[] InitSkillID { get; set; }
		/// <summary>转职ID</summary>
		public int[] OccTwoID { get; set; }
		/// <summary>时装部件</summary>
		public int[] FashionBase { get; set; }
		/// <summary>基础技能</summary>
		public int[] BaseSkill { get; set; }

	}
}
