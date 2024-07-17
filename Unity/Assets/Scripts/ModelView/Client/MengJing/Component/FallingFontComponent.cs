using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FallingFontComponent : Entity, IAwake, IDestroy
    {
        public long Timer;
        public List<EntityRef<FallingFontShowComponent>> FallingFontShows = new();
    }
}