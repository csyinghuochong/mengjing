using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof (NumericComponentS))]
    [FriendOf(typeof (MoveComponent))]
    public static partial class MapMessageHelper
    {
        public static void NoticeUnitAdd(Unit unit, Unit sendUnit)
        {
            //非自己击杀的怪物。不同步
            if (sendUnit.Type == UnitType.DropItem)
            {
                DropComponentS dropComponent = sendUnit.GetComponent<DropComponentS>();
                if (dropComponent.IfDamgeDrop == 1 && !dropComponent.BeAttackPlayerList.Contains(unit.Id))
                {
                    return;
                }
            }

            M2C_CreateUnits createUnits = M2C_CreateUnits.Create();
            UnitHelper.GetUnitInfo(sendUnit, createUnits);
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
            Dictionary<long, EntityRef<AOIEntity>> dict = unit.GetBeSeePlayers();
            // 网络底层做了优化，同一个消息不会多次序列化
            MessageLocationSenderOneType oneTypeMessageLocationType =
                    unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession);
            foreach (AOIEntity u in dict.Values)
            {
                oneTypeMessageLocationType.Send(u.Unit.Id, message);
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
            Dictionary<long, EntityRef<AOIEntity>>  dict = unit.GetBeSeePlayers();
            //(ushort opcode, MemoryStream stream) = MessageSerializeHelper.MessageToStream(message);

            foreach (AOIEntity u in dict.Values)
            {
                bool broadcast = unit.Id == u.Unit.Id;

                if (!broadcast)
                {
                    if (buffConfig.BroadcastType == 0)
                    {
                        broadcast = true;
                    }

                    if (buffConfig.BroadcastType == 1) //队友
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
            unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(unit.Id, message);
        }

        public static void SendToClient(List<Unit> units, IMessage message)
        {
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(unit.Id, message);
            }
        }

        public static void SendToClient(Scene root, long GateSessionId, IMessage message)
        {
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(GateSessionId, message);
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