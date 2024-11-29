namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetFightSwitchHandler : MessageHandler<Scene, M2C_PetFightSwitchMessage>
    {
        protected override async ETTask Run(Scene root, M2C_PetFightSwitchMessage message)
        {
            EventSystem.Instance.Publish(root.CurrentScene(), new PetFightSwitch() { Message = message });

            await ETTask.CompletedTask;
        }
    }
}