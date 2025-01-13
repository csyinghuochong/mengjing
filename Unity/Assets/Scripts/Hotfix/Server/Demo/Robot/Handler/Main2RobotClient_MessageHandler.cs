using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class Main2RobotClient_MessageHandler : MessageHandler<Scene, Main2RobotClient_Message, RobotClient2Main_Message>
    {
        protected override async ETTask Run(Scene root, Main2RobotClient_Message request, RobotClient2Main_Message response)
        {
            Console.WriteLine($"Main2RobotClient_Message: {request.Message}");
            root.GetComponent<BehaviourComponent>().Message = request.Message;
            
            await ETTask.CompletedTask;
        }

    }
}