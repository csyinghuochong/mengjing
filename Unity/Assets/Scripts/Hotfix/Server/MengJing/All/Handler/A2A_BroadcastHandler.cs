using System;

namespace ET.Server
{

    //服务器之间通用通信协议
    [MessageHandler(SceneType.All)]
    public class A2A_BroadcastHandler : MessageHandler<Scene, A2A_BroadcastRequest, A2A_BroadcastResponse>
    {

        protected override async ETTask Run(Scene scene, A2A_BroadcastRequest request, A2A_BroadcastResponse response)
        {
            try
            {
                switch (request.LoadType)
                {
                    case 1: //狩猎
                        ConfigData.ShowLieOpen = request.LoadValue == "1";
                        Console.WriteLine($" ConfigData.ShowLieOpen:  {ConfigData.ShowLieOpen}");
                        break;
                    case 2:  //世界等级
                        ConfigData.ServerInfo = request.ServerInfo;
                        Console.WriteLine($" ConfigData.ServerInfo:  {ConfigData.ServerInfo}");
                        break;
                }

                await ETTask.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Warning(ex.ToString());
            }
        }
    }
}