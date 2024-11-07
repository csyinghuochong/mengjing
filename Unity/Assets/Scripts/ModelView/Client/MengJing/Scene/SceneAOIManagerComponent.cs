namespace ET.Client
{
    
    [ComponentOf(typeof(Scene))]
    public class SceneAOIManagerComponent: Entity, IAwake
    {
        public const int CellSize = 2 * 1000;
    }
    
}