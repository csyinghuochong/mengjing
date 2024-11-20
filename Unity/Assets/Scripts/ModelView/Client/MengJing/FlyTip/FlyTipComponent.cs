using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class FlyTipComponent: Entity, IAwake, IDestroy, IUpdate
    {
        public List<GameObject> FlyTips = new();
        public Queue<string> FlyTipQueue = new();
        public long LastSpawnFlyTipTime;
        public List<GameObject> FlyTipDis = new();
        public Queue<string> FlyTipDiQueue = new();
        public long LastSpawnFlyTipDiTime;

        public long Interval = 300;

        [StaticField]
        public static FlyTipComponent Instance;

        public Dictionary<long, string> FlyTipStr = new();
    }
}