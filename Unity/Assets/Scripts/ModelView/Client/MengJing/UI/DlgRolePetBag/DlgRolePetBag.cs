using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRolePetBag: Entity, IAwake, IUILogic
    {
        public DlgRolePetBagViewComponent View
        {
            get => this.GetComponent<DlgRolePetBagViewComponent>();
        }

        public GameObject[] PetZiZhiItemList = new GameObject[6];
        public RolePetInfo RolePetInfo;
        public List<RolePetInfo> ShowRolePetInfos = new();
        public Dictionary<int, Scroll_Item_PetTuJianItem> ScrollItemPetTuJianItems;
        public Dictionary<int, Scroll_Item_CommonSkillItem> ScrollItemCommonSkillItems;
    }
}