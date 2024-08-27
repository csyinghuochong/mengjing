using System;
using System.Net;
using System.Net.Sockets;
using ET.Server;

namespace ET.Client
{
    [MessageHandler(SceneType.RobotManager)]
    public class Main2RobotManager_MessageHandler : MessageHandler<Scene, Main2RobotManager_Message, RobotManager2Main_Message>
    {
        protected override async ETTask Run(Scene root, Main2RobotManager_Message request, RobotManager2Main_Message response)
        {
            switch (request.OpType)
            {
                case 1:
                    
                    Console.WriteLine("Main2RobotManager_Message.RemoveRobot");
                    root.GetComponent<RobotManagerComponent>().RemoveRobot(int.Parse(request.OpParam)).Coroutine();
                    break;
                default:
                    break;
            }

            await ETTask.CompletedTask;
        }

    }
}