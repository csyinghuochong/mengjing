using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIPaiMaiShopTypeComponent: Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject ImageButton;
        public GameObject UIPointTaskDate;
        public GameObject UIPaiMaiShopTypeItem;
        public GameObject TaskTypeName;

        public List<UIPaiMaiShopTypeItemComponent> UITaskTypeItemList = new();
        public Action<int, int> ClickTypeItemHandler;
        public Action<int> ClickTypeHandler;

        public int TypeId;
        public bool bSelected = false;
    }
}