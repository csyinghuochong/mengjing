using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class DungeonConfigCategory : Singleton<DungeonConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, DungeonConfig> dict = new();
		
        public void Merge(object o)
        {
            DungeonConfigCategory s = o as DungeonConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public DungeonConfig Get(int id)
        {
            this.dict.TryGetValue(id, out DungeonConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (DungeonConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, DungeonConfig> GetAll()
        {
            return this.dict;
        }

        public DungeonConfig GetOne()
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

	public partial class DungeonConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>章节名称</summary>
		public string ChapterName { get; set; }
		/// <summary>音乐</summary>
		public string Music { get; set; }
		/// <summary>个人副本类型</summary>
		public int MapType { get; set; }
		/// <summary>进入等级限制</summary>
		public int EnterLv { get; set; }
		/// <summary>章节BossIcon</summary>
		public int BossIcon { get; set; }
		/// <summary>章节文本描述</summary>
		public string ChapterDes { get; set; }
		/// <summary>地图ID</summary>
		public int MapID { get; set; }
		/// <summary>loading图</summary>
		public string LoadingRes { get; set; }
		/// <summary>出生点</summary>
		public int[] BornPosLeft { get; set; }
		/// <summary>摄像机参数</summary>
		public double[] CameraPos { get; set; }
		/// <summary>传送点</summary>
		public int[] TransmitPos { get; set; }
		/// <summary>寻路</summary>
		public string AutoPath { get; set; }
		/// <summary>NPC</summary>
		public int[] NpcList { get; set; }
		/// <summary>野怪</summary>
		public int MonsterPosition { get; set; }
		/// <summary>对应章节</summary>
		public int ChapterId { get; set; }

	}
}
