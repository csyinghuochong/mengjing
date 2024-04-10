namespace ET.Client
{
    
    public class BuffHandlerCAttribute : BaseAttribute
    {

    }
    
    [BuffHandlerC]
    public abstract class BuffHandlerC
    {
        public abstract void OnInit(BuffC buffc, BuffData buffData, Unit theUnitBelongto);

        public abstract void OnReset(long endTime);

        public abstract void OnExecute();

        public abstract void OnUpdate();

        public abstract void OnFinished();
    }
    
}