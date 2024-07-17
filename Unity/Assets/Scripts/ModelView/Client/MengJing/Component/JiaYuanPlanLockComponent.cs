﻿using UnityEngine;

namespace ET
{
    [ChildOf]
    public class JiaYuanPlanLockComponent: Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject HeadBar;
        public Camera UICamera;
        public Camera MainCamera;
        public Transform UIPosition;
        public HeadBarUI HeadBarUI;

        public GameObject GameObject;

        public string PlanEffectPath;
        public GameObject PlanEffectObj;

        public int CellIndex;
    }
}