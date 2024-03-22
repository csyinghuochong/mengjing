
namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class StateComponent_S : Entity, IAwake, ITransfer, IDeserialize
    {
        //��ǰЯ��״̬��־
        public long CurrentStateType;

        public long RigidityEndTime;

        public long NetWaitEndTime;

        public int ObstructStatus;

    }

}
