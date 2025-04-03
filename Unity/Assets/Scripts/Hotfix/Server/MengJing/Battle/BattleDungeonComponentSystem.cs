using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (BattleDungeonComponent))]
    [FriendOf(typeof (BattleDungeonComponent))]
    public static partial class BattleDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BattleDungeonComponent self)
        {
            self.CampKillNumber_1 = 0;
            self.CampKillNumber_2 = 0;
            self.SendReward = false;
        }

        public static void OnKillEvent(this BattleDungeonComponent self, Unit defend, Unit attack)
        {
            if (defend.Type != UnitType.Player)
            {
                return;
            }

            if (defend.GetBattleCamp() == CampEnum.CampPlayer_1)
            {
                self.CampKillNumber_2++;
            }
            else
            {
                self.CampKillNumber_1++;
            }

            List<EntityRef<Unit>> units = self.Scene().GetComponent<UnitComponent>().GetAll();
            M2C_BattleInfoResult m2C_Battle = self.m2C_BattleInfoResult;
            m2C_Battle.SceneType = MapTypeEnum.Battle;
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.Type != UnitType.Player)
                {
                    continue;
                }

                m2C_Battle.CampKill_1 = self.CampKillNumber_1;
                m2C_Battle.CampKill_2 = self.CampKillNumber_2;
                MapMessageHelper.SendToClient(units[i], m2C_Battle);
            }

            if (attack != null && attack.Type == UnitType.Player)
            {
                attack.GetComponent<NumericComponentS>().ApplyChange(NumericType.BattleTodayKill, 1);
            }
        }

        public static void SendReward(this BattleDungeonComponent self, List<long> Camp1Player, List<long> Camp2Player)
        {
            if (self.SendReward)
            {
                return;
            }

            self.SendReward = true;
            int winCamp = 1;
            if (self.CampKillNumber_1 > self.CampKillNumber_2)
            {
                winCamp = CampEnum.CampPlayer_1;
            }

            if (self.CampKillNumber_2 > self.CampKillNumber_1)
            {
                winCamp = CampEnum.CampPlayer_2;
            }

            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(56);
            List<long> winPlayers = winCamp == 1? Camp1Player : Camp2Player;

            long serverTime = TimeHelper.ServerNow();
            for (int i = 0; i < winPlayers.Count; i++)
            {
                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Status = 0;
                mailInfo.Context = "战场奖励";
                mailInfo.Title = "战场奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();
                string[] needList = globalValueConfig.Value.Split('@');
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
                    BagInfo.GetWay = $"{ItemGetWay.BattleWin}_{serverTime}";
                    mailInfo.ItemList.Add(BagInfo);
                }

                Unit unit = self.Scene().GetComponent<UnitComponent>().Get(winPlayers[i]);
                if (unit != null)
                {
                    unit.GetComponent<TaskComponentS>().OnWinCampBattle();
                }

                if (unit != null && unit.IsRobot())
                {
                    continue;
                }

                ServerLogHelper.LogWarning($"发送战场奖励: {self.Zone()} {winPlayers[i]}", true);
                MailHelp.SendUserMail(self.Root(), winPlayers[i], mailInfo,ItemGetWay.BattleWin).Coroutine();
            }
        }

        /// <summary>
        /// 踢出还在副本的玩家
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask KickOutPlayer(this BattleDungeonComponent self)
        {
            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;

            List<EntityRef<Unit>> units = self.Scene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uniitem = units[i];
                if (uniitem.Type != UnitType.Player)
                {
                    continue;
                }

                if (uniitem.IsDisposed || uniitem.IsRobot())
                {
                    continue;
                }

                await TransferHelper.TransferUnit(units[i], actor_Transfer);
            }

            await ETTask.CompletedTask;
        }

        public static void OnBattleOver(this BattleDungeonComponent self, List<long> Camp1Player, List<long> Camp2Player)
        {
            self.SendReward(Camp1Player, Camp2Player);
        }
    }
}