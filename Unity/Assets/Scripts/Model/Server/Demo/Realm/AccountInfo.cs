namespace ET.Server
{

    [ChildOf(typeof(AccountInfoComponent))]
    public class AccountInfo : Entity
    { 
        public string Account { get; set; }
    }

}