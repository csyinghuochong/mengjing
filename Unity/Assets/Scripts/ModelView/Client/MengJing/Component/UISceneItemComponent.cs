using UnityEngine;

namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class UISceneItemComponent: Entity, IAwake, IDestroy
    {
        public GameObject HeadBar;
        public Camera UICamera;
        public Camera MainCamera;
        public Transform UIPosition;
        public HeadBarUI HeadBarUI;

        public GameObject GameObject;
        public string HeadBarPath;
    }
}