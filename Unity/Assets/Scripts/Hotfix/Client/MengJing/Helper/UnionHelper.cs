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

        public static int CalcuNeedeForAccele(long startTime, long needTime)
        {
            int g = GlobalValueConfigCategory.Instance.Get(105).Value2;
            long passTime = (TimeHelper.ServerNow() - startTime) / 1000;
            long remainTime = needTime - passTime;
            if (remainTime <= 0)
            {
                return 0;
            }

            if (remainTime % 3600 != 0)
            {
                return (int)((remainTime / 3600 + 1) * g);
            }
            else
            {
                return (int)(remainTime / 3600 * g);
            }
        }
    }
}