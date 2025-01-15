using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class TeamSceneComponent : Entity, IAwake
    {
        public List<TeamInfo> TeamList { get; set; } = new List<TeamInfo>();
        
    }
    
}

