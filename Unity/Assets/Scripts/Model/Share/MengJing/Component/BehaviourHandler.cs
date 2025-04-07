namespace ET
{

    public static class BehaviourType
    {
        public const int Behaviour_Test = 0;                //
        public const int Behaviour_Stroll = 1;              //闲逛
        public const int Behaviour_Task = 2;                //任务
        public const int Behaviour_ZhuiJi = 3;              //追击
        public const int Behaviour_Attack = 4;              //攻击
        public const int Behaviour_Battle = 5;              //战场
        public const int Behaviour_TeamDungeon = 6;         //组队
        public const int Behaviour_Target = 7;
        public const int Behaviour_YeWaiBoss = 8;
        public const int Behaviour_Arena = 9;
        public const int Behaviour_Solo = 10;
        public const int Behaviour_Local = 11;
        public const int Behaviour_Tower = 12;
        public const int Behaviour_RunRace = 13;
        public const int Behaviour_Demon = 14;
        public const int Behaviour_BaoZang = 15;
        public const int Behaviour_Retreat = 16;
        public const int Behaviour_DragonDungeon = 17;
        public const int Behaviour_DragonFollow = 18;
        public const int Behaviour_PetMatch = 19;
        public const int Behaviour_PetMatchFight = 20;
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
