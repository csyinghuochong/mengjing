namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class UserInfoComponentClient: Entity, IAwake
    {
        public UserInfo UserInfo = new();
    }
}