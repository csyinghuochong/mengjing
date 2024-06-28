namespace ET.Client
{
    
    [FriendOf(typeof (PlayerComponent))]
    public static class LoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password)
        {
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();

            await clientSenderCompnent.LoginAsync(account, password);
            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
        }
        
        public static async ETTask RequestCreateRole(Scene root, long accountId, int occ, string name)
        {
            Log.Debug("C2A_CreateRoleData.client0");
            
            C2G_CreateRoleData c2ACreateRoleData = new C2G_CreateRoleData() { AccountId = accountId, CreateOcc = occ, CreateName = name };
            G2C_CreateRoleData a2CCreateRoleData = await root.GetComponent<ClientSenderCompnent>().Call(c2ACreateRoleData) as G2C_CreateRoleData;
            root.GetComponent<PlayerComponent>().CreateRoleList.Add(a2CCreateRoleData.createRoleInfo);
        }

        public static async ETTask RequestDeleteRole(Scene root, long accountId, long userId, CreateRoleInfo createRoleInfo)
        {
            C2G_DeleteRoleData request = new() { AccountId = accountId, UserId = userId };
            G2C_DeleteRoleData response = await root.GetComponent<ClientSenderCompnent>().Call(request) as G2C_DeleteRoleData;
            root.GetComponent<PlayerComponent>().CreateRoleList.Remove(createRoleInfo);
        }

    }
}