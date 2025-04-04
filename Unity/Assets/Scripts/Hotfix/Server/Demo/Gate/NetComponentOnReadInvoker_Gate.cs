﻿using System;

namespace ET.Server
{
    [Invoke((long)SceneType.Gate)]
    public class NetComponentOnReadInvoker_Gate: AInvokeHandler<NetComponentOnRead>
    {
        public override void Handle(NetComponentOnRead args)
        {
            HandleAsync(args).Coroutine();
        }

        private async ETTask HandleAsync(NetComponentOnRead args)
        {
            Session session = args.Session;
            object message = args.Message;
            Scene root = args.Session.Root();
            // 根据消息接口判断是不是Actor消息，不同的接口做不同的处理,比如需要转发给Chat Scene，可以做一个IChatMessage接口
            switch (message)
            {
                case ISessionMessage:
                {
                    MessageSessionDispatcher.Instance.Handle(session, message);
                    break;
                }
                case FrameMessage frameMessage:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
                    frameMessage.PlayerId = player.Id;
                    root.GetComponent<MessageSender>().Send(roomActorId, frameMessage);
                    break;
                }
                case IRoomMessage actorRoom:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
                    actorRoom.PlayerId = player.Id;
                    root.GetComponent<MessageSender>().Send(roomActorId, actorRoom);
                    break;
                }
                case IChatActorRequest actorChatLocationRequest: // gate session收到actor rpc消息，先向actor 发送rpc请求，再将请求结果返回客户端
                {
                    long chatUnitId = session.GetComponent<SessionPlayerComponent>().Player.ChatInfoInstanceId;
                    int rpcId = actorChatLocationRequest.RpcId; // 这里要保存客户端的rpcId
                    long instanceId = session.InstanceId;
                    IResponse iResponse = await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Chat).Call(chatUnitId, actorChatLocationRequest);
                    iResponse.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                    {
                        session.Send(iResponse);
                    }
                    break;
                }
                case ILocationMessage actorLocationMessage:
                {
                    long unitId = session.GetComponent<SessionPlayerComponent>().Player.UnitId;

                    root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitId, actorLocationMessage);
                    break;
                }
                case ILocationRequest actorLocationRequest: // gate session收到actor rpc消息，先向actor 发送rpc请求，再将请求结果返回客户端
                {
                    long unitId = session.GetComponent<SessionPlayerComponent>().Player.UnitId;
                    int rpcId = actorLocationRequest.RpcId; // 这里要保存客户端的rpcId
                    long instanceId = session.InstanceId;
                    IResponse iResponse = await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(unitId, actorLocationRequest);
                    iResponse.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                    {
                        session.Send(iResponse);
                    }
                    break;
                }
                case IRequest actorRequest:  // 分发IActorRequest消息，目前没有用到，需要的自己添加
                {
                    IResponse response = null;
                    int rpcId = actorRequest.RpcId;
                    long instanceId = session.InstanceId;
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    if (actorRequest is IActivityActorRequest iActivityRequest)
                    {
                        ActorId activityServerId = player.ActivityServerId;
                        response = await root.GetComponent<MessageSender>().Call(activityServerId, iActivityRequest);
                    }

                    if (actorRequest is IFriendActorRequest iFriendActorRequest)
                    {
                        ActorId friendServerId = player.FriendServerId;
                        response = await root.GetComponent<MessageSender>().Call(friendServerId, iFriendActorRequest);
                    }
                    
                    if (actorRequest is IMailActorRequest iMailActorRequest)
                    {
                        ActorId mailServerID = player.MailServerID;
                        response = await root.GetComponent<MessageSender>().Call(mailServerID, iMailActorRequest);
                    }
                    
                    if (actorRequest is IRankActorRequest iRankActorRequest)
                    {
                        ActorId rankServerID = player.RankServerID;
                        response = await root.GetComponent<MessageSender>().Call(rankServerID, iRankActorRequest);
                    }
                    
                    if (actorRequest is IPaiMaiListRequest iPaiMaiListRequest)
                    {
                        ActorId paiMaiServerID = player.PaiMaiServerID;
                        response = await root.GetComponent<MessageSender>().Call(paiMaiServerID, iPaiMaiListRequest);
                    }

                    if (actorRequest is IUnionActorRequest iUnionActorRequest)
                    {
                        ActorId unionServerID = player.UnionServerID;
                        response = await root.GetComponent<MessageSender>().Call(unionServerID, iUnionActorRequest);
                    }

                    if (actorRequest is ISoloActorRequest iSoloActorRequest)
                    {
                        ActorId soloServerID = player.SoloServerID;
                        response = await root.GetComponent<MessageSender>().Call(soloServerID, iSoloActorRequest);
                    }
                    
                    if (actorRequest is IPetMatchActorRequest iPetMatchActorRequest)
                    {
                        ActorId petmatchServerID = player.PetMatchServerID;
                        response = await root.GetComponent<MessageSender>().Call(petmatchServerID, iPetMatchActorRequest);
                    }

                    if (actorRequest is IPopularizeActorRequest iPopularizeActorRequest)
                    {
                        ActorId popularizeServerID = player.PopularizeServerID;
                        response = await root.GetComponent<MessageSender>().Call(popularizeServerID, iPopularizeActorRequest);
                    }
                    
                    if (actorRequest is ITeamActorRequest iTeamActorRequest)
                    {
                        ActorId teamServerID = player.TeamServerID;
                        response = await root.GetComponent<MessageSender>().Call(teamServerID, iTeamActorRequest);
                    }

                    if (response == null)
                    {
                        break;
                    }
                    response.RpcId = rpcId;
                    if (session.InstanceId == instanceId)
                    {
                        session.Send(response);
                    }
                    break;
                }
                case IMessage actorMessage:  // 分发IActorMessage消息，目前没有用到，需要的自己添加
                {
                    break;
                }
				
                default:
                {
                    throw new Exception($"not found handler: {message}");
                }
            }
        }
    }
}