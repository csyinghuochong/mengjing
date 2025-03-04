
namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class StateComponentS : Entity, IAwake, ITransfer, IDeserialize
    {
        public long CurrentStateType { get; set; }

        public long RigidityEndTime { get; set; }

        public long NetWaitEndTime { get; set; }

    }

}
