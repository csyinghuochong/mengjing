namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class TuoGuanComponet : Entity, IAwake, IDestroy, ITransfer, IDeserialize
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

       
        /// <summary>
        /// 巡逻范围
        /// </summary>
        public float PatrolRange{ get; set; }
        
        public double ActDistance{ get; set; }
        
      
        public long LastChangeTime;
        
        public long LastZhuiJiTime;
        
        
        public int SceneType { get; set; }
        
        public bool noCheckStatus { get; set; }            //检测状态  true 就是不检测 待机除外
        public int CheckJianGeTimeNum;          //检测间隔时间次数

        public long AIDelay;
    }

}
