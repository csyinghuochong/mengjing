using UnityEngine.AI;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class ClientPathfinding2Component : Entity, IAwake, IDestroy
    {
        public NavMeshAgent NavMeshAgent;
    }
}