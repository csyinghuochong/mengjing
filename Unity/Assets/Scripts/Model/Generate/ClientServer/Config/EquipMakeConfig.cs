using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipMakeConfigCategory : Singleton<EquipMakeConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipMakeConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipMakeConfigCategory s = o as EquipMakeConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipMakeConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipMakeConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipMakeConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipMakeConfig> GetAll()
        {
            return this.dict;
        }

        public EquipMakeConfig GetOne()
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

	public partial class EquipMakeConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>制造类型</summary>
		public int ProficiencyType { get; set; }
		/// <summary>制造装备</summary>
		public int MakeItemID { get; set; }
		/// <summary>学习类型</summary>
		public int LearnType { get; set; }
		/// <summary>学习等级</summary>
		public int LearnLv { get; set; }
		/// <summary>学习消耗金币</summary>
		public int LearnGoldValue { get; set; }
		/// <summary>消耗活力值</summary>
		public int CostVitality { get; set; }
		/// <summary>学习需要道具</summary>
		public string LearnNeedItems { get; set; }
		/// <summary>制造装备数量</summary>
		public int MakeEquipNum { get; set; }
		/// <summary>制作成功概率</summary>
		public double MakeSuccesPro { get; set; }
		/// <summary>领悟概率</summary>
		public double LearnPro { get; set; }
		/// <summary>触发隐藏属性概率</summary>
		public string MakeHintPro { get; set; }
		/// <summary>制造装备等级</summary>
		public int MakeLv { get; set; }
		/// <summary>制造装备最大等级</summary>
		public int MakeLvMax { get; set; }
		/// <summary>制造星级</summary>
		public int MakeStar { get; set; }
		/// <summary>需要熟练度</summary>
		public int NeedProficiencyValue { get; set; }
		/// <summary>增长熟练度上限</summary>
		public int ProficiencyMax { get; set; }
		/// <summary>增长熟练点数</summary>
		public int[] ProficiencyValue { get; set; }
		/// <summary>熟练度转换概率生效值</summary>
		public double ProficiencyStartProValue { get; set; }
		/// <summary>熟练点数转换概率</summary>
		public double ProficiencyProValue { get; set; }
		/// <summary>制造冷却时间</summary>
		public int MakeTime { get; set; }
		/// <summary>制造消耗金币</summary>
		public int MakeNeedGold { get; set; }
		/// <summary>需要道具</summary>
		public string NeedItems { get; set; }

	}
}
