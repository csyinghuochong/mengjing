namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_ZeroClockHandler: MessageHandler<Scene, M2C_ZeroClock>
    {
        protected override async ETTask Run(Scene root, M2C_ZeroClock message)
        {
            root.GetComponent<UserInfoComponentC>().ClearDayData();
            root.GetComponent<TaskComponentC>().OnZeroClockUpdate();
            root.GetComponent<ActivityComponentC>().OnZeroClockUpdate();
            
            EventSystem.Instance.Publish(root, new ZeroClock()  { });

            await ETTask.CompletedTask;
        }
    }
}