using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIShouJiItemComponent: Entity, IAwake<GameObject>
    {
        public GameObject Label_HaveTag;
        public GameObject Label_StarNum;
        public GameObject GameObject;
        public GameObject Label_ItemName;
        public GameObject Image_ItemIcon;
        public GameObject Image_ItemQuality;
    }
}