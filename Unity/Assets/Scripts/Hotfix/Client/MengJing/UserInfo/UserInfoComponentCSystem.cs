using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(UserInfoComponentC))]
    public static partial class UserInfoComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this UserInfoComponentC self)
        {
        }

        public static int GetUserLv(this UserInfoComponentC self)
        {
            return self.UserInfo.Lv;
        }

        public static int GetDayItemUse(this UserInfoComponentC self, int mysteryId)
        {
            for (int i = 0; i < self.UserInfo.DayItemUse.Count; i++)
            {
                if (self.UserInfo.DayItemUse[i].KeyId == mysteryId)
                {
                    return (int)self.UserInfo.DayItemUse[i].Value;
                }
            }

            return 0;
        }

        public static void OnDayItemUse(this UserInfoComponentC self, int itemId)
        {
            for (int i = 0; i < self.UserInfo.DayItemUse.Count; i++)
            {
                if (self.UserInfo.DayItemUse[i].KeyId == itemId)
                {
                    self.UserInfo.DayItemUse[i].Value += 1;
                    return;
                }
            }

            self.UserInfo.DayItemUse.Add(new KeyValuePairInt() { KeyId = itemId, Value = 1 });
        }

        public static long GetSceneFubenTimes(this UserInfoComponentC self, int sceneId)
        {
            for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
            {
                if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                {
                    return self.UserInfo.DayFubenTimes[i].Value;
                }
            }

            return 0;
        }

        public static void AddSceneFubenTimes(this UserInfoComponentC self, int sceneId)
        {
            for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
            {
                if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                {
                    self.UserInfo.DayFubenTimes[i].Value++;
                    return;
                }
            }

            self.UserInfo.DayFubenTimes.Add(new KeyValuePairInt() { KeyId = sceneId, Value = 1 });
        }

        public static long GetMakeTime(this UserInfoComponentC self, int makeId)
        {
            List<KeyValuePairInt> makeList = self.UserInfo.MakeIdList;
            for (int i = 0; i < makeList.Count; i++)
            {
                if (makeList[i].KeyId == makeId)
                {
                    return makeList[i].Value;
                }
            }

            return 0;
        }

        public static void OnMakeItem(this UserInfoComponentC self, int makeId)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeId);
            List<KeyValuePairInt> makeList = self.UserInfo.MakeIdList;

            bool have = false;
            long endTime = TimeHelper.ServerNow() + equipMakeConfig.MakeTime * 1000;
            for (int i = 0; i < makeList.Count; i++)
            {
                if (makeList[i].KeyId == makeId)
                {
                    makeList[i].Value = endTime;
                    have = true;
                }
            }

            if (!have)
            {
                self.UserInfo.MakeIdList.Add(new KeyValuePairInt() { KeyId = makeId, Value = endTime });
            }
        }

        public static string GetGameSettingValue(this UserInfoComponentC self, GameSettingEnum gameSettingEnum)
        {
            for (int i = 0; i < self.UserInfo.GameSettingInfos.Count; i++)
            {
                if (self.UserInfo.GameSettingInfos[i].KeyId == (int)gameSettingEnum)
                    return self.UserInfo.GameSettingInfos[i].Value;
            }

            return self.GetDefaultGameSettingValue(gameSettingEnum);
        }

        public static string GetDefaultGameSettingValue(this UserInfoComponentC self, GameSettingEnum gameSettingEnum)
        {
            switch (gameSettingEnum)
            {
                case GameSettingEnum.Music:
                    return "1";
                case GameSettingEnum.Sound:
                    return "0";
                case GameSettingEnum.YanGan: //0 固定 1移动
                    return "0";
                case GameSettingEnum.FenBianlLv:
                    return "1";
                case GameSettingEnum.OneSellSet:
                    return "1@0@0@0";
                case GameSettingEnum.OneSellSet2:
                    return "0@0@0@0@0@0";
                case GameSettingEnum.HighFps:
                    return "1";
                case GameSettingEnum.AutoAttack:
                    return "1";
                case GameSettingEnum.GuaJiAutoUseSkill:
                    return "";
                case GameSettingEnum.HideLeftBottom:
                    return "0";
                case GameSettingEnum.SkillAttackPlayerFirst:
                    return "0";
                case GameSettingEnum.PickSet:
                    return "0@0";
                case GameSettingEnum.Shadow:
                    return "1";
                default:
                    return "0";
            }
        }

        public static void OnStoreBuy(this UserInfoComponentC self, int mysteryId)
        {
            for (int i = 0; i < self.UserInfo.BuyStoreItems.Count; i++)
            {
                if (self.UserInfo.BuyStoreItems[i].KeyId == mysteryId)
                {
                    self.UserInfo.BuyStoreItems[i].Value += 1;
                    return;
                }
            }

            self.UserInfo.BuyStoreItems.Add(new KeyValuePairInt() { KeyId = mysteryId, Value = 1 });
        }

        public static void ClearFubenTimes(this UserInfoComponentC self, int sceneId)
        {
            for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
            {
                if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                {
                    self.UserInfo.DayFubenTimes[i].Value = 0;
                    break;
                }
            }
        }

        public static int GetCreateDay(this UserInfoComponentC self)
        {
            return TimeHelper.DateDiff_Time(TimeHelper.ServerNow(), self.UserInfo.CreateTime);
        }

        public static void UpdateGameSetting(this UserInfoComponentC self, List<KeyValuePair> gameSettingInfos)
        {
            for (int i = 0; i < gameSettingInfos.Count; i++)
            {
                bool exist = false;
                for (int k = 0; k < self.UserInfo.GameSettingInfos.Count; k++)
                {
                    if (self.UserInfo.GameSettingInfos[k].KeyId == gameSettingInfos[i].KeyId)
                    {
                        exist = true;
                        self.UserInfo.GameSettingInfos[k].Value = gameSettingInfos[i].Value;
                        break;
                    }
                }

                if (!exist)
                {
                    self.UserInfo.GameSettingInfos.Add(gameSettingInfos[i]);
                }
            }
        }

        /// <summary>
        /// 角色创建天数  从1 开始
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int GetCrateDay(this UserInfoComponentC self)
        {
            return TimeHelper.DateDiff_Time(TimeHelper.ServerNow(), self.UserInfo.CreateTime);
        }

        public static bool IsHaveFristWinReward(this UserInfoComponentC self, int firstwinid, int difficulty)
        {
            for (int i = 0; i < self.UserInfo.FirstWinSelf.Count; i++)
            {
                KeyValuePair keyValuePair = self.UserInfo.FirstWinSelf[i];
                if (keyValuePair.KeyId != firstwinid)
                {
                    continue;
                }

                return keyValuePair.Value.Contains(difficulty.ToString()) && !keyValuePair.Value2.Contains(difficulty.ToString());
            }

            return false;
        }

        public static bool IsReceivedFristWinReward(this UserInfoComponentC self, int firstwinid, int difficulty)
        {
            for (int i = 0; i < self.UserInfo.FirstWinSelf.Count; i++)
            {
                if (self.UserInfo.FirstWinSelf[i].KeyId != firstwinid)
                {
                    continue;
                }

                return self.UserInfo.FirstWinSelf[i].Value2.Contains(difficulty.ToString());
            }

            return false;
        }

        public static long GetReviveTime(this UserInfoComponentC self, int monsterId)
        {
            for (int i = 0; i < self.UserInfo.MonsterRevives.Count; i++)
            {
                if (self.UserInfo.MonsterRevives[i].KeyId == monsterId)
                {
                    return long.Parse(self.UserInfo.MonsterRevives[i].Value);
                }
            }

            return 0;
        }

        public static int GetMonsterKillNumber(this UserInfoComponentC self, int monsterId)
        {
            for (int i = 0; i < self.UserInfo.MonsterRevives.Count; i++)
            {
                KeyValuePair keyValuePair = self.UserInfo.MonsterRevives[i];
                if (keyValuePair.KeyId != monsterId)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(keyValuePair.Value2))
                {
                    return int.Parse(keyValuePair.Value2);
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }

        public static void AddFubenTimes(this UserInfoComponentC self, int sceneId, int times)
        {
            for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
            {
                if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                {
                    long curTimes = self.UserInfo.DayFubenTimes[i].Value -= times;
                    if (curTimes < 0)
                    {
                        curTimes = 0;
                    }

                    self.UserInfo.DayFubenTimes[i].Value = curTimes;
                    break;
                }
            }
        }

        public static void ClearDayData(this UserInfoComponentC self)
        {
            self.UserInfo.DayFubenTimes.Clear();
            self.UserInfo.ChouKaRewardIds.Clear();
            self.UserInfo.MysteryItems.Clear();
            self.UserInfo.BuyStoreItems.Clear();
            self.UserInfo.BuyStoreItems.Clear();
            self.UserInfo.DayItemUse.Clear();
            self.UserInfo.DayMonsters.Clear();
            self.UserInfo.DayJingLing.Clear();
            self.UserInfo.PetExploreRewardIds.Clear();
            self.UserInfo.PetHeXinExploreRewardIds.Clear();
            self.UserInfo.ItemXiLianNumRewardIds.Clear();
        }

        public static void OnHorseActive(this UserInfoComponentC self, int horseId, bool active)
        {
            if (active && !self.UserInfo.HorseIds.Contains(horseId))
            {
                self.UserInfo.HorseIds.Add(horseId);
            }

            if (!active && self.UserInfo.HorseIds.Contains(horseId))
            {
                self.UserInfo.HorseIds.Remove(horseId);
            }
        }
        
        public static FubenPassInfo GetPassInfoByID(this UserInfoComponentC self, int levelid)
        {
            for (int i = 0; i < self.UserInfo.FubenPassList.Count; i++)
            {
                if (self.UserInfo.FubenPassList[i].FubenId == levelid)
                {
                    return self.UserInfo.FubenPassList[i];
                }
            }
            return null;
        }
        
        public static bool IsLevelPassed(this UserInfoComponentC self, int levelid)
        {
            for (int i = 0; i < self.UserInfo.FubenPassList.Count; i++)
            {
                if (self.UserInfo.FubenPassList[i].FubenId == levelid)
                {
                    return true;
                }
            }
            return false;
        }

        public static void OnResetSeason(this UserInfoComponentC self, bool notice)
        {
            self.UserInfo.SeasonLevel = 1;
            self.UserInfo.SeasonExp = 0;
            self.UserInfo.SeasonCoin = 0;
            self.UserInfo.OpenJingHeIds.Clear();
            self.UserInfo.SeasonDonateRewardIds.Clear();
        }
    }
}