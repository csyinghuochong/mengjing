using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentC))]
    [EntitySystemOf(typeof (UserInfoComponentC))]
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
            return ServerHelper.DateDiff_Time(TimeHelper.ServerNow(), self.UserInfo.CreateTime);
        }
    }
}