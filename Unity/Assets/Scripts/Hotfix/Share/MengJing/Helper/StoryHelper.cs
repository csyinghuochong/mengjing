using System.Collections.Generic;

namespace ET
{
    public static class StoryHelper
    {
        /// <summary>
        /// 累计所有剧情选择带来的属性值
        /// </summary>
        public static void GetStoryValues(List<StoryInfo> storyInfoList, out int affinity, out int fun, out int violence)
        {
            affinity = 0;
            fun = 0;
            violence = 0;

            if (storyInfoList == null)
            {
                return;
            }

            for (int i = 0; i < storyInfoList.Count; i++)
            {
                StoryChoiceConfig choiceConfig = StoryChoiceConfigCategory.Instance.GetOrDefault(storyInfoList[i].ChoiceId);
                if (choiceConfig == null)
                {
                    continue;
                }

                affinity += choiceConfig.Affinity;
                fun += choiceConfig.Fun;
                violence += choiceConfig.Violence;
            }
        }

        /// <summary>
        /// 所有剧情是否都已完成选择
        /// </summary>
        public static bool IsAllStoryChosen(List<StoryInfo> storyInfoList)
        {
            List<StoryConfig> storyConfigs = StoryConfigCategory.Instance.DataList;
            if (storyConfigs.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < storyConfigs.Count; i++)
            {
                if (!ContainsStory(storyInfoList, storyConfigs[i].Id))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ContainsStory(List<StoryInfo> storyInfoList, int storyId)
        {
            if (storyInfoList == null)
            {
                return false;
            }

            for (int i = 0; i < storyInfoList.Count; i++)
            {
                if (storyInfoList[i].StroryId == storyId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 按当前属性值匹配结局
        /// </summary>
        public static StoryEndingConfig GetStoryEndingConfig(int affinity, int fun, int violence)
        {
            List<StoryEndingConfig> endingConfigs = StoryEndingConfigCategory.Instance.DataList;
            for (int i = 0; i < endingConfigs.Count; i++)
            {
                StoryEndingConfig config = endingConfigs[i];
                if (affinity < config.AffinityMin || affinity > config.AffinityMax)
                {
                    continue;
                }
                if (fun < config.FunMin || fun > config.FunMax)
                {
                    continue;
                }
                if (violence < config.ViolenceMin || violence > config.ViolenceMax)
                {
                    continue;
                }

                return config;
            }

            return endingConfigs.Count > 0 ? endingConfigs[endingConfigs.Count - 1] : null;
        }
    }
}
