namespace ET
{

    public static class BehaviourType
    {
        public const int Behaviour_Test = 1;                //
    }

    public class BehaviourHandlerAttribute : BaseAttribute
    {

    }

    [EnableClass]
    [BehaviourHandler]
    public abstract class BehaviourHandler
    {
        // 检查是否满足条件
        public abstract bool Check(BehaviourComponent aiComponent, AIConfig aiConfig);

        // 协程编写必须可以取消
        public abstract ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken);

        public abstract int BehaviourId();
    }
}
