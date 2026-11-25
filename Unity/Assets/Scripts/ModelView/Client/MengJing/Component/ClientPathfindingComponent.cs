using DotRecast.Core.Numerics;
using DotRecast.Detour;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class ClientPathfindingComponent: Entity, IAwake<int>, IDestroy
    {
        public const int MAX_POLYS = 256;
        
        public const int FindRandomNavPosMaxRadius = 15000;  // 随机找寻路点的最大半径
        
        public RcVec3f extents = new(15, 10, 15);
        
        public int Name;
        
        public DtNavMesh navMesh;
        
        public long[] polys = new long[MAX_POLYS];

        public IDtQueryFilter filter;
        
        public DtNavMeshQuery query;
    }
}
