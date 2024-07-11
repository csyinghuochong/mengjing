namespace ET.Server
{
    
    public class BuffHandlerSAttribute : BaseAttribute
    {

    }
    
    [EnableClass]
    [BuffHandlerS]
    public abstract class BuffHandlerS
    {
        /// <summary>
        /// 初始化buff数据
        /// </summary>
        /// <param name="buffData">Buff数据</param>
        /// <param name="theUnitFrom">来自哪个Unit</param>
        /// <param name="theUnitBelongto">寄生于哪个Unit</param>
        public abstract void OnInit(BuffS buffs, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler);

        /// <summary>
        /// Buff持续
        /// </summary>
        public abstract void OnUpdate(BuffS buffs);

        /// <summary>
        /// 重置Buff用
        /// </summary>
        public abstract void OnFinished(BuffS buffs);
    }
    
}