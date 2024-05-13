namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class UserInfoComponentC: Entity, IAwake
    {
        public UserInfo UserInfo { get; set; } = new UserInfo();

        public string[] PickSet{ get; set; } 
    }
}