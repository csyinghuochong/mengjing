using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    //[ComponentOf(typeof(Scene))]
    [ComponentOf(typeof(Unit))]
    public class AIComponent: Entity, IAwake<int>, IDestroy
    {
        public int AIConfigId
        {
            get;set
            ;
        }

        public ETCancellationToken CancellationToken;

        public long Timer;

        public int Current;

        public long TargetID{ get; set; }

        public float ActRange { get; set; }

        public bool IsRetreat{ get; set; }
        
        /// <summary>
        /// 追击范围，超出则撤退
        /// </summary>
        public float ChaseRange{ get; set; }
        
        /// <summary>
        /// 巡逻范围
        /// </summary>
        public float PatrolRange{ get; set; }
        
        public double ActDistance{ get; set; }
        
        public List<int> AISkillIDList{ get; set; } = new List<int>();     //当前所有技能
        
        public long LastChangeTime;
        
        public long LastZhuiJiTime;
        
        public float3 TargetZhuiJi{ get; set; }
        
        public int SceneType { get; set; }
        
        public int CheckJianGeTimeNum;          //检测间隔时间次数

        public long AIDelay;

        public List<float3> TargetPoint  { get; set; }= new List<float3>();
    }
}