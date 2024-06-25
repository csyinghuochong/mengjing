namespace ET.Client
{
    [FriendOf(typeof (TeamComponentC))]
    [EntitySystemOf(typeof (TeamComponentC))]
    public static partial class TeamComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this TeamComponentC self)
        {
        }

        public static TeamInfo GetSelfTeam(this TeamComponentC self)
        {
            long userId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;

            for (int i = 0; i < self.TeamList.Count; i++)
            {
                TeamInfo teamInfo = self.TeamList[i];
                for (int k = 0; k < teamInfo.PlayerList.Count; k++)
                {
                    if (teamInfo.PlayerList[k].UserID == userId)
                    {
                        return teamInfo;
                    }
                }
            }

            return null;
        }
    }
}