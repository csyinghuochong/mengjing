using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class MonsterActRangeComponent: Entity, IAwake<int>, IDestroy
    {
        public bool IsInAck;
        public float AckRange;
        public float3 BornPositon;
        public GameObject MonsterActRange;
    }
}