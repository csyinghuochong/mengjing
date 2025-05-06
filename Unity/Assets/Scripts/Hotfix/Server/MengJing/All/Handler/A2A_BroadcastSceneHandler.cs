using System;

namespace ET.Server
{

    //服务器之间通用通信协议
    [MessageHandler(SceneType.All)]
    public class A2A_BroadcastSceneHandler : MessageHandler<Scene, A2A_BroadcastSceneRequest, A2A_BroadcastSceneResponse>
    {

        protected override async ETTask Run(Scene scene, A2A_BroadcastSceneRequest request, A2A_BroadcastSceneResponse response)
        {
            try
            {
                string sceneName = scene.Root().Name;
                Console.WriteLine($"A2A_BroadcastSceneRequest.kickout: {request.UnitId} {sceneName}");
                if (sceneName.Equals("Map101") ||sceneName.Equals("Union")
                    ||sceneName.Equals("FubenCenter1") ||sceneName.Equals("Team") 
                    ||sceneName.Equals("PetMatch") )
                {
                    ///暂时写在这 没想到好的解决方案。
                    scene.GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Remove(request.UnitId);
                    scene.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Remove(request.UnitId);
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