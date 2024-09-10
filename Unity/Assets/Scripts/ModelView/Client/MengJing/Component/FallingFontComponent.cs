using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FallingFontComponent : Entity, IAwake, IDestroy
    {
        public long Timer;
        public List<EntityRef<FallingFontShowComponent>> FallingFontShows = new();
        
        public int BatchSize = 50; // 每帧处理的任务数
        public int Index = -1;
    }
}