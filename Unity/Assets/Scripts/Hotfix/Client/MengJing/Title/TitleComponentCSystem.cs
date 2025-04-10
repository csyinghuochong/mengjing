namespace ET.Client
{
    [FriendOf(typeof (TitleComponentC))]
    [EntitySystemOf(typeof (TitleComponentC))]
    public static partial class TitleComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this TitleComponentC self)
        {
        }

        public static bool IsHaveTitle(this TitleComponentC self, int titleId)
        {
            for (int i = 0; i < self.TitleList.Count; i++)
            {
                if (self.TitleList[i].KeyId == titleId)
                {
                    return true;
                }
            }

            return false;
        }
        
        public static void OnActiveTile(this TitleComponentC self, int titleId)
        {
            for (int i = self.TitleList.Count - 1; i >= 0; i--)
            {
                if (self.TitleList[i].KeyId == titleId)
                {
                    self.TitleList.RemoveAt(i);
                }
            }

            TitleConfig titleConfig = TitleConfigCategory.Instance.Get(titleId);
            long endTime = titleConfig.ValidityTime == -1 ? -1 : TimeHelper.ServerNow() + titleConfig.ValidityTime * 1000;
            self.TitleList.Add(new KeyValuePairInt() { KeyId = titleId, Value = endTime });
        }
    }
}