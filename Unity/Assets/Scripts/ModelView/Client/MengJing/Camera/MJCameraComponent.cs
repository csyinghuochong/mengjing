using System;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    public enum CameraMoveType
    {
        Normal = 0,
        NpcEnter = 1,
        NpcExit = 2,
        PetFuben = 3,
        Pull = 4,
        Rollback = 5,
        LookAtPet = 6,
    }

    [FriendOf(typeof(Unit))]
    [ComponentOf(typeof(Scene))]
    public class MJCameraComponent : Entity, IAwake, ILateUpdate
    {
        // 战斗摄像机
        public Camera MainCamera;

        // public Vector3 OffsetPostion;

        //0正常 1商店npc

        public CameraMoveType CameraMoveType;

        public float CameraMoveTime;

        public Vector3 TargetPosition;
        public Vector3 OldCameraPostion;

        public float PullRate; // 镜头拉远倍概率

        public float LenDepth { get; set; } = 1; // 镜头纵深

        //相机与人物距离
        public float Distance = 11.6f;

        //初始化的偏移角度，以人物的(0,0,-1)为基准
        public float OffsetAngleX = 0;
        public float OffsetAngleY = 45;

        //相机与人物的坐标的偏移量
        public float3 OffsetPostion;

        //纪录偏移角度用于复原
        public float RecordAngleX;

        public float RecordAngleY;

        //相机是否在旋转，旋转中需要一直重新计算 m_offsetVector
        public bool IsRotateing = false;

        //弧度，用于Mathf.Sin，Mathf.Cos的计算
        public float ANGLE_CONVERTER = Mathf.PI / 180;

        //相机上下的最大最小角度
        public float MAX_ANGLE_Y = 80;
        public float MIN_ANGLE_Y = 10;

        private EntityRef<Unit> mainUnit;
        public Unit MainUnit { get => this.mainUnit; set => this.mainUnit = value; }

        private EntityRef<Unit> npcUnit;
        public Unit NpcUnit { get => this.npcUnit; set => this.npcUnit = value; }

        private EntityRef<Unit> petUnit;
        public Unit PetUnit { get => this.petUnit; set => this.petUnit = value; }

        public Action OnBuildEnter { get; set; }
    }
}