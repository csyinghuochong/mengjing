using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof(Player))]
    public class A2G_GetOnLineUnitHandler : MessageHandler<Scene, A2G_GetOnLineUnit, G2A_GetOnLineUnit>
    {
        protected override async ETTask Run(Scene scene, A2G_GetOnLineUnit request, G2A_GetOnLineUnit response)
        {
            response.OnLineUnits = new List<long>();
            await ETTask.CompletedTask;
        }
    }
}