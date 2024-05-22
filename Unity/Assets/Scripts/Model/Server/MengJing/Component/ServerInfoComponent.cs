namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    
    public class ServerInfoComponent: Entity, IAwake
    {
        public ServerInfo ServerInfo { get; set; }
    }
}
