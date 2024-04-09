namespace ET.Client
{
    
    public class SkillHandlerCAttribute : BaseAttribute
    {

    }
    
    [SkillHandlerC]
    public abstract class SkillHandlerC
    {
        public abstract void OnInit(SkillC skillc, SkillInfo skillcmd, Unit theUnitFrom);

        public abstract void OnExecute(SkillC skillc);

        public abstract void OnUpdate(SkillC skillc);

        public abstract void OnFinished(SkillC skillc);
    }
}