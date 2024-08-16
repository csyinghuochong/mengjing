using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SceneConfigCategory : Singleton<SceneConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SceneConfig> dict = new();
		
        public void Merge(object o)
        {
            SceneConfigCategory s = o as SceneConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SceneConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SceneConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SceneConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SceneConfig> GetAll()
        {
            return this.dict;
        }

        public SceneConfig GetOne()
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

	public partial class SceneConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>章节名称</summary>
		public string Name { get; set; }
		/// <summary>图标显示</summary>
		public string Icon { get; set; }
		/// <summary>摆摊区域</summary>
		public int[] StallArea { get; set; }
		/// <summary>出生坐标点</summary>
		public int[] InitPos { get; set; }
		/// <summary>NPC</summary>
		public int[] NpcList { get; set; }
		/// <summary>地图类型</summary>
		public int MapType { get; set; }
		/// <summary>地图ID</summary>
		public int MapID { get; set; }
		/// <summary>loading图</summary>
		public string LoadingRes { get; set; }
		/// <summary>是否有小地图</summary>
		public int ifShowMinMap { get; set; }
		/// <summary>是否可以使用复活</summary>
		public int IfUseRes { get; set; }
		/// <summary>是否允许PVP</summary>
		public int IfPVP { get; set; }
		/// <summary>是否允许使用道具</summary>
		public int IfUseSkillItem { get; set; }
		/// <summary>返回主城是否在默认点</summary>
		public int IfInitPosi { get; set; }
		/// <summary>音乐</summary>
		public string Music { get; set; }
		/// <summary>创建等级限制</summary>
		public int CreateLv { get; set; }
		/// <summary>进入等级限制</summary>
		public int EnterLv { get; set; }
		/// <summary>推荐等级</summary>
		public int[] TuiJianLv { get; set; }
		/// <summary>进入人数限制</summary>
		public int PlayerLimit { get; set; }
		/// <summary>进入次数限制</summary>
		public int DayEnterNum { get; set; }
		/// <summary>是否可以上马</summary>
		public int IfMount { get; set; }
		/// <summary>章节BossId</summary>
		public int BossId { get; set; }
		/// <summary>怪物生成坐标点</summary>
		public int[] CreateMonsterPosi { get; set; }
		/// <summary>章节文本描述</summary>
		public string ChapterDes { get; set; }
		/// <summary>奖励展示</summary>
		public string RewardShow { get; set; }
		/// <summary>通关经验奖励</summary>
		public int RewardExp { get; set; }
		/// <summary>通关金币奖励</summary>
		public int RewardGold { get; set; }
		/// <summary>翻卡掉落ID</summary>
		public int BoxDropID { get; set; }
		/// <summary>摄像机参数</summary>
		public double[] CameraPos { get; set; }

	}
}
