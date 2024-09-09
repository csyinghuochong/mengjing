namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_MailUpdateHandler : MessageHandler<Scene, M2C_UpdateMailInfo>
    {
        protected override async ETTask Run(Scene root, M2C_UpdateMailInfo message)
        {
            root.GetComponent<ReddotComponentC>().AddReddont(ReddotType.Email);

            await ETTask.CompletedTask;
        }
    }
}