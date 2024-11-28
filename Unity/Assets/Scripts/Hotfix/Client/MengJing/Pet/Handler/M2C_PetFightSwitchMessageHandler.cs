

namespace ET.Client
{
    [FriendOf(typeof (PetComponentC))]
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetFightSwitchMessageHandler: MessageHandler<Scene, M2C_PetFightSwitchMessage>
    {
        protected override async ETTask Run(Scene root, M2C_PetFightSwitchMessage message)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
           
            await ETTask.CompletedTask;
        }
    }
}