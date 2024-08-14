using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GuideComponent : Entity, IAwake
    {
        public Dictionary<int, int> GuideInfoList = new();
        public Dictionary<int, EntityRef<GuideInfo>> GuideInfoDict = new();
    }
}