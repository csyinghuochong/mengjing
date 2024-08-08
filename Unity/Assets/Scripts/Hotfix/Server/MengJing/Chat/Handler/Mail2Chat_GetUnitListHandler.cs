using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [MessageHandler(SceneType.Chat)]
    public class Mail2Chat_GetUnitListHandler : MessageHandler<Scene, Mail2Chat_GetUnitList, Chat2Mail_GetUnitList>
    {
        protected override async ETTask Run(Scene scene, Mail2Chat_GetUnitList request, Chat2Mail_GetUnitList response)
        {
            ChatSceneComponent chatInfoUnitsComponent = scene.Root().GetComponent<ChatSceneComponent>();
            List<long> onlineunitids = chatInfoUnitsComponent.ChatInfoUnitsDict.Keys.ToList();
            response.OnlineUnitIdList = onlineunitids;

            await ETTask.CompletedTask;
        }
    }
}
