using System.Collections.Generic;
using System.Numerics;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FallingFontComponent : Entity, IAwake, IDestroy
    {
        public long Timer;
        public List<EntityRef<FallingFontShowComponent>> FallingFontShows = new();
        public List<EntityRef<FallingFontShow1Component>> FallingFontShow1s = new();
    }
}