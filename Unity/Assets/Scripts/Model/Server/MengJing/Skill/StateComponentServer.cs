
namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class StateComponentServer : Entity, IAwake, ITransfer, IDeserialize
    {
        //当前携带状态标志
        public long CurrentStateType;

        public long RigidityEndTime;

        public long NetWaitEndTime;

        public int ObstructStatus;

    }

}
