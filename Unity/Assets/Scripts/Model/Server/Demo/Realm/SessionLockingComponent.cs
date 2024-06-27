namespace ET.Server
{

    //空組件, 锁定本次会话
    [ComponentOf(typeof(Session))]
    public class SessionLockingComponent : Entity, IAwake
    {
    }
}