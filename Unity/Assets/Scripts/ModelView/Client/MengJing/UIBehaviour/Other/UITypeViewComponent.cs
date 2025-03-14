using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public struct TypeButtonItem
    {
        public int SubTypeId;
        public string ItemName;
    }

    [EnableClass]
    public class TypeButtonInfo
    {
        public int TypeId;
        public string TypeName;
        public List<TypeButtonItem> typeButtonItems = new();
    }

    [ChildOf]
    public class UITypeViewComponent: Entity, IAwake<GameObject>
    {
        public GameObject GameObject { get; set; }
        public string TypeButtonItemAsset { get; set; }
        public string TypeButtonAsset { get; set; }

        public Action<int, int> ClickTypeItemHandler { get; set; }
        public List<TypeButtonInfo> TypeButtonInfos { get; set; } = new();
        public List<UITypeButtonComponent> TypeButtonComponents { get; set; } = new();

        public bool CanClick { get; set; } = true;
    }

    [ChildOf]
    public class UITypeButtonComponent: Entity, IAwake<GameObject>
    {
        public string TypeItemAsset;
        public TypeButtonInfo TypeButtonInfo;
        public GameObject ImageButton;
        public GameObject UIPointTaskDate;
        public GameObject ImageSelect_1;  //选中
        public GameObject TaskTypeName_1;
        public GameObject ImageSelect_0;  //未选中
        public GameObject TaskTypeName_0;
        public GameObject GameObject;

        public List<EntityRef<UITypeButtonItemComponent>> TypeItemUIList = new();
        public Action<int, int> ClickTypeItemHandler;
        public Action<int> ClickTypeHandler;

        public float Height = 500f;
        public float Spacing = 80f;
        public bool bSelected = false;
        public int TypeId;

        public int SubPage = 0;
    }

    [ChildOf]
    public class UITypeButtonItemComponent: Entity, IAwake<GameObject>
    {
        public GameObject Lab_TaskName;
        public GameObject Ima_SelectStatus;
        public GameObject Ima_Di;
        public GameObject GameObject;

        public Action<int> ClickHandler;
        public int SubTypeId;
    }
}