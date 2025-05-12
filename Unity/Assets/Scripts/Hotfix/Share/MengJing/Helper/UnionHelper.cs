using System.Collections.Generic;

namespace ET
{
    public static class UnionHelper
    {
        
        public static int CalcuNeedeForAccele(long startTime, long needTime)
        {
            int g = GlobalValueConfigCategory.Instance.AcceleKeJiCostDiamond;
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


        public static int GetXiuLianId(int postion, int type)
        {
            int numerType = 0;
            switch (type)
            {
                // 角色修炼
                case 0:
                    switch (postion)
                    {
                        case 0:
                            numerType = NumericType.UnionXiuLian_0;
                            break;
                        case 1:
                            numerType = NumericType.UnionXiuLian_1;
                            break;
                        case 2:
                            numerType = NumericType.UnionXiuLian_2;
                            break;
                        case 3:
                            numerType = NumericType.UnionXiuLian_3;
                            break;
                        default:
                            break;
                    }

                    break;
                // 宠物修炼
                case 1:
                    switch (postion)
                    {
                        case 0:
                            numerType = NumericType.UnionPetXiuLian_0;
                            break;
                        case 1:
                            numerType = NumericType.UnionPetXiuLian_1;
                            break;
                        case 2:
                            numerType = NumericType.UnionPetXiuLian_2;
                            break;
                        case 3:
                            numerType = NumericType.UnionPetXiuLian_3;
                            break;
                        default:
                            break;
                    }

                    break;
            }

            return numerType;
        }
    }
}