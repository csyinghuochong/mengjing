
namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class StateComponentS : Entity, IAwake, ITransfer, IDeserialize
    {
        public long CurrentStateType;

        public long RigidityEndTime;

        public long NetWaitEndTime;

        public int ObstructStatus;

    }

}
