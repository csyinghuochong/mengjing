namespace ET.Client
{
    /// <summary>
    /// 宝石天赋数据变更：装备变动、镶嵌或卸下宝石后由服务端主动下发
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    public class M2C_GemTalentHandler : MessageHandler<Scene, M2C_GemTalentMessage>
    {
        protected override async ETTask Run(Scene root, M2C_GemTalentMessage message)
        {
            root.GetComponent<GemTalentComponentC>().UpdateGemTalentInfo(message.Info);
            await ETTask.CompletedTask;
        }
    }
}
