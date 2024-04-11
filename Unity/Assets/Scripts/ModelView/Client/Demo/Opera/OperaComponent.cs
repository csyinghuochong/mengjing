using System;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class OperaComponent: Entity, IAwake, IUpdate
    {
        public Vector3 ClickPoint;

        public float LastSendTime;

        public int mapMask;
        public int npcMask;
        public int boxMask;
        public int playerMask;
        public int monsterMask;
        public int buildingMask;

        public int NpcId;
        public Vector3 UnitStartPosition;

        public Camera mainCamera;

        public bool ClickMode;
        public bool EditorMode;

        public Unit MainUnit { get; set; }
    }
}