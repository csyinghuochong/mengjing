using System.Collections.Generic;

namespace ET
{
    public partial class TalentConfigCategory
    {

        public Dictionary<int,  Dictionary<int, List<int>>> TalentPositionList = new Dictionary<int, Dictionary<int, List<int>>>();

        public override void EndInit()
        {
            foreach (TalentConfig talentConfig in this.GetAll().Values)
            {
                int key = talentConfig.Occ * 100 + talentConfig.TalentType;

                if (!TalentPositionList.ContainsKey(key))
                {
                    TalentPositionList.Add(key, new Dictionary<int, List<int>>());
                }

                if (!TalentPositionList[key].ContainsKey(talentConfig.Position))
                {
                    TalentPositionList[key].Add(talentConfig.Position, new List<int>());
                }
                
                TalentPositionList[key][talentConfig.Position].Add(talentConfig.Id);
            }
        }


        public Dictionary<int, List<int>> GetTalentListByOcc(int occ, int talentType)
        {
            int key = occ * 100 + talentType;
            Dictionary<int, List<int>> talantlist = null;
            TalentPositionList.TryGetValue(key, out talantlist);
            return talantlist;
        }

        public List<int> GetTalentIdByPosition(int occ, int talentType, int position)
        {
            Dictionary<int, List<int>> talantlist = GetTalentListByOcc(occ, talentType);
            List<int> positionlist = null;
            talantlist.TryGetValue(position, out positionlist);
            return positionlist;
        }
    }
}