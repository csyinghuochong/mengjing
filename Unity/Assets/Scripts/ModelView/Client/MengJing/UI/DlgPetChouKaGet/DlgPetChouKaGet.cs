using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetChouKaGet : Entity, IAwake, IUILogic
    {
        public DlgPetChouKaGetViewComponent View
        {
            get => this.GetComponent<DlgPetChouKaGetViewComponent>();
        }

        public GameObject[] PetZiZhiItemList = new GameObject[6];
        public GameObject[] PetZiZhiItemAddList = new GameObject[6];

        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;

        public RolePetInfo RolePetInfo;
        public RolePetInfo OldRolePetInfo;
    }
}