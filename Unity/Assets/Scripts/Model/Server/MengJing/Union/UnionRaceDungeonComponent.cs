using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class UnionRaceDungeonComponent: Entity, IAwake
    {
        public Dictionary<long, List<long>> UnionRaceUnits = new Dictionary<long, List<long>>();

    }
    
}