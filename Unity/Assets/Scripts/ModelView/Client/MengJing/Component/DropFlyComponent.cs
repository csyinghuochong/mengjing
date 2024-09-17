using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class DropFlyComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public Unit MyUnit { get; set; }
        public Unit TargetUnit { get; set; }
        public DropInfo DropInfo;
        public bool Send;
        public string EffectPath;
        public bool IsPlayEffect;
        public GameObject EffectGameObject;
        public Vector3 StartPosition;
        public float Speed = 6f; // 移动速度
        public float Distance = 0.2f; // 范围(飘到距离角色多少米内发送消息拾取)
        public float T;
    }
}