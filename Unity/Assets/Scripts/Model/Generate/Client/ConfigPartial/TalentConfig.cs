using System.Collections.Generic;

namespace ET
{
    public partial class TalentConfigCategory
    {

        Dictionary<int,  Dictionary<int, List<TalentConfig>>> TalentPositionList = new Dictionary<int, Dictionary<int, List<TalentConfig>>>();

        public override void EndInit()
        {
            foreach (TalentConfig talentConfig in this.GetAll().Values)
            {

            }
        }


        public Dictionary<int, List<TalentConfig>> GetTalentListByOcc(int occ, int talentType)
        {
            int key = occ * 100 + talentType;
            Dictionary<int, List<TalentConfig>> talantlist = null;
            TalentPositionList.TryGetValue(key, out talantlist);
            return talantlist;
        }

        public List<TalentConfig> GetTalentIdByPosition(int occ, int talentType, int position)
        {
            Dictionary<int, List<TalentConfig>> talantlist = GetTalentListByOcc(occ, talentType);
            List<TalentConfig> positionlist = null;
            talantlist.TryGetValue(position, out positionlist);
            return positionlist;
        }
    }
}