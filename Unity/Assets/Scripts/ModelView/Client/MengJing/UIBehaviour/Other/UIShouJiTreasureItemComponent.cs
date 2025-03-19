using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIShouJiTreasureItemComponent: Entity, IAwake<GameObject>
    {
        public GameObject RedDot;
        public GameObject TextNumber;
        public GameObject TextAttribute;
        public GameObject ButtonActive;
        public GameObject ImageActived;
        public GameObject ES_CommonItem;
        public GameObject GameObject;
        public GameObject Label_StarNum;
        public GameObject ImageQuality;

        public int ShoujiId;
        public ES_CommonItem UIItemComponent { get; set; }
    }
}