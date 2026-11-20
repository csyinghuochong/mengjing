using System;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIShouJiTreasureTypeComponent: Entity, IAwake<GameObject>
    {
        public GameObject Lab_TaskName;
        public GameObject Lab_TaskName_Select;
        public GameObject Ima_Icon;
        public GameObject Ima_Icon_Select;
        public GameObject Ima_SelectStatus;
        public GameObject Ima_Di;
        public GameObject RedDot;

        public int Chapter;
        public Action<int> ClickChapHandler;
    }
}
