using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class TitleComponentC: Entity, IAwake
    {
        // 称号
        public List<KeyValuePairInt> TitleList { get; set; } = new();
    }
}