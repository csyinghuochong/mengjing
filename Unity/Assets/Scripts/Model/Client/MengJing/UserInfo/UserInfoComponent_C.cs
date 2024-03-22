namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class UserInfoComponent_C: Entity, IAwake
    {
        public UserInfo UserInfo = new();
    }
}