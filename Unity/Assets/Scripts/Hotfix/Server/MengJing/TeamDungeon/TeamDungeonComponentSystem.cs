using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(TeamDungeonComponent))]
    [FriendOf(typeof(TeamDungeonComponent))]
    public static partial class TeamDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TeamDungeonComponent self)
        {
            self.EnterTime = 0;
            self.BoxReward.Clear();
            self.ItemFlags.Clear();
            self.TeamDropItems.Clear();
            self.KillBossList.Clear();
        }

        [EntitySystem]
        private static void Destroy(this TeamDungeonComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnEnterDungeon(this TeamDungeonComponent self, Unit unit)
        {
            if(unit.IsRobot())
            {
                return;
            }
            int fubenType = self.FubenType;
            bool firstEnter = !self.TeamPlayers.ContainsKey(unit.Id);
            if (firstEnter)
            {
                self.AddPlayerList( unit.Id );
                if (fubenType == TeamFubenType.XieZhu && unit.Id == self.TeamId)
                {
                    int times_2 = unit.GetTeamDungeonXieZhu();
                    int totalTimes_2 = GlobalValueConfigCategory.Instance.MaxDailyXieZhuFubens;
                    if (totalTimes_2 > times_2)
                    {
                        unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonXieZhu, unit.GetTeamDungeonXieZhu() + 1);
                    }
                    else
                    {
                        unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonTimes, unit.GetTeamDungeonTimes() + 1);
                    }
                }
                else
                {
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonTimes, unit.GetTeamDungeonTimes() + 1);
                }

                if (fubenType == TeamFubenType.ShenYuan && unit.Id == self.TeamId)
                {
                    unit.GetComponent<BagComponentS>().OnCostItemData($"{ConfigData.ShenYuanCostId};1");
                }

                if (fubenType == TeamFubenType.ShenYuan)
                {
                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.ShenYuanNumber_135, 0, 1);
                }
            }
            
        }

        public static void AddPlayerList(this TeamDungeonComponent self, long unitid)
        {
            self.TeamPlayers[unitid] = TeamPlayerInfo.Create();
            
        }
        
        public static void Check(this TeamDungeonComponent self)
        {
            if (self.TeamDropItems.Count == 0)
            {
                //TimerComponent.Instance.Remove(ref self.Timer);
                return;
            }

            long serverTime = TimeHelper.ServerNow();
            List<Unit> allunits = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            int playerCount = allunits.Count;
            for (int i = self.TeamDropItems.Count - 1; i >= 0; i--)
            {
                TeamDropItem teamDropItem = self.TeamDropItems[i];
                if (teamDropItem.EndTime == -1)
                {
                    continue;
                }

                List<long> needIds = teamDropItem.NeedPlayers;
                List<long> giveIds = teamDropItem.GivePlayers;
                bool finish = serverTime >= teamDropItem.EndTime || (needIds.Count + giveIds.Count >= playerCount);
                if (!finish)
                {
                    continue;
                }

                teamDropItem.EndTime = -1;
                if (playerCount == 0)
                {
                    Log.Warning($"TeamDungeonComponent.DropInfo：playerCount == 0");
                    //self.DomainScene().GetComponent<UnitComponent>().Remove(teamDropItem.DropInfo.UnitId);   
                    continue;
                }

                //全部放弃则默认分配
                if (giveIds.Count >= playerCount || needIds.Count == 0)
                {
                    for (int allunit = 0; allunit < allunits.Count; allunit++)
                    {
                        needIds.Add(allunits[allunit].Id);
                    }
                }

                int maxNumber = 0;
                List<int> randomNumbers = new List<int>();
                for (int p = 0; p < needIds.Count; p++)
                {
                    randomNumbers.Add(RandomHelper.RandomNumber(1, 100));
                    if (randomNumbers[p] > maxNumber)
                    {
                        maxNumber = randomNumbers[p];
                    }
                }

                int onwerIndex = randomNumbers.IndexOf(maxNumber);
                long unitid = teamDropItem.NeedPlayers[onwerIndex];
                Unit unit = self.Scene().GetComponent<UnitComponent>().Get(unitid);
                if (unit != null)
                {
                    List<RewardItem> rewardItems = new List<RewardItem>();
                    rewardItems.Add(new RewardItem()
                    {
                        ItemID = (int)teamDropItem.DropInfo.KV[NumericType.DropItemId], ItemNum = (int)teamDropItem.DropInfo.KV[NumericType.DropItemNum]
                    });
                    bool ret = unit.GetComponent<BagComponentS>()
                            .OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PickItem}_{TimeHelper.ServerNow()}");
                    //Log.Warning($"TeamDungeonComponent.DropInfo：{ret}  {unit.Id} {teamDropItem.DropInfo.ItemID} {teamDropItem.DropInfo.ItemNum}");
                    if (ret)
                    {
                        FubenHelp.SendTeamPickMessage(unit, teamDropItem.DropInfo, needIds, randomNumbers);
                        self.Scene().GetComponent<UnitComponent>().Remove(teamDropItem.DropInfo.UnitId); //移除掉落ID
                        continue;
                    }

                    if (!self.ItemFlags.ContainsKey(teamDropItem.DropInfo.UnitId))
                    {
                        self.ItemFlags.Add(teamDropItem.DropInfo.UnitId, unitid);
                    }
                }
                else
                {
                    Log.Warning($"TeamDungeonComponent.DropInfo：unit == null");
                    //self.DomainScene().GetComponent<UnitComponent>().Remove(teamDropItem.DropInfo.UnitId);       //移除掉落ID
                }
            }
        }

        public static bool IsInTeamDrop(this TeamDungeonComponent self, long dropId)
        {
            for (int i = self.TeamDropItems.Count - 1; i >= 0; i--)
            {
                if (self.TeamDropItems[i].DropInfo.UnitId == dropId)
                {
                    return true;
                }
            }

            return false;
        }

        public static TeamDropItem AddTeamDropItem(this TeamDungeonComponent self, UnitInfo dropInfo)
        {
            for (int i = self.TeamDropItems.Count - 1; i >= 0; i--)
            {
                if (self.TeamDropItems[i].EndTime == -1)
                {
                    //Log.Warning($"self.TeamDropItems[i].EndTime == -1:   {dropInfo.ItemID}");
                    self.TeamDropItems.RemoveAt(i);
                    continue;
                }

                if (self.TeamDropItems[i].DropInfo.UnitId == dropInfo.UnitId)
                {
                    self.Check();
                    return null;
                }
            }

            TeamDropItem teamDropItem = null;
            if (self.GetChild<TeamDropItem>(dropInfo.UnitId) != null)
            {
                teamDropItem = self.GetChild<TeamDropItem>(dropInfo.UnitId);
            }
            else
            {
                teamDropItem = self.AddChildWithId<TeamDropItem>(dropInfo.UnitId);
            }

            teamDropItem.DropInfo = dropInfo;
            teamDropItem.EndTime = TimeHelper.ServerNow() + 60 * 1000;

            self.TeamDropItems.Add(teamDropItem);
            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.TeamDropTimer, self);
            }

            M2C_TeamPickMessage teamPickMessage = self.m2C_TeamPickMessage;
            teamPickMessage.DropItems.Clear();
            teamPickMessage.DropItems.Add(dropInfo);

            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            MapMessageHelper.SendToClient(players, teamPickMessage);
            return teamDropItem;
        }

        public static int GetRealPlayerNumber(this TeamDungeonComponent self)
        {
            return 1;
        }

        public static void OnUpdateDamage(this TeamDungeonComponent self, Unit attack, Unit defend, long damage)
        {
            if (attack == null)
            {
                return;
            }

            if (defend.Type != UnitType.Monster)
            {
                return;
            }

            List<TeamPlayerInfo> vs = self.TeamPlayers.Values.ToList();
            for (int i = 0; i < vs.Count; i++)
            {
                if (vs[i].UserID == attack.Id)
                {
                    vs[i].Damage += (int)damage;
                }
            }

            if (TimeHelper.ServerNow() - self.EnterTime < 5000)
            {
                return;
            }

            self.EnterTime = TimeHelper.ServerNow();
            List<Unit> allPlayer = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            for (int i = 0; i < allPlayer.Count; i++)
            {
                M2C_SyncMiJingDamage m2C_SyncMiJingDamage = M2C_SyncMiJingDamage.Create();
                m2C_SyncMiJingDamage.DamageList.AddRange(self.TeamPlayers.Values.ToList());
                MapMessageHelper.SendToClient(allPlayer[i], m2C_SyncMiJingDamage);
            }
        }

        public static async ETTask CheckFriend(this TeamDungeonComponent self, Dictionary<long, int> hurts)
        {
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            for (int i = 0; i < players.Count; i++)
            {
                Unit unit = players[i];
                if (unit.IsRobot())
                {
                    continue;
                }

                DBFriendInfo dBFriendInfo = await UnitCacheHelper.GetComponent<DBFriendInfo>(self.Root(), unit.Id);
                if (dBFriendInfo == null)
                {
                    continue;
                }

                bool haveFriend = false;
                for (int friend = 0; friend < dBFriendInfo.FriendList.Count; friend++)
                {
                    if (hurts.ContainsKey(dBFriendInfo.FriendList[friend]))
                    {
                        haveFriend = true;
                        break;
                    }
                }

                //if (self.DomainZone() == 56 && unit.Id == 2122034524618555392)
                //{
                //    Log.Warning($"与好友完成组队副本： {unit.Id}   {dBFriendInfo.FriendList.Count}");
                //}

                if (haveFriend)
                {
                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.FriendPassFuben_138, 0, 1);
                }
            }

            await ETTask.CompletedTask;
        }

        public static bool OnKillEvent(this TeamDungeonComponent self, Unit unit)
        {
            if (unit.Type != UnitType.Monster)
            {
                return false;
            }

            if (unit.IsBoss())
            {
                Unit leader = unit.GetParent<UnitComponent>().Get(self.TeamId);
                if (leader != null && self.FubenType == TeamFubenType.XieZhu)
                {
                    //协助副本掉落
                    int dropId = GlobalValueConfigCategory.Instance.XieZhuFubenDropId;
                    UnitFactory.CreateDropItems(leader, unit, 1, dropId, "1");
                }

                if (self.FubenType == TeamFubenType.ShenYuan)
                {
                    //深渊副本掉落
                    int dropId = GlobalValueConfigCategory.Instance.ShenYuanFubenDropId;
                    UnitFactory.CreateDropItems(null, unit, 0, dropId, "1");
                }

                self.BossDeadPosition = unit.Position;
            }

            int sceneid = self.Scene().GetComponent<MapComponent>().SceneId;
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
            if (unit.ConfigId != sceneConfig.BossId)
            {
                return false;
            }

            M2C_TeamDungeonSettlement m2C_FubenSettlement = M2C_TeamDungeonSettlement.Create();
            m2C_FubenSettlement.PassTime = 5 * 60 * 1000;
            m2C_FubenSettlement.PlayerList = self.TeamPlayers.Values.ToList();

            DropHelper.DropIDToDropItem_2(sceneConfig.BoxDropID, m2C_FubenSettlement.RewardExtraItem);

            DropHelper.DropIDToDropItem_2(sceneConfig.BoxDropID, m2C_FubenSettlement.RewardList);
            DropHelper.DropIDToDropItem_2(sceneConfig.BoxDropID, m2C_FubenSettlement.RewardList);
            DropHelper.DropIDToDropItem_2(sceneConfig.BoxDropID, m2C_FubenSettlement.RewardList);

            DropHelper.DropIDToDropItem_2(sceneConfig.BoxDropID, m2C_FubenSettlement.RewardListExcess);
            DropHelper.DropIDToDropItem_2(sceneConfig.BoxDropID, m2C_FubenSettlement.RewardListExcess);
            DropHelper.DropIDToDropItem_2(sceneConfig.BoxDropID, m2C_FubenSettlement.RewardListExcess);

            //最高伤害额外奖励
            long idExtra = 0;
            int damageMax = 0;
            int damageTotal = 0;
            Dictionary<long, int> hurtList = new Dictionary<long, int>();
            for (int i = 0; i < m2C_FubenSettlement.PlayerList.Count; i++)
            {
                TeamPlayerInfo teamPlayerInfo = m2C_FubenSettlement.PlayerList[i];
                if (teamPlayerInfo.Damage >= damageMax)
                {
                    damageMax = teamPlayerInfo.Damage;
                    idExtra = teamPlayerInfo.UserID;
                }

                damageTotal += teamPlayerInfo.Damage;
                if (!hurtList.ContainsKey(teamPlayerInfo.UserID))
                {
                    hurtList.Add(teamPlayerInfo.UserID, teamPlayerInfo.Damage);
                }
            }

            self.CheckFriend(hurtList).Coroutine();

            //TeamDungeonHurt_136
            List<EntityRef<Unit>> units = unit.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unititem = units[i];
                if (unititem.Type != UnitType.Player || unititem.IsRobot())
                {
                    continue;
                }

                int hurtvalue = 0;
                hurtList.TryGetValue(unititem.Id, out hurtvalue);
                int hurtRate = (int)(hurtvalue * 100f / damageTotal);
                unititem.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.TeamDungeonHurt_136, sceneid, hurtRate);

                unititem.GetComponent<TaskComponentS>().OnPassTeamFuben();
                unititem.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.PassTeamFubenNumber_20, 0, 1);
                if (self.FubenType == TeamFubenType.ShenYuan)
                {
                    unititem.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.PassTeamShenYuanNumber_21, 0, 1);
                }

                if (unititem.GetComponent<UserInfoComponentS>().UserInfo.UserId == idExtra)
                {
                    unititem.GetComponent<BagComponentS>().OnAddItemData(m2C_FubenSettlement.RewardExtraItem, string.Empty,
                        $"{ItemGetWay.FubenGetReward}_{TimeHelper.ServerNow()}");
                }

                MapMessageHelper.SendToClient(unititem, m2C_FubenSettlement);
            }

            return true;
        }

    }
}