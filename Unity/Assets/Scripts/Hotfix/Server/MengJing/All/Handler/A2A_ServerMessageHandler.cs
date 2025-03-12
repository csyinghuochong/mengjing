using System;

namespace ET.Server
{

    //服务器之间通用通信协议
    [MessageHandler(SceneType.All)]
    public class A2A_ServerMessageHandler : MessageHandler<Scene, A2A_ServerMessageRequest, A2A_ServerMessageRResponse>
    {

        protected override async ETTask Run(Scene scene, A2A_ServerMessageRequest request, A2A_ServerMessageRResponse response)
        {
            try
            {
                switch (scene.SceneType)
                {
                    case SceneType.Team:
                        if (request.MessageType == NoticeType.PlayerExit)
                        {
                            scene.GetComponent<TeamSceneComponent>().OnRecvUnitLeave(long.Parse(request.MessageValue), true);
                        }
                        break;
                    case SceneType.Solo:
                       
                        break;
                    case SceneType.Rank:
                        if (request.MessageType == NoticeType.RankRefresh)
                        {
                            scene.GetComponent<RankSceneComponent>().UpdateCombat().Coroutine();
                        }
                        if (request.MessageType == NoticeType.StopSever)
                        {
                            scene.GetComponent<RankSceneComponent>().SaveDB().Coroutine();
                            Log.Debug($"数据落地:  Rank: {scene.Zone()}");
                        }
                        break;
                    case SceneType.PaiMai:
                        if (request.MessageType == NoticeType.StopSever)
                        {
                            scene.GetComponent<PaiMaiSceneComponent>().SaveDB(0).Coroutine();
                            Log.Debug($"数据落地:  PaiMai: {scene.Zone()}");
                        }
                        break;
                    case SceneType.Union:
                        if (request.MessageType == NoticeType.StopSever)
                        {
                            scene.GetComponent<UnionSceneComponent>().SaveDB();
                            Log.Debug($"数据落地:  Union: {scene.Zone()}");
                        }
                        break;
                    case SceneType.Chat:
                        ChatSceneComponent chatInfoUnitsComponent = scene.GetComponent<ChatSceneComponent>();
                        if (request.MessageType == NoticeType.PaiMai)
                        {
                            M2C_SyncChatInfo m2C_SyncChatInfo = M2C_SyncChatInfo.Create();
                            m2C_SyncChatInfo.ChatInfo = ChatInfo.Create();
                            m2C_SyncChatInfo.ChatInfo.ChannelId = (int)ChannelEnum.PaiMai;
                            m2C_SyncChatInfo.ChatInfo.ChatMsg = request.MessageValue;
                            m2C_SyncChatInfo.ChatInfo.Time = TimeHelper.ServerNow();
                            foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitsDict.Values)
                            {
                                MapMessageHelper.SendToClient(scene.Root(), otherUnit.GateSessionActorId, m2C_SyncChatInfo);
                            }
                        }
                        else
                        {
                            M2C_HorseNoticeInfo m2C_HorseNoticeInfo = M2C_HorseNoticeInfo.Create();
                            m2C_HorseNoticeInfo.NoticeType = request.MessageType;
                            m2C_HorseNoticeInfo.NoticeText = request.MessageValue;
                            foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitsDict.Values)
                            {
                                MapMessageHelper.SendToClient(scene.Root(), otherUnit.GateSessionActorId, m2C_HorseNoticeInfo);
                            }
                        }
  
                        break;
                    case SceneType.LoginCenter:
                        string[] messagevalue = request.MessageValue.Split('_');
                        
                        if (messagevalue[0] == "0")
                        {
                            scene.GetComponent<FangChenMiComponentS>().StopServer = true;
                            ServerLogHelper.OnStopServer();
                            Log.Warning("StopServer = true");
                        }
                        if(messagevalue[0] == "1")
                        {
                            scene.GetComponent<FangChenMiComponentS>().StopServer = false;
                            Log.Warning("StopServer = false");
                        }
                        if (messagevalue[0] == "2")
                        {
                            EventSystem.Instance.Publish(scene.Scene(), new  GenerateSerials() { Scene = scene });
                        }
                        break;
                    default:
                        break;
                }
                
                await ETTask.CompletedTask;
            }
            catch (Exception e)
            { 
                Log.Error(e);
            }
        }
    }
}