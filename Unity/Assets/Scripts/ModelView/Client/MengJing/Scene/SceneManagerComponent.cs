namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class SceneManagerComponent: Entity, IAwake
    {
        public bool Wait;
    }
}