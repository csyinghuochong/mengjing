using System.Collections.Generic;

namespace ET.Client
{
    public enum PetOperationType
    {
        HeCheng = 1,
        XiLian = 2,
        UpStar_Main = 3,
        UpStar_FuZh = 4,
        RankPet_Team = 5,
        XianJi = 6,
        JiaYuan_Walk = 7,
        PetEcho = 8,
    }

    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetSelect: Entity, IAwake, IUILogic
    {
        public DlgPetSelectViewComponent View
        {
            get => this.GetComponent<DlgPetSelectViewComponent>();
        }

        public PetOperationType OperationType;
        public Dictionary<int, EntityRef<Scroll_Item_PetSelectItem>> ScrollItemPetSelectItems;
        public List<RolePetInfo> ShowRolePetInfos = new();
    }
}