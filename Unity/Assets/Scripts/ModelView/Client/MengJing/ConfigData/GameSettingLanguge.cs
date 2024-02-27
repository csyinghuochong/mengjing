using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace ET.Client
{
    public static class GameSettingLanguge
    {
        [StaticField]
        public static int ranNameNum;

        [StaticField]
        public static string[] randomName_xing;

        [StaticField]
        public static string[] randomName_name;

        [StaticField]
        public static bool langLoadStatus; //本地化语言加载状态 

        [StaticField]
        public static bool Chinese = true;

        public struct LangugeType
        {
            public string cn;
            public string en;
        }

        [StaticField]
        public static Dictionary<string, LangugeType> LangugeList = new();

        [StaticField]
        public static Dictionary<string, string> MulLanguge = new();

        public static string LoadLocalization(string getString)
        {
            return GetText(getString);
        }

        public static string GetText(string text)
        {
            //通过传进来的中文KEY 去数据表里面读对应替换的多语言文字
            if (Chinese)
            {
                return text;
            }

            if (MulLanguge.ContainsKey(text))
            {
                return MulLanguge[text];
            }

            List<MulLanguageConfig> configs = MulLanguageConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < configs.Count; i++)
            {
                if (configs[i].Chinese.Equals(text))
                {
                    MulLanguge.Add(text, configs[i].English);
                    return configs[i].English;
                }
            }

            return text;
        }
    }
}