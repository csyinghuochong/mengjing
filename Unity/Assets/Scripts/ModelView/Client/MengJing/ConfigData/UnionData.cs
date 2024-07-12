using System.Collections.Generic;

namespace ET.Client
{
    public static partial class UnionData
    {
        [StaticField]
        public static Dictionary<int, string> UnionPosition = new()
        {
            { 0, "族员" }, { 1, "族长" }, { 2, "副族长" }, { 3, "长老" },
        };
    }
}