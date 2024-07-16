using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class QuestionBankConfigCategory : Singleton<QuestionBankConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, QuestionBankConfig> dict = new();
		
        public void Merge(object o)
        {
            QuestionBankConfigCategory s = o as QuestionBankConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public QuestionBankConfig Get(int id)
        {
            this.dict.TryGetValue(id, out QuestionBankConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (QuestionBankConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, QuestionBankConfig> GetAll()
        {
            return this.dict;
        }

        public QuestionBankConfig GetOne()
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

	public partial class QuestionBankConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>正确答案</summary>
		public string Right { get; set; }
		/// <summary>错误答案</summary>
		public string Error { get; set; }
		/// <summary>问题</summary>
		public string Question { get; set; }

	}
}
