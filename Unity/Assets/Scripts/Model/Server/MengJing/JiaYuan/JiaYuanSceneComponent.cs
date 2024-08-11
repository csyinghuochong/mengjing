using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class JiaYuanSceneComponent: Entity,IAwake,IDestroy
    {
        public Dictionary<long, ActorId> JiaYuanFubens = new Dictionary<long, ActorId>();
    }
    
}