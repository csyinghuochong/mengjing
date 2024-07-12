using System.Collections.Generic;

namespace ET.Client
{
    public static partial class ChengJiuData
    {
        [StaticField]
        public static List<string> ChengJiuTypeText = new() { "", "关卡成就", "探索成就", "收集成就" };

        [StaticField]
        public static Dictionary<int, string> ChapterIndexText = new()
        {
            { 0, "通用" },
            { 1, "第一章" },
            { 2, "第二章" },
            { 3, "第三章" },
            { 4, "第四章" },
            { 5, "第五章" },
            { 10, "组队副本" },
            { 11, "角色历练" },
            { 12, "积累成就" },
            { 21, "宠物成就" },
        };
    }
}