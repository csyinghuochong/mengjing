using System.Collections.Generic;

namespace ET.Client
{
    public static partial class UnionData
    {
        [StaticField]
        public static Dictionary<int, string> UnionPosition = new()
        {
            { 0, "会员" }, { 1, "会长" }, { 2, "副会长" }, { 3, "长老" },
        };
    }
}