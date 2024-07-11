namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class UserInfoComponentC: Entity, IAwake
    {
        public UserInfo UserInfo { get; set; } 

        public string[] PickSet{ get; set; } 
    }
}