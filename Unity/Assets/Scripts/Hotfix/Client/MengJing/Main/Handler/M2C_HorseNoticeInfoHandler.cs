namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_HorseNoticeInfoHandler: MessageHandler<Scene, M2C_HorseNoticeInfo>
    {
        protected override async ETTask Run(Scene root, M2C_HorseNoticeInfo message)
        {
            EventSystem.Instance.Publish(root, new HorseNotice() { M2C_HorseNoticeInfo = message });
            await ETTask.CompletedTask;
        }
    }
}