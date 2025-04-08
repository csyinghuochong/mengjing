using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    
    [ComponentOf(typeof(Scene))]
    public class BehaviourComponent : Entity, IAwake<int>, IDestroy
    {
        
        public List<KeyValuePair> Behaviours = new List<KeyValuePair>();

        public ETCancellationToken CancellationToken;

        public long Timer;

        public int Current;

        public int NewBehaviour { get; set; } = -1;

        public long TargetID{ get; set; }

        public float3 TargetPosition{ get; set; }

        public RobotConfig RobotConfig{ get; set; }

        public long CreateTime;

        public string Message { get; set; }

        /// <summary>
        /// 攻击范围，范围内攻击
        /// </summary>
        public float ActDistance { get; set; }= 3;

        public readonly C2M_SkillCmd c2mSkillCmd = C2M_SkillCmd.Create();
    }
}

