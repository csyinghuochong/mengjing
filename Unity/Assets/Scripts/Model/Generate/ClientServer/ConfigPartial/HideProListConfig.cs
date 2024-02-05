using System.Collections.Generic;

namespace ET

{
    public partial class HideProListConfigCategory
    {

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, int> PetSkillToHideProId = new Dictionary<int, int>();

        public override void EndInit()
        {
            int petinitSkill = 2001;
            while (petinitSkill != 0)
            {
                HideProListConfig hideProListConfig = Get(petinitSkill);
                PetSkillToHideProId.Add(hideProListConfig.PropertyType, hideProListConfig.Id);
                petinitSkill = hideProListConfig.NtxtID;
            }
        }
    }
}
