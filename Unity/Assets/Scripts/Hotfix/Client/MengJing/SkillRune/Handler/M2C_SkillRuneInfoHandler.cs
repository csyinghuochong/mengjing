namespace ET.Client
{
    /// <summary>
    /// 技能符文数据变更：GM 加符文这类不是客户端自己发起的变化，由服务端主动下发
    /// </summary>
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillRuneInfoHandler : MessageHandler<Scene, M2C_SkillRuneInfoMessage>
    {
        protected override async ETTask Run(Scene root, M2C_SkillRuneInfoMessage message)
        {
            root.GetComponent<SkillRuneComponentC>().UpdateInfo(message.RuneList, message.SlotList);

            //通知界面按最新数据刷新
            EventSystem.Instance.Publish(root, new SkillRuneUpdate());
            await ETTask.CompletedTask;
        }
    }
}
