using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof (NumericComponentS))]
    [FriendOf(typeof (MoveComponent))]
    public static partial class MapMessageHelper
    {
        
          public static void GetUnitInfo(Unit sendUnit, M2C_CreateUnits createUnits)
        {
            switch (sendUnit.Type)
            {
                case UnitType.Player:
                case UnitType.JingLing:
                case UnitType.Pasture:
                case UnitType.Plant:
                case UnitType.Pet:
                case UnitType.Bullet:
                case UnitType.Npc:
                case UnitType.Stall:
                    createUnits.Units.Add(CreateUnitInfo(sendUnit));
                    break;
                case UnitType.Monster:
                    createUnits.Spilings.Add(CreateSpilingInfo(sendUnit));
                    break;
                case UnitType.DropItem:
                    createUnits.Drops.Add(CreateDropInfo(sendUnit));
                    break;
                case UnitType.Chuansong:
                    createUnits.Transfers.Add(CreateTransferInfo(sendUnit));
                    break;
            }
        }

        public static UnitInfo CreateUnitInfo(Unit unit)
        {
            UnitInfo unitInfo = new();
            NumericComponentS nc = unit.GetComponent<NumericComponentS>();
            unitInfo.UnitId = unit.Id;
            unitInfo.ConfigId = unit.ConfigId;
            unitInfo.Type = (int)unit.Type();
            unitInfo.Position = unit.Position;
            unitInfo.Forward = unit.Forward;

            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            if (moveComponent != null)
            {
                if (!moveComponent.IsArrived())
                {
                    unitInfo.MoveInfo = MoveInfo.Create();
                    unitInfo.MoveInfo.Points.Add(unit.Position);
                    for (int i = moveComponent.N; i < moveComponent.Targets.Count; ++i)
                    {
                        float3 pos = moveComponent.Targets[i];
                        unitInfo.MoveInfo.Points.Add(pos);
                    }
                }
            }

            if (nc != null)
            {
                foreach ((int key, long value) in nc.NumericDic)
                {
                    unitInfo.KV.Add(key, value);
                }
            }

            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            switch (unit.Type)
            {
                case UnitType.Player:
                    //携带的buff
                    // unitInfo.Buffs = unit.GetComponent<BuffManagerComponentS>().GetMessageBuff();
                    // unitInfo.Skills = unit.GetComponent<SkillManagerComponentS>().GetMessageSkill();
                    //设置数据
                    UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                    unitInfo.UnitName = userInfoComponent.UserInfo.Name;
                    unitInfo.ConfigId = userInfoComponent.UserInfo.Occ;
                    unitInfo.UnionName = string.IsNullOrWhiteSpace(userInfoComponent.UserInfo.UnionName)? string.Empty
                            : userInfoComponent.UserInfo.UnionName;
                    unitInfo.DemonName = unitInfoComponent.DemonName;
                    unitInfo.FashionEquipList = unit.GetComponent<BagComponentS>().FashionEquipList;
                    break;
                case UnitType.JingLing:
                    unitInfo.MasterName = unitInfoComponent.MasterName;
                    unitInfo.UnitName = unitInfoComponent.UnitName;
                    break;
                case UnitType.Pasture:
                case UnitType.Plant:
                    unitInfo.MasterName = unitInfoComponent.MasterName;
                    unitInfo.UnitName = unitInfoComponent.UnitName;
                    break;
                case UnitType.Pet:
                    unitInfo.MasterName = unit.GetComponent<UnitInfoComponent>().MasterName;
                    unitInfo.UnitName = unit.GetComponent<UnitInfoComponent>().UnitName;
                    break;
                case UnitType.Bullet:
                    unitInfo.UnitName = unit.GetComponent<UnitInfoComponent>().UnitName;
                    break;
                case UnitType.Stall:
                    unitInfo.UnitName = unit.GetComponent<UnitInfoComponent>().UnitName;
                    break;
                case UnitType.Npc:
                    break;
                default:
                    break;
            }

            return unitInfo;
        }

        public static SpilingInfo CreateSpilingInfo(Unit unit)
        {
            SpilingInfo spilingInfo = SpilingInfo.Create();
            unit.GetComponent<UnitInfoComponent>();
            spilingInfo.X = unit.Position.x;
            spilingInfo.Y = unit.Position.y;
            spilingInfo.Z = unit.Position.z;
            float3 forward = unit.Forward;
            spilingInfo.ForwardX = forward.x;
            spilingInfo.ForwardY = forward.y;
            spilingInfo.ForwardZ = forward.z;
            spilingInfo.UnitId = unit.Id;

            NumericComponentS nc = unit.GetComponent<NumericComponentS>();
            if (nc != null)
            {
                foreach ((int key, long value) in nc.NumericDic)
                {
                    if (key >= (int)NumericType.Max)
                    {
                        continue;
                    }
                    spilingInfo.Ks.Add(key);
                    spilingInfo.Vs.Add(value);
                }
            }

            // if (unit.GetComponent<BuffManagerComponentS>() != null)
            // {
            //     spilingInfo.Buffs = unit.GetComponent<BuffManagerComponentS>().GetMessageBuff();
            //     spilingInfo.Skills = unit.GetComponent<SkillManagerComponentS>().GetMessageSkill();
            // }
            //广播创建的是那个怪物ID
            spilingInfo.SkillId = unit.GetComponent<UnitInfoComponent>().EnergySkillId;
            spilingInfo.MonsterID = unit.ConfigId;
            return spilingInfo;
        }
        
        public static DropInfo CreateDropInfo(Unit unit)
        {
            DropInfo dropinfo = DropInfo.Create();
            dropinfo.UnitId = unit.Id;
            //DropType == 0 公共掉落 2保护掉落   1私有掉落
            DropComponentS dropComponent = unit.GetComponent<DropComponentS>();
            dropinfo.DropType = dropComponent.OwnerId > 0 ? 2 : 0;
            dropinfo.ItemID = dropComponent.ItemID;
            dropinfo.ItemNum = dropComponent.ItemNum;
            dropinfo.CellIndex = dropComponent.CellIndex;
            dropinfo.BeKillId = dropComponent.BeKillId;
            dropinfo.X = unit.Position.x;
            dropinfo.Y = unit.Position.y;
            dropinfo.Z = unit.Position.z;
            return dropinfo;
        }

        public static TransferInfo CreateTransferInfo(Unit unit)
        {
            TransferInfo transferinfo = TransferInfo.Create();
            ChuansongComponent chuansongComponent = unit.GetComponent<ChuansongComponent>();

            transferinfo.UnitId = unit.Id;
            transferinfo.X = unit.Position.x;
            transferinfo.Y = unit.Position.y;
            transferinfo.Z = unit.Position.z;
            transferinfo.CellIndex = chuansongComponent.CellIndex;
            transferinfo.Direction = chuansongComponent.DirectionType;
            transferinfo.TransferId = unit.ConfigId;
            return transferinfo;
        }
        
        
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
            GetUnitInfo(sendUnit, createUnits);
            SendToClient(unit, createUnits);
        }


        public static void NoticeUnitRemove(Unit unit, Unit sendUnit)
        {
            M2C_RemoveUnits removeUnits = M2C_RemoveUnits.Create();
            removeUnits.Units.Add(sendUnit.Id);
            SendToClient(unit, removeUnits);
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

        //技能广播
        public static void BroadcastSkill( Unit unit, IMessage message)
        {
            //主城不广播技能
            if (unit.SceneType != SceneTypeEnum.MainCityScene)
            {
                Broadcast(unit, message);
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