using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public class JiaYuanPlanUIComponent : Entity, IAwake, IDestroy
    {
        public GameObject GameObject;
        public Camera UICamera;
        public Camera MainCamera;
        public Transform UIPosition;
        public HeadBarUI HeadBarUI;
        public NumericComponentC NumericComponent { get; set; }

        public int PlanStage = -1;
        public long Timer;
    }
}