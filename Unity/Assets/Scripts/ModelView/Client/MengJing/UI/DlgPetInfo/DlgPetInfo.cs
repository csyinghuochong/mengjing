using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetInfo : Entity, IAwake, IUILogic
    {
        public DlgPetInfoViewComponent View { get => this.GetComponent<DlgPetInfoViewComponent>(); }

        public GameObject[] PetHeXinItemList;
        public GameObject[] PetZiZhiItemList = new GameObject[6];
        public long ClickTime;
        public bool IsChange;
        public int PetHeXinSuit;
        public int PetSkinId;
        public RolePetInfo LastSelectItem;
        public Dictionary<int, EntityRef<Scroll_Item_PetSkinIconItem>> ScrollItemPetSkinIconItems;
        public int[] ShowPetSkins;
        public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
        public List<int> ShowPetSkills = new();
        public int UnactiveId;
        public int UnactiveNum;

        public int Position;
        public int Type;
        public BagInfo BagInfo;

        public bool IsHoldDown;
        public List<int> PointList = new();
        public List<int> PointInit = new();
        public int PointRemain = 0;
        
        public List<BagInfo> PetHeXinList = new List<BagInfo>();
        public List<int> Keys = new List<int>();
        public List<long> Values = new List<long>();
    }
}