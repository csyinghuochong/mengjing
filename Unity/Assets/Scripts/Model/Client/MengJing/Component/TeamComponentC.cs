using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class TeamComponentC: Entity, IAwake
    {
        public int FubenType { get; set; }

        public List<TeamInfo> TeamList { get; set; } = new();

        public List<TeamPlayerInfo> ApplyList { get; set; } = new();
    }
}