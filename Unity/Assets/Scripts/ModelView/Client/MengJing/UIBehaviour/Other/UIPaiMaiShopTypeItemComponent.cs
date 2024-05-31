using System;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIPaiMaiShopTypeItemComponent: Entity, IAwake<GameObject>
    {
        public GameObject GameObject { get; set; }
        public GameObject Lab_TaskName;
        public GameObject Ima_SelectStatus;
        public GameObject Ima_Di;

        public Action<int> ClickHandler;
        public int SubTypeId;
    }
}