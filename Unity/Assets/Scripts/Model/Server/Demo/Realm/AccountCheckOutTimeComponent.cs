namespace ET.Server
{

    [ComponentOf(typeof(Session))]
    public class AccountCheckOutTimeComponent : Entity, IAwake<long>, IDestroy
    {
        public long Timer = 0;

        public long AccountId = 0;
    }
}