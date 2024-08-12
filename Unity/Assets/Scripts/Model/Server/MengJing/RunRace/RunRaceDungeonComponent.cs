using Unity.Mathematics;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Scene))]
    public class RunRaceDungeonComponent: Entity, IAwake, IDestroy
    {
        public long Timer;

        public long NextTransforTime;

        public bool Close;

        public int CheckTime;

        public bool HaveArrived;

        public float3 EndPosition = new float3(26f, 0f, -6.5f);
    }
    
}
