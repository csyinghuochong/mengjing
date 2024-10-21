using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class LanguageComponent : Entity, IAwake
    {
        [StaticField]
        public static LanguageComponent Instance { get; set; }

        public int ranNameNum { get; set; }

        public string[] randomName_xing { get; set; }

        public string[] randomName_name { get; set; }

        public bool langLoadStatus { get; set; } //本地化语言加载状态 

        public bool Chinese = true;

        public struct LanguageType
        {
            public string cn;
            public string en;
        }

        public Dictionary<string, LanguageType> LanguageList = new();

        public Dictionary<string, string> MulLanguage = new();

        // 多语言插件
        public LanguageSource m_LanguageSource;
        public LanguageSourceData m_SourceData => m_LanguageSource.SourceData;

        public List<string> m_AllLanguage = new List<string>();

        public bool m_UseRuntimeModule = false; //模拟平台运行时 编辑器资源不加载

        public string m_DefaultLanguage;

        public string m_CurrentLanguage;
    }
}