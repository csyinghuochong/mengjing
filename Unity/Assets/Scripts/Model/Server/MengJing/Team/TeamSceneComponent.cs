using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class TeamSceneComponent : Entity, IAwake
    {
        public List<TeamInfo> TeamList { get; set; } = new List<TeamInfo>();

        public M2C_TeamUpdateResult m2C_TeamUpdateResult = M2C_TeamUpdateResult.Create();

        public T2M_TeamUpdateRequest t2M_TeamUpdateRequest = T2M_TeamUpdateRequest.Create();

        public M2C_TeamPlayerQuitDungeon m2C_TeamPlayerQuitDungeon = M2C_TeamPlayerQuitDungeon.Create();
    }
    
}

