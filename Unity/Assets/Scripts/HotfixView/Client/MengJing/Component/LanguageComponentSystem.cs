using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

namespace ET.Client
{
    public static class LanguageType
    {
        public const string Chinese = "Chinese";
        public const string English = "English";
        public const string Japanese = "Japanese";
    }
    
    [FriendOf(typeof(LanguageComponent))]
    [EntitySystemOf(typeof(LanguageComponent))]
    public static partial class GameSettingLanguageSystem
    {
        [EntitySystem]
        private static void Awake(this LanguageComponent self)
        {
            LanguageComponent.Instance = self;
            self.OnInit().Coroutine();
            self.OnInitL2Localization();
        }

        private static async ETTask OnInit(this LanguageComponent self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            if (self.randomName_xing == null)
            {
                var path_1 = ABPathHelper.GetTextPath("RandName_Xing");
                var path_2 = ABPathHelper.GetTextPath("RandName_Name");
                TextAsset textAsset1 = await resourcesLoaderComponent.LoadAssetAsync<TextAsset>(path_1);
                TextAsset textAsset2 = await resourcesLoaderComponent.LoadAssetAsync<TextAsset>(path_2);
                self.LoadWWW_Xing(textAsset1.text);
                self.LoadWWW_Name(textAsset2.text);
            }
        }

        private static void LoadWWW_Xing(this LanguageComponent self, string wwwStr)
        {
            wwwStr = wwwStr.Replace("\r", "");
            wwwStr = wwwStr.Replace("\n", "");

            //将读取到的字符串进行分割后存储到定义好的数组中
            self.randomName_xing = wwwStr.Split('@');

            self.ranNameNum += 1;
        }

        private static void LoadWWW_Name(this LanguageComponent self, string wwwStr)
        {
            wwwStr = wwwStr.Replace("\r", "");
            wwwStr = wwwStr.Replace("\n", "");

            //将读取到的字符串进行分割后存储到定义好的数组中
            self.randomName_name = wwwStr.Split('@');

            self.ranNameNum += 1;
        }

        public static string LoadLocalization(this LanguageComponent self, string getString)
        {
            return self.GetText(getString);
        }

        public static string GetText(this LanguageComponent self, string text)
        {
            //通过传进来的中文KEY 去数据表里面读对应替换的多语言文字
            if (self.Chinese)
            {
                return text;
            }

            if (self.MulLanguage.ContainsKey(text))
            {
                return self.MulLanguage[text];
            }

            List<MulLanguageConfig> configs = MulLanguageConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < configs.Count; i++)
            {
                if (configs[i].Chinese.Equals(text))
                {
                    self.MulLanguage.Add(text, configs[i].English);
                    return configs[i].English;
                }
            }

            return text;
        }

        // 本地化插件

        [EntitySystem]
        private static void Update(this LanguageComponent self)
        {
            if (InputHelper.GetKey((int)KeyCode.LeftAlt) && InputHelper.GetKeyDown((int)KeyCode.L) ||
                InputHelper.GetKeyDown((int)KeyCode.LeftAlt) && InputHelper.GetKey((int)KeyCode.L))
            {
                var languages = new List<string>
                {
                    LanguageType.Chinese,
                    LanguageType.English,
                    LanguageType.Japanese
                };

                int currentIndex = languages.IndexOf(self.CurrentLanguage);

                int nextIndex = (currentIndex + 1) % languages.Count;

                self.SetLanguage(languages[nextIndex], true);
            }
        }
        
        private static void OnInitL2Localization(this LanguageComponent self)
        {
            self.DefaultLanguage = PlayerPrefsHelp.GetString(PlayerPrefsHelp.Localization, LanguageType.Chinese);

            GameObject go = UnityEngine.Object.Instantiate(new GameObject());
            UnityEngine.Object.DontDestroyOnLoad(go);
            go.name = "[I2LocalizeMgr]";
            go.AddComponent<LanguageSource>();
            self.LanguageSource = go.GetComponent<LanguageSource>();

            if (Define.IsEditor)
            {
                if (!self.UseRuntimeModule)
                {
                    LocalizationManager.RegisterSourceInEditor();
                    self.UpdateAllLanguages();
                    self.SetLanguage(self.DefaultLanguage);
                }
                else
                {
                    self.LanguageSourceData.Awake();
                    self.LoadLanguage(self.DefaultLanguage, true).Coroutine();
                }
            }
            else
            {
                self.LanguageSourceData.Awake();
                self.LoadLanguage(self.DefaultLanguage, true).Coroutine();
            }
        }

        private static void UpdateAllLanguages(this LanguageComponent self)
        {
            self.AllLanguage.Clear();
            foreach (var language in LocalizationManager.GetAllLanguages())
            {
                var newLanguage = Regex.Replace(language, @"[\r\n]", "");
                self.AllLanguage.Add(newLanguage);
            }
        }

        public static bool CheckLanguage(this LanguageComponent self, string language)
        {
            return self.AllLanguage.Contains(language);
        }

        //运行时注意 需要提前加载你需要的所有语言
        public static bool SetLanguage(this LanguageComponent self, string language, bool load = false)
        {
            if (!self.CheckLanguage(language))
            {
                if (load)
                {
                    self.LoadLanguage(language, true).Coroutine();
                    return true;
                }

                Log.Error($"当前没有这个语言无法切换到此语言 {language}");
                return false;
            }

            if (self.CurrentLanguage == language)
            {
                return true;
            }

            Log.Debug($"设置当前语言 = {language}");
            LocalizationManager.CurrentLanguage = language;
            self.CurrentLanguage = language;
            return true;
        }

        //根据需求可提前加载语言
        public static async ETTask LoadLanguage(this LanguageComponent self, string language, bool setCurrent = false)
        {
            if (Define.IsEditor)
            {
                if (!self.UseRuntimeModule)
                {
                    Log.Error($"禁止在此模式下 动态加载语言 {language}");
                    return;
                }
            }

            if (self.CheckLanguage(language))
            {
                Log.Error($"当前语言已存在 请勿重复加载 {language}");
                return;
            }

            var assetName = self.GetLanguageAssetName(language);

            var assetTextAsset = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<TextAsset>(assetName);
            if (assetTextAsset == null)
            {
                Log.Error($"没有加载到目标语言资源 {language}");
                return;
            }

            Log.Debug($"加载语言成功 {language}");

            self.UseLocalizationCSV(assetTextAsset.text, !setCurrent);
            if (setCurrent)
            {
                self.SetLanguage(language);
            }

            //语言加载完毕后就可以释放资源了
            // YIUILoadHelper.Release(assetTextAsset);
        }

        private static string GetLanguageAssetName(this LanguageComponent self, string language)
        {
            return $"Assets/Bundles/Text/{I2LocalizeHelper.I2ResAssetNamePrefix}{language}.csv";
        }

        private static void UseLocalizationCSV(this LanguageComponent self, string text, bool isLocalizeAll = false)
        {
            self.LanguageSourceData.Import_CSV(string.Empty, text, eSpreadsheetUpdateMode.Replace, ',');
            if (isLocalizeAll)
            {
                LocalizationManager.LocalizeAll(); // 强制使用新数据本地化所有启用的标签/精灵
            }

            self.UpdateAllLanguages();
        }
    }
}