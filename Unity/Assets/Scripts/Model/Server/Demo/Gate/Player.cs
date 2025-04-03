namespace ET.Server
{

    public enum PlayerState
    {
        None,
        Disconnect,
        Gate,
        Game,
    }

    [ChildOf(typeof(PlayerComponent))]
    public sealed class Player : Entity, IAwake<string>
    {
        public string Account { get; set; }
        
        public long UnitId { get; set; }

        public PlayerState PlayerState { get; set; }
        
        public long ChatInfoInstanceId { get; set; }
        
        public ActorId ActivityServerId { get; set; }
        
        public ActorId FriendServerId { get; set; }
        
        public ActorId MailServerID { get; set; }
        
        public ActorId RankServerID { get; set; }
        
        public ActorId PaiMaiServerID { get; set; }
        
        public ActorId UnionServerID { get; set; }

        public ActorId SoloServerID { get; set; }
        
        public ActorId PetMatchServerID { get; set; }

        public ActorId PopularizeServerID { get; set; }
        
        public ActorId TeamServerID { get; set; }
        
        public string RemoteAddress  { get; set; }
    }
}