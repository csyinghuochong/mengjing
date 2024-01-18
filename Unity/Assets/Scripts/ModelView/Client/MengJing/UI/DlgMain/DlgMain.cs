using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgMain: Entity, IAwake, IUILogic
    {
        public DlgMainViewComponent View
        {
            get => this.GetComponent<DlgMainViewComponent>();
        }

        public Vector2 OldPoint;
        public Vector2 NewPoint;
        public float Distance = 110;
        public long lastSendTime;
        public long checkTime;

        public int direction;
        public int lastDirection;

        public Camera UICamera;
        public Camera MainCamera;
        public float LastShowTip;

        public EntityRef<Unit> MainUnit;

        public int ObstructLayer;
        public int BuildingLayer;
        public long Timer;

        public int OperateMode;
    }
}