namespace ET
{
    // Unit的组件有这个接口说明需要传送
    public interface ITransfer
    {
        
    }
}

//using ET.Server;

//namespace ET
//{
//    // 客户端挂在ClientScene上，服务端挂在Unit上
//#if DOTNET
//    [ComponentOf(typeof(Unit))]
//     public class BagComponent : Entity, IAwake<int>, IDestroy, ITransfer, IUnitCache
//#else
//    [ComponentOf(typeof(Scene))]
//    public class BagComponent : Entity, IAwake<int>, IDestroy
//#endif

//    {
//        public int AIConfigId;

//        public ETCancellationToken CancellationToken;

//        public long Timer;

//        public int Current;
//    }
//}