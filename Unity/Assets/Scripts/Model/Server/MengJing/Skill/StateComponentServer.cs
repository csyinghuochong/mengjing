
namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class StateComponentServer : Entity, IAwake, ITransfer, IDeserialize
    {
        //��ǰЯ��״̬��־
        public long CurrentStateType;

        public long RigidityEndTime;

        public long NetWaitEndTime;

        public int ObstructStatus;

    }

}
