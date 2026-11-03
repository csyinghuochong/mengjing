using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 技能增幅配置查询。增幅选项直接由 SkillAugmentConfig 按 BaseSkillId + Level 分组，
    /// 不再需要单独的 SkillAugmentOptionsConfig。
    /// </summary>
    public static class SkillAugmentHelper
    {
        /// <summary>
        /// 取某个基础技能在指定解锁等级（2 级或 3 级）下的全部增幅选项，按 Id 升序排列。
        /// </summary>
        public static List<SkillAugmentConfig> GetAugments(int baseSkillId, int level)
        {
            List<SkillAugmentConfig> result = new List<SkillAugmentConfig>();
            List<SkillAugmentConfig> configs = SkillAugmentConfigCategory.Instance.DataList;
            for (int i = 0; i < configs.Count; i++)
            {
                SkillAugmentConfig config = configs[i];
                if (config.BaseSkillId == baseSkillId && config.Level == level)
                {
                    result.Add(config);
                }
            }

            result.Sort((a, b) => a.Id.CompareTo(b.Id));
            return result;
        }

        /// <summary>
        /// 取某个基础技能在指定解锁等级下的增幅 Id 数组，供轮盘按顺序摆放。
        /// </summary>
        public static int[] GetAugmentIds(int baseSkillId, int level)
        {
            List<SkillAugmentConfig> configs = GetAugments(baseSkillId, level);
            int[] ids = new int[configs.Count];
            for (int i = 0; i < configs.Count; i++)
            {
                ids[i] = configs[i].Id;
            }

            return ids;
        }

        /// <summary>
        /// 取某个基础技能在指定解锁等级下当前已选中的增幅 Id，没有返回 0。
        /// </summary>
        public static int GetSelectedAugmentId(List<int> augmentIds, int baseSkillId, int level)
        {
            if (augmentIds == null)
            {
                return 0;
            }

            for (int i = 0; i < augmentIds.Count; i++)
            {
                SkillAugmentConfig config = SkillAugmentConfigCategory.Instance.GetOrDefault(augmentIds[i]);
                if (config != null && config.BaseSkillId == baseSkillId && config.Level == level)
                {
                    return config.Id;
                }
            }

            return 0;
        }

        /// <summary>
        /// 该基础技能是否配置了任意等级的增幅选项。
        /// </summary>
        public static bool HasAugment(int baseSkillId)
        {
            List<SkillAugmentConfig> configs = SkillAugmentConfigCategory.Instance.DataList;
            for (int i = 0; i < configs.Count; i++)
            {
                if (configs[i].BaseSkillId == baseSkillId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
