namespace ET.Client
{
    
    public class SkillHandlerCAttribute : BaseAttribute
    {

    }
    
    
    [EnableClass]
    [SkillHandlerC]
    public abstract class SkillHandlerC
    {
        public abstract void OnInit(SkillC skillc, Unit theUnitFrom);

        public abstract void OnExecute(SkillC skillc);

        public abstract void OnUpdate(SkillC skillc);

        public abstract void OnFinished(SkillC skillc);
    }
}