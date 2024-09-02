using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (DemonDungeonComponent))]
    [FriendOf(typeof (DemonDungeonComponent))]
    public static partial class DemonDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this DemonDungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this DemonDungeonComponent self)
        {
        }

        public static void OnBegin(this DemonDungeonComponent self)
        {
            self.IsOver = false;
            if (self.Zone() == 5)
            {
                G2Robot_MessageRequest G2Robot_MessageRequest = G2Robot_MessageRequest.Create();
                G2Robot_MessageRequest.Zone = self.Zone();
                G2Robot_MessageRequest.MessageType = NoticeType.Demon;
                G2Robot_MessageRequest.Message = string.Empty;
                ActorId robotSceneId = UnitCacheHelper.GetRobotServerId();
                self.Root().GetComponent<MessageSender>().Send(robotSceneId,G2Robot_MessageRequest);
            }
        }

        public static void OnClose(this DemonDungeonComponent self)
        {
            List<Unit> destlist = new List<Unit>();
            List<Unit> sourcelist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);

            ///开始后会根据当前场景的人数随机生成X个 恶魔
            int demonNumber = sourcelist.Count - 1;

            RandomHelper.GetRandListByCount(sourcelist, destlist, demonNumber);

            for (int i = 0; i < destlist.Count; i++)
            {
                destlist[i].GetComponent<NumericComponentS>().ApplyValue(NumericType.BattleCamp, CampEnum.CampPlayer_2);
                destlist[i].GetComponent<NumericComponentS>().ApplyValue(NumericType.RunRaceTransform, 90000017);
                Function_Fight.UnitUpdateProperty_DemonBig(destlist[i], true);
            }

        }

        public static void SendCampReward(this DemonDungeonComponent self, int campId, int rewardId)
        {
            MailInfo mailInfo = MailInfo.Create();
            string rewardTime = rewardId == 100? "胜利" : "参与";
            mailInfo.Status = 0;
            mailInfo.Title = "恶魔活动奖励";
            mailInfo.Context = $"恶魔活动{rewardTime}奖励";
            mailInfo.MailId = IdGenerater.Instance.GenerateId();

            GlobalValueConfig globalValue = GlobalValueConfigCategory.Instance.Get(rewardId);
            string[] rewardList = globalValue.Value.Split('@');
            for (int i = 0; i < rewardList.Length; i++)
            {
                string[] rewardItem = rewardList[i].Split(';');
                ItemInfoProto BagInfo = ItemInfoProto.Create();
                BagInfo.ItemID = int.Parse(rewardItem[0]);
                BagInfo.ItemNum = int.Parse(rewardItem[1]);
                mailInfo.ItemList.Add(BagInfo);
            }

            List<Unit> sourcelist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            for (int i = 0; i < sourcelist.Count; i++)
            {
                if (campId != sourcelist[i].GetComponent<NumericComponentS>().GetAsInt(NumericType.BattleCamp))
                {
                    continue;
                }

                MailHelp.SendUserMail(self.Root(), sourcelist[i].Id, mailInfo, ItemGetWay.PaiMaiBuy).Coroutine();
            }
        }

        public static async ETTask SendRankReward(this DemonDungeonComponent self)
        {
            //1059
            ActorId rankserverid = UnitCacheHelper.GetRankServerId(self.Zone());
            ////恶魔结束. 发送奖励
            A2A_ActivityUpdateRequest A2A_ActivityUpdateRequest = A2A_ActivityUpdateRequest.Create();
            A2A_ActivityUpdateRequest.Hour = -1;
            A2A_ActivityUpdateRequest.FunctionId = 1059;
            A2A_ActivityUpdateRequest.FunctionType = 2;
            A2A_ActivityUpdateResponse m2m_TrasferUnitResponse =
                    (A2A_ActivityUpdateResponse)await self.Root().GetComponent<MessageSender>().Call(rankserverid,A2A_ActivityUpdateRequest);
        }

        public static async ETTask OnUpdateScore(this DemonDungeonComponent self, Unit unit, int score)
        {
            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            RankingInfo rankPetInfo = RankingInfo.Create();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            rankPetInfo.UserId = userInfoComponent.UserInfo.UserId;
            rankPetInfo.PlayerName = userInfoComponent.UserInfo.Name;
            rankPetInfo.PlayerLv = userInfoComponent.UserInfo.Lv;
            rankPetInfo.Occ = userInfoComponent.UserInfo.Occ;
            rankPetInfo.Combat = score;

            M2R_RankDemonRequest M2R_RankDemonRequest = M2R_RankDemonRequest.Create();
            M2R_RankDemonRequest.RankingInfo = rankPetInfo;
            R2M_RankDemonResponse Response =
                    (R2M_RankDemonResponse)await self.Root().GetComponent<MessageSender>().Call(mapInstanceId, M2R_RankDemonRequest);

            //推给客户端
            List<Unit> sourcelist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            self.M2C_RankDemonMessage.RankList = Response.RankList;
            MapMessageHelper.SendToClient(sourcelist, self.M2C_RankDemonMessage);
        }

        public static async ETTask OnKillEvent(this DemonDungeonComponent self, Unit defend, Unit attack)
        {
            //90000017大恶魔   90000018小恶魔   90000019幽灵

            int monsterId = defend.GetComponent<NumericComponentS>().GetAsInt(NumericType.RunRaceTransform);

            //1被恶魔打败的玩家会变成小恶魔,
            if (defend.Type == UnitType.Player && monsterId == 0)
            {
                string attackName = attack.GetComponent<UserInfoComponentS>().UserInfo.Name;
                defend.SetBornPosition(defend.Position, true);
                defend.GetComponent<HeroDataComponentS>().OnRevive();

                defend.GetComponent<NumericComponentS>().ApplyValue(NumericType.BattleCamp, CampEnum.CampPlayer_2);
                defend.GetComponent<NumericComponentS>().ApplyValue(NumericType.RunRaceTransform, 90000018);
                defend.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.DemonName, attackName, true);
                defend.GetComponent<UserInfoComponentS>().UpdateRoleDataBroadcast(UserDataType.DemonName, attackName);
                Function_Fight.UnitUpdateProperty_DemonBig(defend, true);

                await self.OnUpdateScore(attack, 50);
            }

            //如果大恶魔 / 小恶魔被击败将进入幽灵模式,幽灵模式不能放任何技能，其他玩家也玩不见自己,只能移动.  添加一个隐身buff
            if (defend.Type == UnitType.Player && (monsterId == 90000017 || monsterId == 90000018))
            {
                defend.SetBornPosition(defend.Position, true);
                defend.GetComponent<HeroDataComponentS>().OnRevive();
                defend.GetComponent<NumericComponentS>().ApplyValue(NumericType.RunRaceTransform, 90000019);
                Function_Fight.UnitUpdateProperty_DemonGhost(defend, true);
                BuffData buffData_1 = new BuffData();
                buffData_1.SkillId = 67000278;
                buffData_1.BuffId = 99004004;
                defend.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_1, defend, null, true);

                await self.OnUpdateScore(attack, monsterId == 90000017? 500 : 50);
            }

            //玩家或者大恶魔全部死亡，游戏结束
            if (!self.IsOver)
            {
                int playerNumber = 0;
                int demonNumber = 0;
                List<Unit> sourcelist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
                for (int i = 0; i < sourcelist.Count; i++)
                {
                    int transformId = sourcelist[i].GetComponent<NumericComponentS>().GetAsInt(NumericType.RunRaceTransform);
                    if (transformId == 0)
                    {
                        playerNumber++;
                    }

                    if (transformId == 90000017)
                    {
                        demonNumber++;
                    }
                }

                //游戏结束， 发阵营奖励
                if (demonNumber == 0)
                {
                    self.IsOver = true;
                    self.SendCampReward(1, 100);
                    self.SendCampReward(2, 101);
                    self.SendRankReward().Coroutine();
                }

                if (playerNumber == 0)
                {
                    self.IsOver = true;
                    self.SendCampReward(1, 101);
                    self.SendCampReward(2, 100);
                    self.SendRankReward().Coroutine();
                }
            }
        }
    }
}