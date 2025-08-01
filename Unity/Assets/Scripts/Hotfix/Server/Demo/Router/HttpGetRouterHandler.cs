using System;
using System.Net;

namespace ET.Server
{
    [HttpHandler(SceneType.RouterManager, "/get_router")]
    public class HttpGetRouterHandler : IHttpHandler
    {
        public async ETTask Handle(Scene scene, HttpListenerContext context)
        {
            Console.WriteLine("HttpGetRouterHandler");
            HttpGetRouterResponse response = new();
            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Realms)
            {
                response.Realms.Add(startSceneConfig.InnerIPPort.ToString());
            }
            foreach (StartSceneConfig startSceneConfig in StartSceneConfigCategory.Instance.Routers)
            {
                response.Routers.Add($"{startSceneConfig.StartProcessConfig.OuterIP}:{startSceneConfig.Port}");
            }
            HttpHelper2.Response(context, response);
            await ETTask.CompletedTask;
        }
    }
}
