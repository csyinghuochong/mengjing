namespace ET.Client
{
    public static class LoginHelper
    {
        public static async ETTask Login(Scene root, string account, string password)
        {
            root.RemoveComponent<ClientSenderCompnent>();
            ClientSenderCompnent clientSenderCompnent = root.AddComponent<ClientSenderCompnent>();

            await clientSenderCompnent.LoginAsync(account, password);
            await EventSystem.Instance.PublishAsync(root, new LoginFinish());
        }
    }
}