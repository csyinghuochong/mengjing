using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class HappySceneComponent: Entity, IAwake, IDestroy
    { 
        public bool HappyOpen = false;

        public  Dictionary<long, List<long>> FubenPlayers = new Dictionary<long, List<long>>(); 
    
    }
}
