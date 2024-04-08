

using System.Collections.Generic;
using System.IO;

namespace ET.Server
{
    public static partial class MapMessageHelper
    {
        public static void NoticeUnitAdd(Unit unit, Unit sendUnit)
        {
            M2C_CreateUnits createUnits = M2C_CreateUnits.Create();
            createUnits.Units.Add(UnitHelper.CreateUnitInfo(sendUnit));
            MapMessageHelper.SendToClient(unit, createUnits);
        }
        
        public static void NoticeUnitRemove(Unit unit, Unit sendUnit)
        {
            M2C_RemoveUnits removeUnits = M2C_RemoveUnits.Create();
            removeUnits.Units.Add(sendUnit.Id);
            MapMessageHelper.SendToClient(unit, removeUnits);
        }
        
        public static void Broadcast(Unit unit, IMessage message)
        {
            (message as MessageObject).IsFromPool = false;
            Dictionary<long, AOIEntity> dict = unit.GetBeSeePlayers();
            // 网络底层做了优化，同一个消息不会多次序列化
            MessageLocationSenderOneType oneTypeMessageLocationType = unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession);
            foreach (AOIEntity u in dict.Values)
            {
                oneTypeMessageLocationType.Send(u.Unit.GateSessionActorId, message);
            }
        }
        
        public static void BroadcastBuff(Unit unit, IMessage message, SkillBuffConfig buffConfig, int sceneType)
        {
            //主城只给自己广播
            if (unit.Type == UnitType.Player && sceneType == SceneTypeEnum.MainCityScene)
            {
                SendToClient(unit, message);
                return;
            }

            ///0 全部 1 队友
            Dictionary<long, AOIEntity> dict = unit.GetBeSeePlayers();
            (ushort opcode, MemoryStream stream) = MessageSerializeHelper.MessageToStream(message);

            foreach (AOIEntity u in dict.Values)
            {
                bool broadcast = unit.Id == u.Unit.Id;

                if (!broadcast)
                {
                    if (buffConfig.BroadcastType == 0)
                    {
                        broadcast = true;
                    }
                    if (buffConfig.BroadcastType == 1)  //队友
                    {
                        broadcast = unit.IsSameTeam(u.Unit);
                    }
                }

                if (!broadcast)
                {
                    continue;
                }

                SendToClient(u.Unit, message);
            }
        }
        
        public static void SendToClient(Unit unit, IMessage message)
        {
            unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(unit.GateSessionActorId, message);
        }
        
        /// <summary>
        /// 发送协议给Actor
        /// </summary>
        public static void Send(Scene root, ActorId actorId, IMessage message)
        {
            root.GetComponent<MessageSender>().Send(actorId, message);
        }
    }
}