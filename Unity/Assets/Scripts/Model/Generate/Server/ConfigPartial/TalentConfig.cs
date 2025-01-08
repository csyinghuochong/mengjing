using System.Collections.Generic;

namespace ET
{
    public partial class TalentConfigCategory
    {

        public Dictionary<int,  List<int>> TalentPositionList = new Dictionary<int, List<int>>();

        public override void EndInit()
        {
            foreach (TalentConfig talentConfig in this.GetAll().Values)
            {
                int key = talentConfig.Occ * 100 + talentConfig.TalentType;

                if (!TalentPositionList.ContainsKey(key))
                {
                    TalentPositionList.Add(key, new List<int>());
                }
                
                TalentPositionList[key].Add(talentConfig.Id);
            }
        }


        public List<int> GetTalentListByOcc(int occ, int talentType)
        {
            int key = occ * 100 + talentType;
            List<int> talantlist = null;
            TalentPositionList.TryGetValue(key, out talantlist);
            return talantlist;
        }

        public int GetTalentIdByPosition(int occ, int talentType, int position)
        {
            List<int> talantlist = GetTalentListByOcc(occ, talentType);
            foreach (int id in talantlist)
            {
                if (this.Get(id).Position == position)
                {
                    return id;
                }
            }
            return 0;
        }
    }
}