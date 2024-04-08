namespace ET.Server
{
    
    public class BuffHandlerSAttribute : BaseAttribute
    {

    }
    
    [BuffHandlerS]
    public abstract class BuffHandlerS
    {
        /// <summary>
        /// 初始化buff数据
        /// </summary>
        /// <param name="buffData">Buff数据</param>
        /// <param name="theUnitFrom">来自哪个Unit</param>
        /// <param name="theUnitBelongto">寄生于哪个Unit</param>
        public abstract void OnInit(BuffData buffData, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler=null);

        /// <summary>
        /// Buff持续
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        /// 重置Buff用
        /// </summary>
        public abstract void OnFinished();
    }
    
}