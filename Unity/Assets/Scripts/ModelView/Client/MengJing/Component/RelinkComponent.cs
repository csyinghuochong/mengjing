namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class RelinkComponent : Entity, IAwake, IDestroy
    {
        public bool Relink;

        public int ModifyDataNumber = 0;
        
        
    }
}