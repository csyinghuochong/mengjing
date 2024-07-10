using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Server
{
    public static class DisconnectHelper
    {
        public static async ETTask Disconnect(this Session self)
        {
            if (self == null || self.IsDisposed)
            {
                return;
            }

            long instanceId = self.InstanceId;

            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);

            if (self.InstanceId != instanceId)
            {
                return;
            }

            self.Dispose();
        }

        public static async ETTask KickPlayerNoLock(Player player)
        { 
            Console.WriteLine("KickPlayerNoLock");
            if (player == null || player.IsDisposed)
            {
                return;
            }
    
            switch (player.PlayerState)
            {
                case PlayerState.Disconnect:
                    break;
                case PlayerState.Gate:
                    break;
                case PlayerState.Game:
                    Console.WriteLine("G2M_RequestExitGame");
                    //通知游戏逻辑服下线Unit角色逻辑，并将数据存入数据库
                    var m2GRequestExitGame = (M2G_RequestExitGame)await player.Root().GetComponent<MessageLocationSenderComponent>()
                            .Get(LocationType.Unit).Call(player.UnitId, G2M_RequestExitGame.Create());

                    //通知移除账号角色登录信息
                    G2L_RemoveLoginRecord g2LRemoveLoginRecord = G2L_RemoveLoginRecord.Create();
                    g2LRemoveLoginRecord.AccountName = player.Account;
                    g2LRemoveLoginRecord.ServerId = player.Zone();
                    var L2G_RemoveLoginRecord = (L2G_RemoveLoginRecord) await player.Root().GetComponent<MessageSender>()
                            .Call(StartSceneConfigCategory.Instance.LoginCenterConfig.ActorId, g2LRemoveLoginRecord);
                    break;
            }
    
            TimerComponent timerComponent = player.Root().GetComponent<TimerComponent>();
            player.PlayerState = PlayerState.Disconnect;

            await player.GetComponent<PlayerSessionComponent>().RemoveLocation(LocationType.GateSession);
            await player.RemoveLocation(LocationType.Player);
            player.Root().GetComponent<PlayerComponent>()?.Remove(player);
            player?.Dispose();
    
            await timerComponent.WaitAsync(300);
        }
        
        public static async ETTask KickPlayer(Player player, bool isException = false)
        {
            Console.WriteLine("KickPlayer");
            if (player == null || player.IsDisposed)
            {
                return;
            }
            long instanceId = player.InstanceId;

            CoroutineLockComponent coroutineLockComponent = player.Root().GetComponent<CoroutineLockComponent>();

            using (await coroutineLockComponent.Wait(CoroutineLockType.LoginGate, player.Account.GetLongHashCode()))
            {
                if (player.IsDisposed || instanceId != player.InstanceId)
                {
                    return;
                }
                await KickPlayerNoLock(player);
            }
        }

        public static async ETTask KickPlayer(int zone, long unitid)
        {
            Log.Info("KickPlayer_2");
            // long fubencenterId = DBHelper.GetFubenCenterId(zone);
            // M2F_FubenCenterListRequest request = new M2F_FubenCenterListRequest() { };
            // F2M_FubenCenterListResponse response = (F2M_FubenCenterListResponse)await ActorMessageSenderComponent.Instance.Call(fubencenterId, request);
            //
            // List<long> mapIdList = new List<long>()
            // {
            //     StartSceneConfigCategory.Instance.GetBySceneName(zone, $"Map{ComHelp.MainCityID()}").InstanceId
            // };
            // mapIdList.AddRange(response.FubenInstanceList);
            //
            // for (int i = mapIdList.Count - 1; i >= 0; i--)
            // {
            //     ActorMessageSenderComponent.Instance.Send(mapIdList[i], new G2M_KickPlayerRequest() { UnitId = unitid });
            // }
            await ETTask.CompletedTask;
        }
    }
}