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
    }
}