using System.Collections.Generic;

namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class EffectViewComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        public List<Effect> Effects { get; set; } = new List<Effect>();
    }
}