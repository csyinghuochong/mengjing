namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class UserInfoComponentC: Entity, IAwake
    {
        public UserInfo UserInfo = new();
    }
}