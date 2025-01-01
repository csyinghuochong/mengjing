
namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [MessageHandler(SceneType.Demo)]
    public class M2C_UpdateUserInfoHandler : MessageHandler<Scene, M2C_UpdateUserInfoMessage>
    {
        protected override async ETTask Run(Scene root, M2C_UpdateUserInfoMessage message)
        {
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().AddChild<UserInfo>();
            userInfo.FromMessage(message.UserInfo);
            
            root.GetComponent<UserInfoComponentC>().UserInfo = userInfo;
            userInfo.Dispose();
            await ETTask.CompletedTask;
        }
    }
}