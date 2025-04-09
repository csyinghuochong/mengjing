using System;
using System.Collections.Generic;

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

        public static async ETTask  KickPlayerNoLock(Player player, int ftype)
        { 
            if (player == null || player.IsDisposed)
            {
                return;
            }
            Console.WriteLine($"KickPlayerNoLock:  {player.Id}  {ftype}");
            switch (player.PlayerState)
            {
                case PlayerState.Disconnect:
                    break;
                case PlayerState.Gate:
                    break;
                case PlayerState.Game:
                    //通知游戏逻辑服下线Unit角色逻辑，并将数据存入数据库
                    var m2GRequestExitGame = (M2G_RequestExitGame)await player.Root().GetComponent<MessageLocationSenderComponent>()
                            .Get(LocationType.Unit).Call(player.UnitId, G2M_RequestExitGame.Create());
                    
                    //通知组队服
                    await BroadCastHelper.SendServerMessage(player.Root(), UnitCacheHelper.GetTeamServerId(player.Zone()) , NoticeType.PlayerExit, player.UnitId.ToString());
                    
                    //通知Solo服
                    //await BroadCastHelper.SendServerMessage(player.SoloServerID, NoticeType.PlayerExit, player.UnitId.ToString());
                    
                    //通知移除账号角色登录信息
                    G2L_RemoveLoginRecord g2LRemoveLoginRecord = G2L_RemoveLoginRecord.Create();
                    g2LRemoveLoginRecord.AccountName = player.Account;
                    g2LRemoveLoginRecord.ServerId = player.Zone();
                    var L2G_RemoveLoginRecord = (L2G_RemoveLoginRecord) await player.Root().GetComponent<MessageSender>()
                            .Call(StartSceneConfigCategory.Instance.LoginCenterConfig.ActorId, g2LRemoveLoginRecord);
                    
                    await ExitWorldChatServer(player.Scene(), player.ChatInfoInstanceId);
                    await ExitOtherServer(  player.Scene(), player.UnitId);

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

        public static async ETTask ExitOtherServer(Scene root,  long chatUnitId)
        {
            A2A_BroadcastSceneRequest broadcastSceneRequest = A2A_BroadcastSceneRequest.Create();
            broadcastSceneRequest.UnitId = chatUnitId;
            List<StartSceneConfig> otherscenes = BroadCastHelper.GetAllScene(root.Zone());
            
            for (int i = 0; i < otherscenes.Count; i++)
            {
                await root.GetComponent<MessageSender>().Call(otherscenes[i].ActorId, broadcastSceneRequest);
            }
        }

        private static async ETTask<long> ExitWorldChatServer(Scene root,  long chatUnitId)
        {
            G2Chat_RequestExitChat g2ChatEnterChat = G2Chat_RequestExitChat.Create(); 
            IResponse iResponse = await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Chat).Call(chatUnitId, g2ChatEnterChat);
            return iResponse.Error;
        }
        
        public static async ETTask KickPlayer(Player player, bool isException = false)
        {
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
                await KickPlayerNoLock(player, 5);
            }
        }
        
    }
}