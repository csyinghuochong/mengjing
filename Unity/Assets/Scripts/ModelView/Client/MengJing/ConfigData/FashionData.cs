using System.Collections.Generic;

namespace ET.Client
{
    public static partial class FashionData
    {
        //1001  头饰
        //1002  脸
        //1003  眼睛
        //1004  眉毛
        //2001  披风
        //2002  上衣
        //3001  下衣
        //3002  鞋子
        /// <summary>
        /// 默认配置
        /// </summary>
        //战士
        [StaticField]
        public static Dictionary<int, List<string>> FashionBaseTemplate_1 = new()
        {
            { 1002, new List<string>() { "Hero_lian" } },
            { 1004, new List<string>() { "Hero_meimao" } },
            { 2001, new List<string>() { "Hero_pifeng" } },
            { 2002, new List<string>() { "Hero_shangyi" } },
            { 2003, new List<string>() { "Hero_fashi" } },
            { 1001, new List<string>() { "Hero_toufa" } },
            { 3001, new List<string>() { "Hero_xiashen" } },
            { 3002, new List<string>() { "Hero_xiezi" } },
            { 1003, new List<string>() { "Hero_yanjing" } },
        };

        //法师
        [StaticField]
        public static Dictionary<int, List<string>> FashionBaseTemplate_2 = new()
        {
            { 1002, new List<string>() { "Hero_lian" } },
            { 1004, new List<string>() { "Hero_meimao" } },
            { 2001, new List<string>() { "Hero_pifeng" } },
            //{ 2002,     new List<string>(){"Hero_shangyi", "Hero_pifu1" } },
            { 2002, new List<string>() { "Hero_shangyi", "Hero_pifu1" } },
            { 2003, new List<string>() { "Hero_fashi", "fashi_fashi2" } },
            { 1001, new List<string>() { "Hero_toufa" } },
            { 3001, new List<string>() { "Hero_xiashen", "Hero_pifu2" } },
            { 3002, new List<string>() { "Hero_xiezi" } },
            { 1003, new List<string>() { "Hero_yanjing" } },
        };

        //猎人
        [StaticField]
        public static Dictionary<int, List<string>> FashionBaseTemplate_3 = new()
        {
            { 1002, new List<string>() { "Hero_lian" } },
            { 1004, new List<string>() { "Hero_meimao" } },
            { 2001, new List<string>() { "Hero_pifeng" } },
            { 2002, new List<string>() { "Hero_shangyi", "Hero_weijin" } },
            { 2003, new List<string>() { "Hero_fashi" } },
            { 1001, new List<string>() { "Hero_toufa" } },
            { 3001, new List<string>() { "Hero_xiashen" } },
            { 3002, new List<string>() { "Hero_xiezi" } },
            { 1003, new List<string>() { "Hero_yanjing" } },
        };
    }
}