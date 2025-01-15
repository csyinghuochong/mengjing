using System;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIPetTuJianItem: Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject E_Image_ItemButton;
        public GameObject E_Image_EventTrigger;
        public GameObject E_Image_ItemQuality;
        public GameObject E_Image_XuanZhong;
        public GameObject E_Image_ItemIcon;
        public GameObject E_Label_ItemNum;
        public GameObject E_Label_ItemName_Active;
        public GameObject E_Label_ItemName_InActive;
        public GameObject E_Label_Active;
        public GameObject E_Label_InActive;
        public int PetId;
        public Action<int> ClickHandler;
    }
}