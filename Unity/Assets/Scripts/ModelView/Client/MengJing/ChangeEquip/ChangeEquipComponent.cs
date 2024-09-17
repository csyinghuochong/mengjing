﻿using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class ChangeEquipComponent : Entity, IAwake, IDestroy
    {
        public GameObject target;
        public string lianPaths;
        public string shangyiPaths;
        public string meimaoPaths;
        public string pifengPaths;
        public string toufaPaths;
        public string xiashenPaths;
        public string xieziPaths;
        public string yangjingPaths;
    }
}