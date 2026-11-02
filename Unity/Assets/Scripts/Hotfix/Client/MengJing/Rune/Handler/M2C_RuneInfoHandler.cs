namespace ET.Client
{
    /// <summary>
    /// 符文数据变更：GM 加符文这类不是客户端自己发起的变化，由服务端主动下发
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    public class M2C_RuneInfoHandler : MessageHandler<Scene, M2C_RuneInfoMessage>
    {
        protected override async ETTask Run(Scene root, M2C_RuneInfoMessage message)
        {
            root.GetComponent<RuneComponentC>().UpdateRuneInfo(message.Info);
            await ETTask.CompletedTask;
        }
    }
}
