using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (GameSettingLanguge))]
    [EntitySystemOf(typeof (GameSettingLanguge))]
    public static partial class GameSettingLangugeSystem
    {
        [EntitySystem]
        private static void Awake(this GameSettingLanguge self)
        {
            GameSettingLanguge.Instance = self;
            self.InitRandomName().Coroutine();
        }

        private static async ETTask InitRandomName(this GameSettingLanguge self)
        {
            if (self.randomName_xing == null)
            {
                Log.Warning("222222222");
                var path_1 = ABPathHelper.GetTextPath("RandName_Xing");
                var path_2 = ABPathHelper.GetTextPath("RandName_Name");
                TextAsset textAsset1 = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>(path_1);
                TextAsset textAsset2 = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>(path_2);
                self.LoadWWW_Xing(textAsset1.text);
                self.LoadWWW_Name(textAsset2.text);
            }
        }

        private static void LoadWWW_Xing(this GameSettingLanguge self, string wwwStr)
        {
            Log.Warning("1111111111111111111");
            wwwStr = wwwStr.Replace("\r", "");
            wwwStr = wwwStr.Replace("\n", "");

            //将读取到的字符串进行分割后存储到定义好的数组中
            self.randomName_xing = wwwStr.Split('@');

            self.ranNameNum += 1;
        }

        private static void LoadWWW_Name(this GameSettingLanguge self, string wwwStr)
        {
            wwwStr = wwwStr.Replace("\r", "");
            wwwStr = wwwStr.Replace("\n", "");

            //将读取到的字符串进行分割后存储到定义好的数组中
            self.randomName_name = wwwStr.Split('@');

            self.ranNameNum += 1;
        }

        public static string LoadLocalization(this GameSettingLanguge self, string getString)
        {
            return self.GetText(getString);
        }

        public static string GetText(this GameSettingLanguge self, string text)
        {
            //通过传进来的中文KEY 去数据表里面读对应替换的多语言文字
            if (self.Chinese)
            {
                return text;
            }

            if (self.MulLanguge.ContainsKey(text))
            {
                return self.MulLanguge[text];
            }

            List<MulLanguageConfig> configs = MulLanguageConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < configs.Count; i++)
            {
                if (configs[i].Chinese.Equals(text))
                {
                    self.MulLanguge.Add(text, configs[i].English);
                    return configs[i].English;
                }
            }

            return text;
        }
    }

    [ComponentOf(typeof (Scene))]
    public class GameSettingLanguge: Entity, IAwake
    {
        [StaticField]
        public static GameSettingLanguge Instance { get; set; }

        public int ranNameNum { get; set; }

        public string[] randomName_xing { get; set; }

        public string[] randomName_name { get; set; }

        public bool langLoadStatus { get; set; } //本地化语言加载状态 

        public bool Chinese = true;

        public struct LangugeType
        {
            public string cn;
            public string en;
        }

        public Dictionary<string, LangugeType> LangugeList = new();

        public Dictionary<string, string> MulLanguge = new();
    }
}