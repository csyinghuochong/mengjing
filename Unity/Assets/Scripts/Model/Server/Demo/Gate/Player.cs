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

        public long AccountId { get; set; }

        public long UnitId { get; set; }

        public PlayerState PlayerState { get; set; }

        public Session ClientSession { get; set; }

        public long ChatInfoInstanceId { get; set; }
        
        public ActorId ActivityServerId { get; set; }
        
        public ActorId FriendServerId { get; set; }
        
        public ActorId MailServerID { get; set; }
    }
}