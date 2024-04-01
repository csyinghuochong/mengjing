namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class EffectViewComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        
    }
    
}