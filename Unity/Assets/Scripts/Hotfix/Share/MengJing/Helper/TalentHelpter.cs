using System.Collections.Generic;

namespace ET
{
    
    public static class TalentHelpter
    {


        public static int GetFirstTalent(int occ, int talentType)
        {
            List<int> talentConfigs = TalentConfigCategory.Instance.GetTalentIdByPosition(occ, talentType, 1);

            return talentConfigs.Count > 0 ? talentConfigs[0]: 0;
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

        public static int GetTalentIdByPosition(int postion,  List<int> oldtalentlist)
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

        /// <summary>
        /// 替换对应位置的天赋。  
        /// </summary>
        public static int OnTalentActive(int occ, int talentType, int postion,  List<int> oldtalentlist)
        {
            int talentid = GetTalentIdByPosition(postion, oldtalentlist);
            int curlv = GetTalentCurLevel(occ, talentType, postion, talentid);
            int maxlv = GetTalentMaxLevel(occ, talentType, postion);

            if (curlv >= maxlv)
            {
                return ErrorCode.ERR_AlreadyLearn;
            }

            int nextid = GetTalentNextId(occ, talentType, postion, talentid);
            if (nextid == 0)
            {
                return ErrorCode.ERR_AlreadyLearn;
            }
            
            oldtalentlist.Remove(talentid);
            oldtalentlist.Add(nextid);
            return ErrorCode.ERR_Success;
        }
    }
    
    
}