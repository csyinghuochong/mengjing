using System.Collections.Generic;

namespace ET
{
    public static class TalentHelpter
    {
        public static int GetFirstTalent(int occ, int talentType)
        {
            List<int> talentConfigs = TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, 1);

            return talentConfigs.Count > 0 ? talentConfigs[0] : 0;
        }

        /// <summary>
        /// /当前等级
        /// </summary>
        /// <param name="occ"></param>
        /// <param name="talentType"></param>
        /// <returns></returns>
        public static int GetTalentCurLevel(int occ, int talentType, int postion, int talentid)
        {
            if (talentid == 0)
            {
                return 0;
            }

            List<int> talentConfigs = TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, postion);
            if (talentConfigs == null)
            {
                return 0;
            }

            return talentConfigs.IndexOf(talentid) + 1;
        }

        public static int GetTalentNextId(int occ, int talentType, int postion, int talentid)
        {
            List<int> talentConfigs = TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, postion);
            if (talentConfigs == null)
            {
                Log.Error($"talentConfigs == null:  {occ}  {talentType}  {postion}");
                return 0;
            }

            if (talentid == 0)
            {
                return talentConfigs[0];
            }

            int index = talentConfigs.IndexOf(talentid);
            if (index < 0)
            {
                Log.Error($"talentConfigs == null:  {occ}  {talentType}  {postion}");
                return 0;
            }

            if (index < talentConfigs.Count - 1)
            {
                return talentConfigs[index + 1];
            }

            return 0;
        }

        public static int GetTalentMaxLevel(int occ, int talentType, int postion)
        {
            List<int> talentConfigs = TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, postion);
            if (talentConfigs == null)
            {
                return 0;
            }

            return talentConfigs.Count;
        }

        public static int GetTalentIdByPosition(int postion, List<int> oldtalentlist)
        {
            for (int i = 0; i < oldtalentlist.Count; i++)
            {
                if (TalentConfigCategory.Instance.Get(oldtalentlist[i]).Position == postion)
                {
                    return oldtalentlist[i];
                }
            }

            return 0;
        }

        public static int UsedTalentPoint(int occ, int talentType, List<int> oldtalentlist)
        {
            int usedPoint = 0;
            foreach (int id in oldtalentlist)
            {
                List<int> ids = TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, TalentConfigCategory.Instance.Get(id).Position);
                for (int i = ids.IndexOf(id); i >= 0; i--)
                {
                    TalentConfig talentConfig = TalentConfigCategory.Instance.Get(ids[i]);
                    usedPoint += talentConfig.NeedUseNumber;
                }
            }

            return usedPoint;
        }

        /// <summary>
        /// 激活对应位置的天赋。  
        /// </summary>
        public static int OnTalentActive(int occ, int talentType, int postion, List<int> oldtalentlist, int talentPoints)
        {
            int talentid = GetTalentIdByPosition(postion, oldtalentlist);
            int curlv = GetTalentCurLevel(occ, talentType, postion, talentid);
            int maxlv = GetTalentMaxLevel(occ, talentType, postion);

            if (curlv >= maxlv)
            {
                return ErrorCode.ERR_AlreadyLearn;
            }

            bool checkPreId = talentid == 0;

            int nextid = GetTalentNextId(occ, talentType, postion, talentid);
            if (nextid == 0)
            {
                return ErrorCode.ERR_AlreadyLearn;
            }

            TalentConfig talentConfig = TalentConfigCategory.Instance.Get(nextid);
            if (checkPreId)
            {
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

                    if (oldtalentlist.Contains(id))
                    {
                        havePre = true;
                        break;
                    }
                }

                if (!havePre)
                {
                    return ErrorCode.ERR_TalentNotActivePreId;
                }
            }

            // 检查天赋点
            if (talentPoints < UsedTalentPoint(occ, talentType, oldtalentlist) + talentConfig.NeedUseNumber)
            {
                return ErrorCode.ERR_TalentPointNot;
            }

            oldtalentlist.Remove(talentid);
            oldtalentlist.Add(nextid);
            return ErrorCode.ERR_Success;
        }
    }
}