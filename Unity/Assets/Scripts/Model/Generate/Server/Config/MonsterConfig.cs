using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MonsterConfigCategory : Singleton<MonsterConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MonsterConfig> dict = new();
		
        public void Merge(object o)
        {
            MonsterConfigCategory s = o as MonsterConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MonsterConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MonsterConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MonsterConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MonsterConfig> GetAll()
        {
            return this.dict;
        }

        public MonsterConfig GetOne()
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

	public partial class MonsterConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>怪物名称</summary>
		public string MonsterName { get; set; }
		/// <summary>怪物类型</summary>
		public int MonsterType { get; set; }
		/// <summary>怪物子类</summary>
		public int MonsterSonType { get; set; }
		/// <summary>阵营</summary>
		public int MonsterCamp { get; set; }
		/// <summary>怪物种族</summary>
		public int MonsterRace { get; set; }
		/// <summary>怪物头像</summary>
		public string MonsterHeadIcon { get; set; }
		/// <summary>怪物模型ID</summary>
		public int MonsterModelID { get; set; }
		/// <summary>触发精灵概率</summary>
		public double SpiritPro { get; set; }
		/// <summary>触发精灵ID</summary>
		public int SpiritID { get; set; }
		/// <summary>怪物等级</summary>
		public int Lv { get; set; }
		/// <summary>移动速度</summary>
		public double MoveSpeed { get; set; }
		/// <summary>攻击距离</summary>
		public double ActDistance { get; set; }
		/// <summary>巡逻速度</summary>
		public int WalkSpeed { get; set; }
		/// <summary>怪物生命</summary>
		public int Hp { get; set; }
		/// <summary>攻击</summary>
		public int Act { get; set; }
		/// <summary>魔法攻击</summary>
		public int MageAct { get; set; }
		/// <summary>物理防御</summary>
		public int Def { get; set; }
		/// <summary>魔法防御</summary>
		public int Adf { get; set; }
		/// <summary>暴击概率</summary>
		public double Cri { get; set; }
		/// <summary>抗暴概率</summary>
		public double Res { get; set; }
		/// <summary>附加命中概率</summary>
		public double Hit { get; set; }
		/// <summary>附加闪避概率</summary>
		public double Dodge { get; set; }
		/// <summary>怪物物理免伤</summary>
		public double DefAdd { get; set; }
		/// <summary>怪物魔法免伤</summary>
		public double AdfAdd { get; set; }
		/// <summary>怪物免伤</summary>
		public double DamgeAdd { get; set; }
		/// <summary>怪物复活时间</summary>
		public double ReviveTime { get; set; }
		/// <summary>巡逻范围</summary>
		public double PatrolRange { get; set; }
		/// <summary>追击范围</summary>
		public double ChaseRange { get; set; }
		/// <summary>攻击范围</summary>
		public double ActRange { get; set; }
		/// <summary>攻击间隔时间</summary>
		public double ActInterValTime { get; set; }
		/// <summary>怪物经验</summary>
		public int Exp { get; set; }
		/// <summary>是否显示大血条</summary>
		public int IfBoss { get; set; }
		/// <summary>选中条大小</summary>
		public double SelectSize { get; set; }
		/// <summary>掉落类型</summary>
		public int DropType { get; set; }
		/// <summary>造成伤害才有掉落</summary>
		public int IfDamgeDrop { get; set; }
		/// <summary>掉落ID</summary>
		public int[] DropID { get; set; }
		/// <summary>分级掉落</summary>
		public string LvDropID { get; set; }
		/// <summary>极品掉落概率</summary>
		public double HideDropPro { get; set; }
		/// <summary>怪物出现概率</summary>
		public double MonsterShowPro { get; set; }
		/// <summary>普通攻击ID</summary>
		public int ActSkillID { get; set; }
		/// <summary>技能ID</summary>
		public int[] SkillID { get; set; }
		/// <summary>怪物参数</summary>
		public int[] Parameter { get; set; }
		/// <summary>AI</summary>
		public int AI { get; set; }
		/// <summary>AI相关参数</summary>
		public string AIParameter { get; set; }
		/// <summary>AI延迟时间</summary>
		public int AIDelay { get; set; }
		/// <summary>怪物出生自动死亡时间</summary>
		public int DeathTime { get; set; }
		/// <summary>怪物死亡触发技能</summary>
		public int DeathSkillId { get; set; }
		/// <summary>开服天数刷怪变化</summary>
		public string OpenDayMonster { get; set; }
		/// <summary>攻击初始位置</summary>
		public double ActBasePosiY { get; set; }
		/// <summary>是否对敌人隐身</summary>
		public int IfHide { get; set; }
		/// <summary>是否带走buff</summary>
		public int RemoveBuff { get; set; }
		/// <summary>奇遇宠物id</summary>
		public int[] QiYuPetId { get; set; }

	}
}
