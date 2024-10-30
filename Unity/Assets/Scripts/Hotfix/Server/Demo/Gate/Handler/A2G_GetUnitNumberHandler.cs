using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof(Player))]
    public class A2G_GetUnitNumberHandler : MessageHandler<Scene, A2G_GetUnitNumber, G2A_GetUnitNumber>
    {
        protected override async ETTask Run(Scene scene, A2G_GetUnitNumber request, G2A_GetUnitNumber response)
        {
            EntityRef<Player>[] players = scene.GetComponent<PlayerComponent>().GetAll();

            for (int i = 0; i < players.Length; i++)
            {
                Player player = players[i];
                //PlayerSessionComponent
                //GateMapComponent
                if (player.PlayerState != PlayerState.Game)
                {
                    continue;
                }
                
                if (player.GetComponent<PlayerOfflineOutTimeComponent>() != null)
                {
                    continue;
                }

                if(player.RemoteAddress.Contains("127.0.0.1")
                   || player.RemoteAddress.Contains("47.94.107.92")
                   || player.RemoteAddress.Contains("39.96.194.143"))
                {
                    response.OnLineRobot++;
                }
                else
                {
                    response.OnLinePlayer++;
                }
            }
            await ETTask.CompletedTask;
        }
    }
}