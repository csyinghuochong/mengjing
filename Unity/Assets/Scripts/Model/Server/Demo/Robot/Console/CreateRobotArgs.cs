using CommandLine;

namespace ET.Server
{
    public class CreateRobotArgs: Object
    {
        [Option("Num", Required = false, Default = 1)]
        public int Num { get; set; }
        
        [Option("RobotId", Required = false, Default = 1000)]
        public int RobotId { get; set; }
    }
}