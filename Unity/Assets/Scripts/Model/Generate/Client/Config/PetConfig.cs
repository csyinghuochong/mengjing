using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PetConfigCategory : Singleton<PetConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PetConfig> dict = new();
		
        public void Merge(object o)
        {
            PetConfigCategory s = o as PetConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PetConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PetConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PetConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PetConfig> GetAll()
        {
            return this.dict;
        }

        public PetConfig GetOne()
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

	public partial class PetConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>宠物名称</summary>
		public string PetName { get; set; }
		/// <summary>头像Icon</summary>
		public string HeadIcon { get; set; }
		/// <summary>宠物Model</summary>
		public int PetModel { get; set; }
		/// <summary>洗炼变异</summary>
		public int PetBianYiID { get; set; }
		/// <summary>宠物显示的位置</summary>
		public string ModelShowPosi { get; set; }
		/// <summary>宠物类型</summary>
		public int PetType { get; set; }
		/// <summary>宠物等级</summary>
		public int PetLv { get; set; }
		/// <summary>宠物品质</summary>
		public int PetQuality { get; set; }
		/// <summary>出战等级</summary>
		public int FightLv { get; set; }
		/// <summary>默认星数</summary>
		public int[] InitStartNum { get; set; }
		/// <summary>基础评分</summary>
		public string Base_PingFen { get; set; }
		/// <summary>宠物种族</summary>
		public int PetRace { get; set; }
		/// <summary>血量资质</summary>
		public int ZiZhi_Hp_Min { get; set; }
		/// <summary>血量资质</summary>
		public int ZiZhi_Hp_Max { get; set; }
		/// <summary>攻击资质</summary>
		public int ZiZhi_Act_Min { get; set; }
		/// <summary>攻击资质</summary>
		public int ZiZhi_Act_Max { get; set; }
		/// <summary>攻击资质</summary>
		public int ZiZhi_MageAct_Min { get; set; }
		/// <summary>攻击资质</summary>
		public int ZiZhi_MageAct_Max { get; set; }
		/// <summary>物防资质</summary>
		public int ZiZhi_Def_Min { get; set; }
		/// <summary>物防资质</summary>
		public int ZiZhi_Def_Max { get; set; }
		/// <summary>法防资质</summary>
		public int ZiZhi_Adf_Min { get; set; }
		/// <summary>法防资质</summary>
		public int ZiZhi_Adf_Max { get; set; }
		/// <summary>攻速资质</summary>
		public int ZiZhi_ActSpeed_Min { get; set; }
		/// <summary>攻速资质</summary>
		public int ZiZhi_ActSpeed_Max { get; set; }
		/// <summary>成长资质</summary>
		public double ZiZhi_ChengZhang_Min { get; set; }
		/// <summary>成长资质</summary>
		public double ZiZhi_ChengZhang_Max { get; set; }
		/// <summary>血量</summary>
		public int Base_Hp { get; set; }
		/// <summary>攻击</summary>
		public int Base_Act { get; set; }
		/// <summary>魔法攻击</summary>
		public int Base_MageAct { get; set; }
		/// <summary>物防</summary>
		public int Base_Def { get; set; }
		/// <summary>魔防</summary>
		public int Base_Adf { get; set; }
		/// <summary>暴击</summary>
		public double Base_Cri { get; set; }
		/// <summary>抗暴</summary>
		public int Base_Res { get; set; }
		/// <summary>命中</summary>
		public double Base_Hit { get; set; }
		/// <summary>闪避</summary>
		public double Base_Dodge { get; set; }
		/// <summary>物理免伤</summary>
		public int Base_DefAdd { get; set; }
		/// <summary>魔法免伤</summary>
		public int Base_AdfAdd { get; set; }
		/// <summary>怪物免伤</summary>
		public int Base_DamgeAdd { get; set; }
		/// <summary>移动速度</summary>
		public int Base_MoveSpeed { get; set; }
		/// <summary>攻击速度</summary>
		public double Base_ActSpeed { get; set; }
		/// <summary>攻击距离</summary>
		public double ActDistance { get; set; }
		/// <summary>等级成长血量</summary>
		public double Lv_Hp { get; set; }
		/// <summary>等级成长攻击</summary>
		public double Lv_Act { get; set; }
		/// <summary>等级成长魔法攻击</summary>
		public double Lv_MageAct { get; set; }
		/// <summary>等级成长物防</summary>
		public double Lv_Def { get; set; }
		/// <summary>等级成长魔防</summary>
		public double Lv_Adf { get; set; }
		/// <summary>监视范围(未用)</summary>
		public int PatrolRange { get; set; }
		/// <summary>追击范围</summary>
		public int ChaseRange { get; set; }
		/// <summary>攻击范围(未用)</summary>
		public int ActRunRange { get; set; }
		/// <summary>抓捕狂暴概率</summary>
		public double Exp { get; set; }
		/// <summary>选中条大小</summary>
		public int SelectSize { get; set; }
		/// <summary>放生奖励</summary>
		public int[] ReleaseReward { get; set; }
		/// <summary>专注技能</summary>
		public string ZhuanZhuSkillID { get; set; }
		/// <summary>怪物普通攻击</summary>
		public int ActSkillID { get; set; }
		/// <summary>宠物必带技能ID</summary>
		public string BaseSkillID { get; set; }
		/// <summary>宠物随机技能ID</summary>
		public string RandomSkillID { get; set; }
		/// <summary>宠物皮肤</summary>
		public int[] Skin { get; set; }
		/// <summary>宠物皮肤激活概率</summary>
		public int[] SkinPro { get; set; }
		/// <summary>攻击方式</summary>
		public int AttackType { get; set; }

	}
}
