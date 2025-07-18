using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof (MiJingDungeonComponent))]
    [FriendOf(typeof (MiJingDungeonComponent))]
    public static partial class MiJingDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MiJingDungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MiJingDungeonComponent self)
        {
        }

        public static void OnKillEvent(this MiJingDungeonComponent self, Unit defend)
        {
            if (defend.ConfigId != self.BossId)
            {
                return;
            }

            List<TeamPlayerInfo> players = new List<TeamPlayerInfo>();
            players.AddRange(self.PlayerDamageList.Take(5));

            self.SendReward(players, 0, 0, "1;150000@10010085;100").Coroutine();
            self.SendReward(players, 1, 1, "1;100000@10010085;75").Coroutine();
            ;
            self.SendReward(players, 2, 2, "1;75000@10010085;50").Coroutine();
            ;
            self.SendReward(players, 3, 4, "1;50000@10010085;40").Coroutine();
            ;
            self.SendReward(players, 5, 9, "1;30000@10010085;30").Coroutine();
            ;
            self.SendReward(players, 10, 19, "1;20000@10010085;20").Coroutine();

            self.PlayerDamageList.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="players"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="rewardList"></param>
        public static async ETTask SendReward(this MiJingDungeonComponent self, List<TeamPlayerInfo> players, int start, int end, string rewardList)
        {
            long serverTime = TimeHelper.ServerNow();
            ActorId mailServerId = UnitCacheHelper.GetMailServerId(self.Zone());
            for (int i = start; i <= end; i++)
            {
                if (i >= players.Count || players[i].RobotId > 0)
                {
                    return;
                }

                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Status = 0;
                int num = i + 1;
                mailInfo.Context = $"恭喜你在秘境中获得第{num}名，获得如下奖励。";
                mailInfo.Title = "秘境领主排名奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();
                string[] needList = rewardList.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    ItemInfoProto BagInfo = ItemInfoProto.Create();
                    BagInfo.ItemID = itemId;
                    BagInfo.ItemNum = itemNum;
                    BagInfo.GetWay = $"{ItemGetWay.MiJingBoss}_{serverTime}";
                    mailInfo.ItemList.Add(BagInfo);
                }

                Log.Warning($"世界Boss排名奖励1: {self.Zone()}  {players[i].UserID}");
                await MailHelp.SendUserMail(self.Root(),  players[i].UserID, mailInfo, ItemGetWay.MiJingBoss);
            }
        }

        public static void OnUpdateDamage(this MiJingDungeonComponent self, Unit attack, Unit defend, long damage)
        {
            if (attack == null)
            {
                return;
            }

            if (!defend.IsBoss() || defend.ConfigId != self.BossId)
            {
                return;
            }

            TeamPlayerInfo teamPlayerInfo = null;
            for (int i = 0; i < self.PlayerDamageList.Count; i++)
            {
                if (self.PlayerDamageList[i].UserID == attack.Id)
                {
                    teamPlayerInfo = self.PlayerDamageList[i];
                    teamPlayerInfo.Damage += (int)damage;
                }
            }

            if (teamPlayerInfo == null)
            {
                UserInfo userInfo = attack.GetComponent<UserInfoComponentS>().UserInfo;
                teamPlayerInfo = TeamPlayerInfo.Create();
                teamPlayerInfo.UserID = attack.Id;
                teamPlayerInfo.PlayerName = userInfo.Name;
                teamPlayerInfo.Damage = (int)damage;
                teamPlayerInfo.PlayerLv = userInfo.Lv;
                self.PlayerDamageList.Add(teamPlayerInfo);
            }

            if (TimeHelper.ServerNow() - self.LastTime < 1000)
            {
                return;
            }

            self.LastTime = TimeHelper.ServerNow();
            self.PlayerDamageList.Sort(delegate(TeamPlayerInfo a, TeamPlayerInfo b) { return (int)b.Damage - (int)a.Damage; });

            List<Unit> allPlayer = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            for (int i = 0; i < allPlayer.Count; i++)
            {
                self.M2C_SyncMiJingDamage.DamageList.Clear();
                self.M2C_SyncMiJingDamage.DamageList.AddRange(self.PlayerDamageList.Take(5));
                MapMessageHelper.SendToClient(allPlayer[i], self.M2C_SyncMiJingDamage);
            }
        }
    }
}
