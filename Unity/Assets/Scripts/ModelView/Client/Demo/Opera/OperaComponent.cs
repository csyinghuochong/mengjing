using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class OperaComponent: Entity, IAwake, IUpdate
    {
        public Vector3 ClickPoint;

        public float LastSendTime;

        public int MapMask;
        public int NpcMask;
        public int BoxMask;
        public int PlayerMask;
        public int MonsterMask;
        public int BuildingMask;

        public int NpcId;
        public Vector3 UnitStartPosition;

        public Camera MainCamera;

        public bool ClickMode;
        public bool EditorMode;

        public Unit MainUnit { get; set; }
    }
}