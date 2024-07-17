namespace ET.Server
{

    [ComponentOf(typeof(Scene))]
    public class AccountCenterComponent : Entity, IAwake, IDestroy
    {
        public long Timer;

        public int TianQITime = 0;
        public int TianQiValue= 0;

        public int CheckIndex = 0;

        public DBCenterSerialInfo DBCenterSerialInfo
        {
            get;
            set
            ;
        }
    }
}