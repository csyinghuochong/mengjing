
namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TurtleRewardHandler: MessageHandler<Scene, M2C_TurtleRewardMessage>
    {
        protected override async ETTask Run(Scene root, M2C_TurtleRewardMessage message)
        {
           
            await ETTask.CompletedTask;
        }
    }
}