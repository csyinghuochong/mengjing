using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class EffectConfigCategory : Singleton<EffectConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, EffectConfig> dict = new();
		
        public void Merge(object o)
        {
            EffectConfigCategory s = o as EffectConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public EffectConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EffectConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EffectConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EffectConfig> GetAll()
        {
            return this.dict;
        }

        public EffectConfig GetOne()
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

	public partial class EffectConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>特效类型</summary>
		public int EffectType { get; set; }
		/// <summary>特效是否跟随绑定</summary>
		public int IfFollowCollider { get; set; }
		/// <summary>特效名称</summary>
		public string EffectName { get; set; }
		/// <summary>技能效果延迟时间</summary>
		public double SkillEffectDelayTime { get; set; }
		/// <summary>绑定父级</summary>
		public int SkillParent { get; set; }
		/// <summary>绑定父级位置</summary>
		public string SkillParentPosition { get; set; }
		/// <summary>隐藏间隔时间</summary>
		public int HideTime { get; set; }
		/// <summary>技能特效存在时间[毫秒]</summary>
		public int SkillEffectLiveTime { get; set; }
		/// <summary>是否面向施法者播放特效</summary>
		public int PlayType { get; set; }
		/// <summary>缩放</summary>
		public double Scale { get; set; }

	}
}
