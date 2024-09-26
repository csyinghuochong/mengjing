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
                return 0;
            }

            if (talentid == 0)
            {
                return talentConfigs[0];
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

        /// <summary>
        /// 替换对应位置的天赋。  
        /// </summary>
        public static void OnTalentActive(int occ, int talentType, int postion, int talentid, List<int> oldtalentlist)
        {
            int curlv = GetTalentCurLevel(occ, talentType, postion, talentid);
            int maxlv = GetTalentMaxLevel(occ, talentType, postion);

            if (curlv >= maxlv)
            {
                return;
            }
            
            
        }
    }
    
    
}