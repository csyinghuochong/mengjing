namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    [EntitySystemOf(typeof (UserInfoComponentClient))]
    public static partial class UserInfoComponentClientSystem
    {
        [EntitySystem]
        private static void Awake(this UserInfoComponentClient self)
        {
        }

        public static int GetUserLv(this UserInfoComponentClient self)
        {
            return self.UserInfo.Lv;
        }

        public static int GetDayItemUse(this UserInfoComponentClient self, int mysteryId)
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

        public static void OnDayItemUse(this UserInfoComponentClient self, int itemId)
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

        public static long GetSceneFubenTimes(this UserInfoComponentClient self, int sceneId)
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

        public static void AddSceneFubenTimes(this UserInfoComponentClient self, int sceneId)
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
    }
}