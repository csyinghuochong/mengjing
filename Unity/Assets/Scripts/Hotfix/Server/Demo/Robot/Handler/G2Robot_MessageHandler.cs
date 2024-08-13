
using System;

namespace ET.Server
{
    [MessageHandler(SceneType.RobotManager)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class G2Robot_MessageHandler : MessageHandler<Scene, G2Robot_MessageRequest>
    {
        protected override async ETTask Run(Scene scene, G2Robot_MessageRequest message)
        {
            Console.WriteLine($"G2Robot_MessageHandler:  {message}");
            
            
            await ETTask.CompletedTask;
        }
    }
}
