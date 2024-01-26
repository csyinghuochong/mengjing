namespace ET.Server
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    public class BagComponent : Entity, IAwake<int>, IDestroy, ITransfer, IUnitCache
    {
        public int AIConfigId;

        public ETCancellationToken CancellationToken;

        public long Timer;

        public int Current;
    }
}