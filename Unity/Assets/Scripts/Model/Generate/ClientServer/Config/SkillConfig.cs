using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SkillConfigCategory : Singleton<SkillConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SkillConfig> dict = new();
		
        public void Merge(object o)
        {
            SkillConfigCategory s = o as SkillConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SkillConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillConfig> GetAll()
        {
            return this.dict;
        }

        public SkillConfig GetOne()
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

	public partial class SkillConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>技能名称</summary>
		public string SkillName { get; set; }
		/// <summary>技能等级</summary>
		public int SkillLv { get; set; }
		/// <summary>技能Icon</summary>
		public string SkillIcon { get; set; }
		/// <summary>下一级技能</summary>
		public int NextSkillID { get; set; }
		/// <summary>使用武器触发</summary>
		public int WeaponType { get; set; }
		/// <summary>学习技能等级</summary>
		public int LearnRoseLv { get; set; }
		/// <summary>升级消耗SP值</summary>
		public int CostSPValue { get; set; }
		/// <summary>升级消耗金币</summary>
		public int CostGoldValue { get; set; }
		/// <summary>被控制是否可以放技能</summary>
		public int OpenType { get; set; }
		/// <summary>装备升级前ID</summary>
		public string EquipSkill { get; set; }
		/// <summary>技能类型</summary>
		public int SkillType { get; set; }
		/// <summary>被动技能触发类型</summary>
		public int[] PassiveSkillType { get; set; }
		/// <summary>被动技能触发参数</summary>
		public double[] PassiveSkillPro { get; set; }
		/// <summary>被动技能触发一次</summary>
		public int PassiveSkillTriggerOnce { get; set; }
		/// <summary>施法目标</summary>
		public int SkillTargetTypeNum { get; set; }
		/// <summary>连招技能ID</summary>
		public int ComboSkillID { get; set; }
		/// <summary>技能攻击类型</summary>
		public int SkillActType { get; set; }
		/// <summary>伤害类型</summary>
		public int DamgeType { get; set; }
		/// <summary>伤害元素攻击</summary>
		public int DamgeElementType { get; set; }
		/// <summary>攻击系数</summary>
		public double ActDamge { get; set; }
		/// <summary>怪物攻击系数</summary>
		public double MonsterActDamge { get; set; }
		/// <summary>固定伤害值</summary>
		public int DamgeValue { get; set; }
		/// <summary>是否必中</summary>
		public int IfMustAct { get; set; }
		/// <summary>消耗魔法</summary>
		public int SkillUseMP { get; set; }
		/// <summary>增加魔法</summary>
		public int SkillAddMP { get; set; }
		/// <summary>是否触发公共CD</summary>
		public int IfPublicSkillCD { get; set; }
		/// <summary>是否触发冷却技能CD(废弃)</summary>
		public int IfSkillCD { get; set; }
		/// <summary>冷却CD</summary>
		public double SkillCD { get; set; }
		/// <summary>伤害范围类型</summary>
		public int DamgeRangeType { get; set; }
		/// <summary>伤害范围</summary>
		public double[] DamgeRange { get; set; }
		/// <summary>技能目标类型</summary>
		public int SkillTargetType { get; set; }
		/// <summary>释放区域类型</summary>
		public int SkillZhishiType { get; set; }
		/// <summary>释放区域目标点类型</summary>
		public int SkillZhishiTargetType { get; set; }
		/// <summary>释放区域大小</summary>
		public double SkillRangeSize { get; set; }
		/// <summary>技能指示器增加范围</summary>
		public int SkillRangeZhiShiSize { get; set; }
		/// <summary>施法前吟唱时间</summary>
		public double SkillFrontSingTime { get; set; }
		/// <summary>施法中吟唱时间</summary>
		public double SkillSingTime { get; set; }
		/// <summary>技能僵直</summary>
		public double SkillRigidity { get; set; }
		/// <summary>技能存在时间[毫秒]</summary>
		public int SkillLiveTime { get; set; }
		/// <summary>技能效果延迟时间</summary>
		public double SkillDelayTime { get; set; }
		/// <summary>技能移动速度</summary>
		public double SkillMoveSpeed { get; set; }
		/// <summary>初始化BUFFID</summary>
		public int[] InitBuffID { get; set; }
		/// <summary>释放BUFFID</summary>
		public int[] BuffID { get; set; }
		/// <summary>只释放一次buff</summary>
		public int[] OnlyOnceBuffID { get; set; }
		/// <summary>施法动作名称</summary>
		public string SkillAnimation { get; set; }
		/// <summary>技能音效</summary>
		public string SkillMusic { get; set; }
		/// <summary>技能特效ID</summary>
		public int SkillHitEffectID { get; set; }
		/// <summary>技能特效ID</summary>
		public int[] SkillEffectID { get; set; }
		/// <summary>脚本名称</summary>
		public string GameObjectName { get; set; }
		/// <summary>每个脚本对应参数</summary>
		public string GameObjectParameter { get; set; }
		/// <summary>所有脚本通用参数</summary>
		public string ComObjParameter { get; set; }
		/// <summary>是否显示</summary>
		public int IsShow { get; set; }
		/// <summary>技能描述</summary>
		public string SkillDescribe { get; set; }
		/// <summary>施法时面对目标时间</summary>
		public double IfLookAtTatgetTime { get; set; }
		/// <summary>触发技能时附带技能</summary>
		public int AddSkillID { get; set; }
		/// <summary>技能触发时间</summary>
		public double PassiveSkillTriggerTime { get; set; }
		/// <summary>施法时是否面对目标</summary>
		public int IfLookAtTarget { get; set; }
		/// <summary>怪物技能延迟</summary>
		public double MonsterDelayTime { get; set; }
		/// <summary>宠物互斥ID</summary>
		public int HuChiID { get; set; }
		/// <summary>触发自身拥有技能</summary>
		public int[] TriggerSelfSkillID { get; set; }
		/// <summary>释放技能是否打断移动</summary>
		public int IfStopMove { get; set; }
		/// <summary>技能持续伤害是否触发Buff</summary>
		public int DamgeChiXuTrigerBuff { get; set; }
		/// <summary>技能持续伤害间隔时间</summary>
		public int DamgeChiXuInterval { get; set; }
		/// <summary>技能持续伤害百分比</summary>
		public double DamgeChiXuPro { get; set; }
		/// <summary>技能持续伤害固定值</summary>
		public int DamgeChiXuValue { get; set; }
		/// <summary>是否显示技能指示器字段</summary>
		public int IfShowSkillZhiShi { get; set; }
		/// <summary>结束时技能</summary>
		public int EndSkillId { get; set; }
		/// <summary>触发技能</summary>
		public string BuffToSkill { get; set; }
		/// <summary>技能伤害增加</summary>
		public string SkillDamgeAddValue { get; set; }
		/// <summary>最大攻击数量</summary>
		public int MaxAttackNumber { get; set; }
		/// <summary>震屏类型</summary>
		public int ShakeCameraType { get; set; }
		/// <summary>震屏开始时间</summary>
		public double ShakeStart { get; set; }
		/// <summary>震持续时间</summary>
		public double ShakeDuration { get; set; }

	}
}
