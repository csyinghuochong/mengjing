using System;

namespace ET.Server
{

    //服务器之间通用通信协议
    [MessageHandler(SceneType.All)]
    public class A2A_BroadcastProcessHandler : MessageHandler<Scene, A2A_BroadcastProcessRequest, A2A_BroadcastProcessResponse>
    {

        protected override async ETTask Run(Scene scene, A2A_BroadcastProcessRequest request, A2A_BroadcastProcessResponse response)
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
                        int zone = int.Parse(request.LoadValue);
                        ConfigData.ServerInfoList[zone] = request.ServerInfo;
                        Console.WriteLine($" ConfigData.ServerInfo: ");
                        break;
                    case 3: //热重载
                        string[] ss = request.LoadValue.Split(" ");
                        int loadType = int.Parse(ss[1]);
                        string LoadValue = ss[2];
                        CodeLoader.Instance.Reload();
                        await World.Instance.AddSingleton<ConfigLoader>().LoadAsync();  //耗时8s
                        Console.WriteLine($" CodeLoader.Instance.Reload ");
                        break;
                    default:
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