using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class RobotManagerComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<int,KeyValuePair> robots = new();

        public Dictionary<long, long> TeamRobot { get; set; } = new Dictionary<long, long>();
    }
}