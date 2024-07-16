using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class NpcConfigCategory : Singleton<NpcConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, NpcConfig> dict = new();
		
        public void Merge(object o)
        {
            NpcConfigCategory s = o as NpcConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public NpcConfig Get(int id)
        {
            this.dict.TryGetValue(id, out NpcConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (NpcConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, NpcConfig> GetAll()
        {
            return this.dict;
        }

        public NpcConfig GetOne()
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

	public partial class NpcConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>商店值</summary>
		public int ShopValue { get; set; }
		/// <summary>NPC类型</summary>
		public int NpcType { get; set; }
		/// <summary>任务ID</summary>
		public int[] TaskID { get; set; }
		/// <summary>剧情对话ID</summary>
		public int[] StorySpeakID { get; set; }
		/// <summary>npc参数</summary>
		public int[] NpcPar { get; set; }
		/// <summary>描述</summary>
		public string Desc { get; set; }
		/// <summary>资源</summary>
		public string Asset { get; set; }
		/// <summary>位置</summary>
		public int[] Position { get; set; }
		/// <summary>方向</summary>
		public int Rotation { get; set; }
		/// <summary>AI</summary>
		public int AI { get; set; }
		/// <summary>移动坐标</summary>
		public string MovePosition { get; set; }
		/// <summary>摄像头是否拉近</summary>
		public int ifCameraLaJin { get; set; }
		/// <summary>对话信息</summary>
		public string SpeakText { get; set; }
		/// <summary>头部说话</summary>
		public string NpcHeadSpeakText { get; set; }
		/// <summary>任务提示</summary>
		public string TaskHint { get; set; }
		/// <summary>播放音效ID</summary>
		public int SourceID { get; set; }
		/// <summary>展示等级</summary>
		public int ShowRoseLv { get; set; }
		/// <summary>出现类型</summary>
		public int ShowType { get; set; }
		/// <summary>出现值</summary>
		public int ShowValue { get; set; }
		/// <summary>商店类型</summary>
		public int ShopType { get; set; }

	}
}
