using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    public enum CameraMoveType
    {
        Normal = 0,
        BuildEnter = 1,
        BuildExit = 2,
        PetFuben = 3,
        Pull = 4,
        Rollback = 5,
        Shake = 6
    }

    public enum CameraBuildType
    {
        /// <summary>
        /// 看NPC
        /// </summary>
        Type_0,

        /// <summary>
        /// 看怪物
        /// </summary>
        Type_1,

        /// <summary>
        /// 看主角 靠左
        /// </summary>
        Type_2,

        /// <summary>
        /// 看主角 居中
        /// </summary>
        Type_3,

        /// <summary>
        /// 看主角 靠左 -> 居中
        /// </summary>
        Type_4,
    }

    public enum ShakeCameraType
    {
        Type_1,
        Type_2,
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
        public CameraBuildType CameraBuildType;
        public float CameraMoveTime;

        public Vector3 TargetPosition;
        public Vector3 OldCameraPostion;
        public Vector3 OldCameraDirection;

        public ShakeCameraType ShakeCameraType;
        public float ShakeDurationTime; // 震动时间
        public float NextShakeTime;
        public int ShakeCount;

        public float PullRate; // 镜头拉远倍概率

        public float LenDepth { get; set; } = 1; // 镜头纵深
        public float HorizontalOffset { get; set; } // 看向角色的水平偏差
        public float VerticalOffset { get; set; } // 看向角色的垂直偏差

        //相机与人物距离
        public float Distance = 11.6f;

        //初始化的偏移角度，以人物的(0,0,-1)为基准
        public float OffsetAngleX = 0;
        public float OffsetAngleY = 45;

        //相机与人物的坐标的偏移量
        public float3 OffsetPosition { get; set; }

        //纪录偏移角度用于复原
        public float RecordAngleX;

        public float RecordAngleY;

        //相机是否在旋转，旋转中需要一直重新计算 m_offsetVector
        public bool IsRotateing = false;

        //弧度，用于Mathf.Sin，Mathf.Cos的计算
        public float ANGLE_CONVERTER = Mathf.PI / 180;

        //相机上下的最大最小角度
        public float MAX_ANGLE_Y = 80;
        public float MIN_ANGLE_Y = -10;

        private EntityRef<Unit> lookAtUnit;
        public Unit LookAtUnit { get => this.lookAtUnit; set => this.lookAtUnit = value; }

        private EntityRef<Unit> buildUnit;
        public Unit BuildUnit { get => this.buildUnit; set => this.buildUnit = value; }

        public float3 BuildUnitPos { get; set; }

        public Action OnBuildEnter { get; set; }

        public List<long> NoHideIds { get; set; } = new();
    }
}