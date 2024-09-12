using System.Collections.Generic;

namespace ET.Client
{
    public static partial class SkillData
    {
        [StaticField]
        public static Dictionary<string, long> AckExitTime = new()
        {
            { "Act_1", 700 },
            { "Act_2", 1100 },
            { "Act_3", 1100 },
            { "Act_11", 900 },
            { "Act_12", 900 },
            { "Act_13", 900 }
        };

        [StaticField]
        public static Dictionary<int, (string, string)> BuffFallingFont = new()
        {
            { 100912, ("加速", "减速") },
            { 100612, ("物防增加", "物防减低") },
            { 1, (string.Empty, string.Empty) }
        };
    }
}