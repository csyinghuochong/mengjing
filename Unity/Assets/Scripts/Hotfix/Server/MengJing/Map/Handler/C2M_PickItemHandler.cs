using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PickItemHandler : MessageLocationHandler<Unit, C2M_PickItemRequest, M2C_PickItemResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PickItemRequest request, M2C_PickItemResponse response)
        {
            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            //DropType ==  0 公共掉落 2保护掉落   1私有掉落
            List<long> privateIds = new();
            List<long> publicIds = new();
            for (int i = request.ItemIds.Count - 1; i >= 0; i--)
            {
                bool have = false;
                for (int d = unitInfoComponent.Drops.Count - 1; d >= 0; d--)
                {
                    UnitInfo unitInfo = unitInfoComponent.Drops[d];
                    if (unitInfo.UnitId == request.ItemIds[i])
                    {
                        have = true;
                        privateIds.Add(request.ItemIds[i]);
                        break;
                    }
                }

                if (!have)
                {
                    publicIds.Add(request.ItemIds[i]);
                }
            }

            if (privateIds.Count == 0 && publicIds.Count == 0)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            int sceneTypeEnum = unit.Scene().GetComponent<MapComponent>().MapType;
            if (sceneTypeEnum == MapTypeEnum.TeamDungeon)
            {
                response.Error = OnTeamPick(unit, privateIds, publicIds, sceneTypeEnum);
            }
            else
            {
                response.Error = OnFubenPick(unit, privateIds, publicIds, sceneTypeEnum);
            }

            await ETTask.CompletedTask;
        }

        private int OnFubenPick(Unit unit, List<long> privateIds, List<long> publicIds, int sceneTypeEnum)
        {
            long serverTime = TimeHelper.ServerNow();
            int errorCode = ErrorCode.ERR_Success;
            //DropType ==  0 公共掉落 2保护掉落   1私有掉落 3 归属掉落

            int cellIndex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.HappyCellIndex);

            List<UnitInfo> unitInfos = new();
            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();
            for (int i = publicIds.Count - 1; i >= 0; i--)
            {
                Unit unitDrop = unitComponent.Get(publicIds[i]);
                if (unitDrop == null)
                {
                    errorCode = ErrorCode.ERR_NetWorkError;
                    continue;
                }

                DropComponentS dropComponent = unitDrop.GetComponent<DropComponentS>();
                NumericComponentS numericComponent = unitDrop.GetComponent<NumericComponentS>();

                int dropType = numericComponent.GetAsInt(NumericType.DropType);

                if (dropType == 2 && dropComponent.OwnerId != 0 && dropComponent.OwnerId != unit.Id && serverTime < dropComponent.ProtectTime)
                {
                    errorCode = ErrorCode.ERR_ItemDropProtect;
                    continue;
                }

                if (dropType == 3 && dropComponent.OwnerId != 0 && dropComponent.OwnerId != unit.Id)
                {
                    errorCode = ErrorCode.ERR_ItemBelongOther;
                    continue;
                }

                unitInfos.Add(MapMessageHelper.CreateUnitInfo(unitDrop));
                unitComponent.Remove(unitDrop.Id); //移除掉落Unit
            }

            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            for (int i = privateIds.Count - 1; i >= 0; i--)
            {
                UnitInfo unitInfo = null;
                for (int d = unitInfoComponent.Drops.Count - 1; d >= 0; d--)
                {
                    if (unitInfoComponent.Drops[d].UnitId == privateIds[i])
                    {
                        unitInfo = unitInfoComponent.Drops[d];
                        unitInfoComponent.Drops.RemoveAt(d); //移除掉落
                        break;
                    }
                }

                if (unitInfo == null)
                {
                    continue;
                }

                if (sceneTypeEnum == MapTypeEnum.Happy && cellIndex != unitInfo.KV[NumericType.CellIndex])
                {
                    errorCode = ErrorCode.Error_PickErrorCell;
                    continue;
                }

                unitInfos.Add(unitInfo);
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            foreach (UnitInfo unitInfo in unitInfos)
            {
                int addItemID = (int)unitInfo.KV[NumericType.DropItemId];
                int addItemNum = (int)unitInfo.KV[NumericType.DropItemNum];
                List<RewardItem> rewardItems = new List<RewardItem>();
                rewardItems.Add(new RewardItem() { ItemID = addItemID, ItemNum = addItemNum });
                bool success = bagComponent.OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PickItem}_{TimeHelper.ServerNow()}");
                if (!success)
                {
                    errorCode = ErrorCode.ERR_BagIsFull;
                    continue;
                }

                FubenHelp.SendFubenPickMessage(unit, unitInfo);

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(addItemID);
                if (sceneTypeEnum == MapTypeEnum.Happy && itemConfig.ItemQuality >= 5)
                {
                    string uername = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    string getmessage = $"{uername}在喜从天降活动这种获得: <color=#{CommonHelp.QualityReturnColor(5)}>{itemConfig.ItemName}</color>";
                    BroadCastHelper.SendBroadMessage(unit.Root(), NoticeType.Notice, getmessage);
                }
            }

            return errorCode;
        }

        private int OnTeamPick(Unit unit, List<long> privateIds, List<long> publicIds, int sceneTypeEnum)
        {
            long debugId = 1231456;
            if (unit.Id == debugId)
            {
                ServerLogHelper.LogDebug($"OnTeamPick1: {debugId} {unit.GetComponent<UserInfoComponentS>().UserName}");
            }

            long serverTime = TimeHelper.ServerNow();
            int errorCode = ErrorCode.ERR_Success;

            //DropType ==  0 公共掉落 2保护掉落   1私有掉落
            TeamDungeonComponent teamDungeonComponent = unit.Scene().GetComponent<TeamDungeonComponent>();
            List<UnitInfo> unitInfos = new();

            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();
            for (int i = publicIds.Count - 1; i >= 0; i--)
            {
                Unit drop = unitComponent.Get(publicIds[i]);
                if (drop == null)
                {
                    errorCode = ErrorCode.ERR_NetWorkError;
                    continue;
                }

                DropComponentS dropComponent = drop.GetComponent<DropComponentS>();
                NumericComponentS numericComponent = drop.GetComponent<NumericComponentS>();

                int dropType = numericComponent.GetAsInt(NumericType.DropType);

                if (dropType == 2 && dropComponent.OwnerId != 0 && dropComponent.OwnerId != unit.Id && serverTime < dropComponent.ProtectTime)
                {
                    errorCode = ErrorCode.ERR_ItemDropProtect;
                    continue;
                }

                if (dropType == 3 && dropComponent.OwnerId != 0 && dropComponent.OwnerId != unit.Id)
                {
                    errorCode = ErrorCode.ERR_ItemBelongOther;
                    continue;
                }

                unitInfos.Add(MapMessageHelper.CreateUnitInfo(drop));
                unitComponent.Remove(drop.Id); //移除掉落Unit
            }

            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            for (int i = privateIds.Count - 1; i >= 0; i--)
            {
                UnitInfo unitInfo = null;
                for (int d = unitInfoComponent.Drops.Count - 1; d >= 0; d--)
                {
                    if (unitInfoComponent.Drops[d].UnitId == privateIds[i])
                    {
                        unitInfo = unitInfoComponent.Drops[d];
                        unitInfoComponent.Drops.RemoveAt(d); //移除掉落
                        break;
                    }
                }

                if (unitInfo == null)
                {
                    continue;
                }

                unitInfos.Add(unitInfo);
            }

            foreach (UnitInfo unitInfo in unitInfos)
            {
                int addItemID = (int)unitInfo.KV[NumericType.DropItemId];
                int addItemNum = (int)unitInfo.KV[NumericType.DropItemNum];
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(addItemID);

                bool teshuItem = itemConfig.ItemQuality >= 4 && itemConfig.ItemType == 2 && itemConfig.ItemSubType == 1;
                //紫色品质通知客户端抉择
                //DropType ==   0 公共掉落 1私有掉落 2保护掉落   3 归属掉落

                if (unitInfo.KV[NumericType.DropType] != 1 && teamDungeonComponent.IsInTeamDrop(unitInfo.UnitId))
                {
                    errorCode = ErrorCode.Error_PickWaitSelect;
                }

                if (unitInfo.KV[NumericType.DropType] == 0 && itemConfig.ItemQuality >= 4 && !teshuItem
                    && !teamDungeonComponent.ItemFlags.ContainsKey(unitInfo.UnitId))
                {
                    teamDungeonComponent.AddTeamDropItem(unitInfo); //这个地方通知客户端弹窗需求还是放弃
                    continue;
                }

                //普通道具直接随机分配
                M2C_SyncChatInfo m2C_SyncChatInfo = M2C_SyncChatInfo.Create();
                m2C_SyncChatInfo.ChatInfo = ChatInfo.Create();
                m2C_SyncChatInfo.ChatInfo.PlayerLevel = unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
                m2C_SyncChatInfo.ChatInfo.Occ = unit.GetComponent<UserInfoComponentS>().UserInfo.Occ;
                m2C_SyncChatInfo.ChatInfo.ChannelId = (int)ChannelEnum.Pick;
                m2C_SyncChatInfo.ChatInfo.Time = TimeHelper.ServerNow();
                string colorValue = CommonHelp.QualityReturnColor(itemConfig.ItemQuality);
                string numShow = "";
                if (itemConfig.Id == 1)
                {
                    numShow = unitInfo.KV[NumericType.DropItemNum].ToString();
                }

                Unit owner = null;
                if (unitInfo.KV[NumericType.DropType] == 1)
                {
                    owner = unit;
                }
                else
                {
                    //已经分配过的
                    if (teamDungeonComponent.ItemFlags.ContainsKey(unitInfo.UnitId))
                    {
                        owner = unit.GetParent<UnitComponent>().Get(teamDungeonComponent.ItemFlags[unitInfo.UnitId]);

                        string pick_name = teamDungeonComponent.TeamPlayers[teamDungeonComponent.ItemFlags[unitInfo.UnitId]].PlayerName;
                        pick_name += (owner == null ? "(未在副本中)" : string.Empty);
                        m2C_SyncChatInfo.ChatInfo.ChatMsg = m2C_SyncChatInfo.ChatInfo.ChatMsg + $"{pick_name}拾取{itemConfig.ItemName}";
                    }
                    else
                    {
                        int maxRollpoint = 0;
                        long maxPlayerId = 0;
                        Dictionary<long, TeamPlayerInfo> allPlayer = teamDungeonComponent.TeamPlayers;
                        foreach ((long uid, TeamPlayerInfo TeamPlayerInfo) in allPlayer)
                        {
                            int rollpoint = 0;
                            if (teshuItem && TeamPlayerInfo.RobotId > 0)
                            {
                                rollpoint = 0;
                            }
                            else
                            {
                                rollpoint = (RandomHelper.RandomNumber(1, 100));
                            }

                            if (rollpoint >= maxRollpoint)
                            {
                                maxRollpoint = rollpoint;
                                maxPlayerId = uid;
                            }

                            m2C_SyncChatInfo.ChatInfo.ChatMsg += $"{TeamPlayerInfo.PlayerName}:{rollpoint}点";
                            m2C_SyncChatInfo.ChatInfo.ChatMsg += "  ";
                        }

                        teamDungeonComponent.ItemFlags.Add(unitInfo.UnitId, maxPlayerId);
                        owner = unit.GetParent<UnitComponent>().Get(maxPlayerId);
                        string pick_name = teamDungeonComponent.TeamPlayers[maxPlayerId].PlayerName;
                        pick_name += (owner == null ? "(未在副本中)" : string.Empty);
                        m2C_SyncChatInfo.ChatInfo.ChatMsg =
                                $"<color=#FDD376>{pick_name}</color>拾取<color=#{colorValue}>{numShow}{itemConfig.ItemName}</color>({m2C_SyncChatInfo.ChatInfo.ChatMsg})";
                    }
                }

                if (owner != null)
                {
                    List<RewardItem> rewardItems = new List<RewardItem>();
                    rewardItems.Add(new RewardItem() { ItemID = addItemID, ItemNum = addItemNum });

                    bool success = owner.GetComponent<BagComponentS>()
                            .OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PickItem}_{TimeHelper.ServerNow()}");
                    if (!success)
                    {
                        errorCode = owner.Id == unit.Id ? ErrorCode.ERR_BagIsFull : ErrorCode.ERR_ItemBelongOther;
                        continue;
                    }
                }

                if (unitInfo.KV[NumericType.DropType] != 1)
                {
                    unit.GetParent<UnitComponent>().Remove(unitInfo.UnitId);
                }

                MapMessageHelper.SendToClient(UnitHelper.GetUnitList(unit.Scene(), UnitType.Player), m2C_SyncChatInfo);
            }

            return errorCode;
        }
    }
}