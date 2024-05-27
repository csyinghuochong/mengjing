using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class TeamSceneComponent : Entity, IAwake
    {
        public List<TeamInfo> TeamList { get; set; } = new List<TeamInfo>();

        public M2C_TeamUpdateResult m2C_TeamUpdateResult = new M2C_TeamUpdateResult();  

        public T2M_TeamUpdateRequest t2M_TeamUpdateRequest = new T2M_TeamUpdateRequest();

        public M2C_TeamDungeonQuitMessage M2C_TeamDungeonQuitMessage = new M2C_TeamDungeonQuitMessage();
    }
    
}

