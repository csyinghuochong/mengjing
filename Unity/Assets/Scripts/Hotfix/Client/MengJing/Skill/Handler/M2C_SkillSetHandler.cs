namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillSetHandler: MessageHandler<Scene, M2C_SkillSetMessage>
    {
        protected override async ETTask Run(Scene root, M2C_SkillSetMessage message)
        {
            root.GetComponent<SkillSetComponentC>().UpdateSkillSet(message.SkillSetInfo);
            EventSystem.Instance.Publish(root, new SkillSetting());
            await ETTask.CompletedTask;
        }
    }
}