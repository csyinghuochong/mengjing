namespace ET.Client
{
    
    public class BuffHandlerCAttribute : BaseAttribute
    {

    }
    
    [EnableClass]
    [BuffHandlerC]
    public abstract class BuffHandlerC
    {
        public abstract void OnInit(BuffC buffc, BuffData buffData, Unit theUnitBelongto);

        public abstract void OnReset(BuffC buffc, long endTime);

        public abstract void OnExecute(BuffC buffc);

        public abstract void OnUpdate(BuffC buffc);

        public abstract void OnFinished(BuffC buffc);
    }
    
}