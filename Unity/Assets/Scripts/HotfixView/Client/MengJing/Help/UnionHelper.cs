using System.Collections.Generic;

namespace ET.Client
{
    public static class UnionHelper
    {
        public static UnionPlayerInfo GetUnionPlayerInfo(List<UnionPlayerInfo> playerInfos, long unitid)
        {
            for (int i = 0; i < playerInfos.Count; i++)
            {
                if (playerInfos[i].UserID == unitid)
                {
                    return playerInfos[i];
                }
            }

            return null;
        }
    }
}