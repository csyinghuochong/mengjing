using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class UnionSceneComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        
        public DBUnionManager DBUnionManager { get; set; } = new DBUnionManager();

    }
    
}
