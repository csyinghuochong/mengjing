namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class StateComponentC : Entity, IAwake
    {
        //当前携带状态标志
        public long CurrentStateType;

        public long RigidityEndTime;

        public long NetWaitEndTime;

        public int ObstructStatus { get; set; } = 0;

        public C2M_UnitStateUpdate c2M_UnitStateUpdate = null;

        /// <summary>
        /// 沉默, 避免前后端不同步出现玩家不能移动的情况
        /// </summary>
        public long SilenceCheckTime;
    }
}

