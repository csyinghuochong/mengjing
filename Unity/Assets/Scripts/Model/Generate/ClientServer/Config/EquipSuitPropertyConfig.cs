using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipSuitPropertyConfigCategory : Singleton<EquipSuitPropertyConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipSuitPropertyConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipSuitPropertyConfigCategory s = o as EquipSuitPropertyConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipSuitPropertyConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipSuitPropertyConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipSuitPropertyConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipSuitPropertyConfig> GetAll()
        {
            return this.dict;
        }

        public EquipSuitPropertyConfig GetOne()
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

	public partial class EquipSuitPropertyConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>套装名称</summary>
		public string EquipSuitName { get; set; }
		/// <summary>套装名称2</summary>
		public string EquipSuitDes { get; set; }
		/// <summary>是否显示套装件数</summary>
		public int ifShowSuitNum { get; set; }
		/// <summary>血量</summary>
		public int Equip_Hp { get; set; }
		/// <summary>最低攻击</summary>
		public int Equip_MinAct { get; set; }
		/// <summary>最高攻击</summary>
		public int Equip_MaxAct { get; set; }
		/// <summary>最低攻击3</summary>
		public int Equip_MinMagAct { get; set; }
		/// <summary>最高攻击4</summary>
		public int Equip_MaxMagAct { get; set; }
		/// <summary>最低防御</summary>
		public int Equip_MinDef { get; set; }
		/// <summary>最高防御</summary>
		public int Equip_MaxDef { get; set; }
		/// <summary>最低防御5</summary>
		public int Equip_MinAdf { get; set; }
		/// <summary>最高防御6</summary>
		public int Equip_MaxAdf { get; set; }
		/// <summary>暴击</summary>
		public double Equip_Cri { get; set; }
		/// <summary>命中</summary>
		public double Equip_Hit { get; set; }
		/// <summary>闪避</summary>
		public double Equip_Dodge { get; set; }
		/// <summary>伤害加成</summary>
		public double Equip_DamgeAdd { get; set; }
		/// <summary>伤害减免</summary>
		public double Equip_DamgeSub { get; set; }
		/// <summary>速度</summary>
		public double Equip_Speed { get; set; }
		/// <summary>幸运值</summary>
		public int Equip_Lucky { get; set; }
		/// <summary>套装附加技能</summary>
		public int EquipSuitSkillID { get; set; }
		/// <summary>附加</summary>
		public string AddPropreListStr { get; set; }

	}
}
