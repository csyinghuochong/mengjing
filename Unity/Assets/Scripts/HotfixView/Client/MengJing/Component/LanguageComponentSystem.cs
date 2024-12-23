using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(LanguageComponent))]
    [EntitySystemOf(typeof(LanguageComponent))]
    public static partial class GameSettingLanguageSystem
    {
        [EntitySystem]
        private static void Awake(this LanguageComponent self)
        {
            LanguageComponent.Instance = self;
            self.OnInit().Coroutine();
            self.OnInitL2Localization().Coroutine();
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

        #region 本地化插件

        private static async ETTask OnInitL2Localization(this LanguageComponent self)
        {
            self.m_DefaultLanguage = PlayerPrefsHelp.GetString(PlayerPrefsHelp.Localization, "Chinese");
            GameObject go = UnityEngine.Object.Instantiate(new GameObject(), GlobalComponent.Instance.Global);
            go.name = "I2LocalizeMgr";
            go.AddComponent<LanguageSource>();
            self.m_LanguageSource = go.GetComponent<LanguageSource>();

#if UNITY_EDITOR
            if (!self.m_UseRuntimeModule)
            {
                LocalizationManager.RegisterSourceInEditor();
                self.UpdateAllLanguages();
                self.SetLanguage(self.m_DefaultLanguage);
            }
            else
            {
                self.m_SourceData.Awake();
                await self.LoadLanguage(self.m_DefaultLanguage, true);
            }
#else
                self.m_SourceData.Awake();
                await self.LoadLanguage(self.m_DefaultLanguage, true);
#endif
        }

        private static void UpdateAllLanguages(this LanguageComponent self)
        {
            self.m_AllLanguage.Clear();
            foreach (var language in LocalizationManager.GetAllLanguages())
            {
                var newLanguage = Regex.Replace(language, @"[\r\n]", "");
                self.m_AllLanguage.Add(newLanguage);
            }
        }

        public static bool CheckLanguage(this LanguageComponent self, string language)
        {
            return self.m_AllLanguage.Contains(language);
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

            if (self.m_CurrentLanguage == language)
            {
                return true;
            }

            Log.Debug($"设置当前语言 = {language}");
            LocalizationManager.CurrentLanguage = language;
            self.m_CurrentLanguage = language;
            return true;
        }

        //根据需求可提前加载语言
        public static async ETTask LoadLanguage(this LanguageComponent self, string language, bool setCurrent = false)
        {
#if UNITY_EDITOR
            if (!self.m_UseRuntimeModule)
            {
                Log.Error($"禁止在此模式下 动态加载语言 {language}");
                return;
            }
#endif

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
            self.m_SourceData.Import_CSV(string.Empty, text, eSpreadsheetUpdateMode.Replace, ',');
            if (isLocalizeAll)
            {
                LocalizationManager.LocalizeAll(); // 强制使用新数据本地化所有启用的标签/精灵
            }

            self.UpdateAllLanguages();
        }

        #endregion
    }
}