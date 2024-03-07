
namespace ET
{
    public static class FunctionContionEnum
    {
        public const int None = 0;
        public const int PlayerLv = 1;
        public const int TaskId = 2;
    }

    //1.每天随机给东西 参数:掉落ID
    //2.拾取地上的金币
    //3.拾取地上的金币和道具
    //4.附带技能 参数:技能ID(取消当前精灵要取消对应的技能Buff)
    //5.激活提升属性 参数: 属性
    //6.每次击败怪物额外附加一个掉落ID 参数: 掉落ID
    //7.打开对应系统功能 参数: 功能ID
    public static class JingLingFunctionType
    {
        public const int RandomDrop = 1;
        public const int PickGold = 2;

        public const int AddSkill = 4;
        public const int AddProperty = 5;
        public const int ExtraDrop = 6;
        public const int OpenFunction = 7;
    }
}
