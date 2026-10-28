using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 附加效果(TalentConfig / LongYinConfig 的 AddPropreList)的通用读取方法
    /// </summary>
    public static class PropEffectHelper
    {
        /// <summary>
        /// 取第 level 级(从1开始)的效果列表，越界返回空列表
        /// </summary>
        public static List<PropEffect> GetLevelEffects(this List<List<PropEffect>> addPropreList, int level)
        {
            if (addPropreList == null || level <= 0 || level > addPropreList.Count)
            {
                return new List<PropEffect>();
            }

            return addPropreList[level - 1];
        }

        /// <summary>
        /// 把一条角色属性效果换算成 PropertyValue：整数属性取原值，百分比属性放大10000倍。
        /// 这里保留先转 float 再截断的旧算法，避免导表结构变化顺手改掉数值表现。
        /// </summary>
        public static PropertyValue ToPropertyValue(this RolePropertyAdd effect)
        {
            long value = NumericHelp.GetNumericValueType(effect.NumericKey) == 1
                    ? (long)effect.Value
                    : (int)((float)effect.Value * 10000);
            return new PropertyValue() { HideID = effect.NumericKey, HideValue = value };
        }

        /// <summary>
        /// 收集一批效果里的角色属性，供 Function_Fight 计算属性时使用
        /// </summary>
        public static List<PropertyValue> CollectRoleProperties(List<PropEffect> effects)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            if (effects == null)
            {
                return proList;
            }

            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i] is RolePropertyAdd rolePropertyAdd)
                {
                    proList.Add(rolePropertyAdd.ToPropertyValue());
                }
            }

            return proList;
        }

        /// <summary>
        /// 往字典里累加数值，key 已存在则叠加
        /// </summary>
        public static void AddOrMerge(Dictionary<int, float> dict, int key, float value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] += value;
                return;
            }

            dict.Add(key, value);
        }
    }
}
