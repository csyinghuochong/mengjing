using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetXiLianLockSkill : Entity, IAwake, IUILogic
    {
        public DlgPetXiLianLockSkillViewComponent View { get => this.GetComponent<DlgPetXiLianLockSkillViewComponent>(); }

        public RolePetInfo RolePetInfo;
        public BagInfo CostItemInfo;
        public int SkillId;
        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
        public List<int> ShowPetSkills = new();
    }
}