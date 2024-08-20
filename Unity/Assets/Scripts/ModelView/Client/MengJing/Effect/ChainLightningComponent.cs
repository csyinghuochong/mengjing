using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Effect))]
    public class ChainLightningComponent : Entity, IAwake<GameObject>, IDestroy
    {
        public long Timer;

        public float detail = 1; //增加后，线条数量会减少，每个线条会更长。  

        public float displacement = 0.5f; //位移量，也就是线条数值方向偏移的最大值  

        public Transform End { get; set; } //链接目标  

        public Transform Start { get; set; }

        public bool UsePosition { get; set; }
        public Vector3 EndPosition { get; set; }

        public float yOffset = 0;

        public float PassTime;

        public float IntervalTime = 0.1f;

        public LineRenderer _lineRender;

        public List<Vector3> _linePosList;

        public float TextureOffsetX = 0;
    }
}