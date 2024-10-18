using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetXiLianLockSkill : Entity, IAwake, IUILogic
    {
        public DlgPetXiLianLockSkillViewComponent View { get => this.GetComponent<DlgPetXiLianLockSkillViewComponent>(); }

        public RolePetInfo RolePetInfo;
        private EntityRef<ItemInfo> costItemInfo;
        public ItemInfo CostItemInfo { get => this.costItemInfo; set => this.costItemInfo = value; }
        public int SkillId;
        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
        public List<int> ShowPetSkills = new();
    }
}