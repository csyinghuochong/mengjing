using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static class TalentHelpter
    {
        public static int GetFirstTalent(int occ, int talentType)
        {
            return TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, 1);
        }

        public static int GetTalentIdByPosition(int postion, List<KeyValuePairInt> oldtalentlist)
        {
            for (int i = 0; i < oldtalentlist.Count; i++)
            {
                if (TalentConfigCategory.Instance.Get(oldtalentlist[i].KeyId).Position == postion)
                {
                    return oldtalentlist[i].KeyId;
                }
            }

            return 0;
        }

        public static int UsedTalentPoint(List<KeyValuePairInt> oldtalentlist)
        {
            int usedPoint = 0;
            foreach (KeyValuePairInt keyValuePairInt in oldtalentlist)
            {
                TalentConfig talentConfig = TalentConfigCategory.Instance.Get(keyValuePairInt.KeyId);
                usedPoint += talentConfig.NeedUseNumber * (int)keyValuePairInt.Value;
            }

            return usedPoint;
        }

        /// <summary>
        /// 激活对应位置的天赋。  
        /// </summary>
        public static int OnTalentActive(int occ, int talentType, int postion, List<KeyValuePairInt> oldtalentlist, int lv, int talentPoints)
        {
            int talentid = TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, postion);
            if (talentid == 0)
            {
                return ErrorCode.ERR_ModifyData;
            }

            int curlv = 0;
            foreach (KeyValuePairInt keyValuePairInt in oldtalentlist)
            {
                if (talentid == keyValuePairInt.KeyId)
                {
                    curlv = (int)keyValuePairInt.Value;
                }
            }

            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(talentid);
            int maxlv = talentConfig.Lv;

            if (curlv >= maxlv)
            {
                return ErrorCode.ERR_AlreadyLearn;
            }

            // 前置都要激活
            // foreach (int id in talentConfig.PreId)
            // {
            //     if (id != 0 && !oldtalentlist.Contains(id))
            //     {
            //         return ErrorCode.ERR_TalentNotActivePreId;
            //     }
            // }

            // 前置只需激活一个
            bool havePre = false;
            foreach (int id in talentConfig.PreId)
            {
                if (id == 0)
                {
                    havePre = true;
                    break;
                }

                if (oldtalentlist.Any(keyValuePairInt => keyValuePairInt.KeyId == id))
                {
                    havePre = true;
                }
            }

            if (!havePre)
            {
                return ErrorCode.ERR_TalentNotActivePreId;
            }

            // 检查等级
            if (lv < talentConfig.LearnRoseLv)
            {
                return ErrorCode.ERR_LvNoHigh;
            }

            // 检查天赋点
            if (talentPoints < UsedTalentPoint(oldtalentlist) + talentConfig.NeedUseNumber)
            {
                return ErrorCode.ERR_TalentPointNot;
            }

            return ErrorCode.ERR_Success;
        }
    }
}