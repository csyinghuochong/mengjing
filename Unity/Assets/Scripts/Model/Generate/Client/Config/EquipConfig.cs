using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EquipConfigCategory : Singleton<EquipConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EquipConfig> dict = new();
		
        public void Merge(object o)
        {
            EquipConfigCategory s = o as EquipConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EquipConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipConfig> GetAll()
        {
            return this.dict;
        }

        public EquipConfig GetOne()
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

	public partial class EquipConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>鉴定道具消耗</summary>
		public int AppraisalItem { get; set; }
		/// <summary>套装ID</summary>
		public int EquipSuitID { get; set; }
		/// <summary>隐藏属性类型</summary>
		public int HideType { get; set; }
		/// <summary>隐藏属性最大值</summary>
		public int HideMax { get; set; }
		/// <summary>单条隐藏属性出现概率</summary>
		public double HideShowPro { get; set; }
		/// <summary>一级属性随机值</summary>
		public int OneProRandomValue { get; set; }
		/// <summary>初始宝石孔位</summary>
		public int GemHole { get; set; }
		/// <summary>血量</summary>
		public int Equip_Hp { get; set; }
		/// <summary>最低攻击</summary>
		public int Equip_MinAct { get; set; }
		/// <summary>最高攻击</summary>
		public int Equip_MaxAct { get; set; }
		/// <summary>最低攻击</summary>
		public int Equip_MinMagAct { get; set; }
		/// <summary>最高攻击</summary>
		public int Equip_MaxMagAct { get; set; }
		/// <summary>最低防御</summary>
		public int Equip_MinDef { get; set; }
		/// <summary>最高防御</summary>
		public int Equip_MaxDef { get; set; }
		/// <summary>最低防御</summary>
		public int Equip_MinAdf { get; set; }
		/// <summary>最高防御</summary>
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
		/// <summary>附加属性类型</summary>
		public int[] AddPropreListType { get; set; }
		/// <summary>附加属性值</summary>
		public long[] AddPropreListValue { get; set; }
		/// <summary>是否显示属性</summary>
		public long[] AddPropreListIfShow { get; set; }
		/// <summary>附加</summary>
		public int TianFuId { get; set; }

	}
}
