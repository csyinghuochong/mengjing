using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof(Player))]
    public class A2G_GetOnLineUnitHandler : MessageHandler<Scene, A2G_GetOnLineUnit, G2A_GetOnLineUnit>
    {
        protected override async ETTask Run(Scene scene, A2G_GetOnLineUnit request, G2A_GetOnLineUnit response)
        {
            EntityRef<Player>[] players = scene.GetComponent<PlayerComponent>().GetAll();

            for (int i = 0; i < players.Length; i++)
            {
                Player player = players[i];
                if (player.PlayerState != PlayerState.Game)
                {
                    continue;
                }
                
                if (player.GetComponent<PlayerOfflineOutTimeComponent>() == null)
                {
                    response.OnLineUnits.Add(player.UnitId);
                }
            }
            await ETTask.CompletedTask;
        }
    }
}