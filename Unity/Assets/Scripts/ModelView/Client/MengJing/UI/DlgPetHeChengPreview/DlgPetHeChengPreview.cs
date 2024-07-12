using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetHeChengPreview: Entity, IAwake, IUILogic
    {
        public DlgPetHeChengPreviewViewComponent View
        {
            get => this.GetComponent<DlgPetHeChengPreviewViewComponent>();
        }

        public GameObject[] PetZiZhiItemList = new GameObject[6];
        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems_A;
        public List<int> PetAbaseSkillId = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems_B;
        public List<int> PetBbaseSkillId = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
        public List<int> AllSkillId = new();
    }
}