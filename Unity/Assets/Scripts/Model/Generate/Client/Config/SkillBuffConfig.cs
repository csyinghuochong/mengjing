using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SkillBuffConfigCategory : Singleton<SkillBuffConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SkillBuffConfig> dict = new();
		
        public void Merge(object o)
        {
            SkillBuffConfigCategory s = o as SkillBuffConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SkillBuffConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillBuffConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillBuffConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillBuffConfig> GetAll()
        {
            return this.dict;
        }

        public SkillBuffConfig GetOne()
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

	public partial class SkillBuffConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>状态名称</summary>
		public string BuffName { get; set; }
		/// <summary>广播目标类型</summary>
		public int BroadcastType { get; set; }
		/// <summary>Buff等级</summary>
		public int BuffLv { get; set; }
		/// <summary>切换场景保留</summary>
		public int Transfer { get; set; }
		/// <summary>Buff图标类型</summary>
		public string BuffIconType { get; set; }
		/// <summary>Buff图标</summary>
		public string BuffIcon { get; set; }
		/// <summary>Buff存在时间</summary>
		public int BuffTime { get; set; }
		/// <summary>Buff延迟生效时间</summary>
		public int BuffDelayTime { get; set; }
		/// <summary>循环触发时间</summary>
		public int BuffLoopTime { get; set; }
		/// <summary>Buff目标类型</summary>
		public int TargetType { get; set; }
		/// <summary>Buff脚本</summary>
		public string BuffScript { get; set; }
		/// <summary>Buff类型</summary>
		public int BuffType { get; set; }
		/// <summary>Buff增益减益</summary>
		public int BuffBenefitType { get; set; }
		/// <summary>Buff参数操作类型</summary>
		public int buffParameterType { get; set; }
		/// <summary>Buff参数操作值</summary>
		public double buffParameterValue { get; set; }
		/// <summary>Buff参数操作值2</summary>
		public string buffParameterValue2 { get; set; }
		/// <summary>buff操作参数值类型</summary>
		public int buffParameterValueType { get; set; }
		/// <summary>buff操作参数值类型定义</summary>
		public int buffParameterValueDef { get; set; }
		/// <summary>Buff是否叠加</summary>
		public int BuffAddClass { get; set; }
		/// <summary>Buff是叠加层数上限</summary>
		public int BuffAddClassMax { get; set; }
		/// <summary>buff叠加后时间统一</summary>
		public int BuffAddSync { get; set; }
		/// <summary>唯一buffID</summary>
		public string WeiYiBuffID { get; set; }
		/// <summary>伤害类型</summary>
		public int DamgeType { get; set; }
		/// <summary>伤害系数</summary>
		public double DamgePro { get; set; }
		/// <summary>固定伤害值</summary>
		public int DamgeValue { get; set; }
		/// <summary>是否立即释放</summary>
		public int IfImmediatelyUse { get; set; }
		/// <summary>是否在主界面显示BuffIcon</summary>
		public int IfShowIconTips { get; set; }
		/// <summary>buff特效</summary>
		public int BuffEffectID { get; set; }
		/// <summary>Buff描述</summary>
		public string BuffDescribe { get; set; }
		/// <summary>附加目标类型</summary>
		public int[] BuffTargetType { get; set; }
		/// <summary>移除机制</summary>
		public int Remove { get; set; }
		/// <summary>移动触发</summary>
		public int MoveAction { get; set; }
		/// <summary>叠加层数触发技能</summary>
		public int[] AddSkill { get; set; }
		/// <summary>被击杀后是否移除机制</summary>
		public int DeadNoRemove { get; set; }
		/// <summary>触发技能</summary>
		public string BuffToSkill { get; set; }

	}
}
