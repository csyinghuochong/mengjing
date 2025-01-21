using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.AI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ClientPathfinding2Component))]
    [FriendOf(typeof(ClientPathfinding2Component))]
    public static partial class ClientPathfinding2ComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientPathfinding2Component self)
        {
            self.NavMeshAgent = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.GetComponent<NavMeshAgent>();
        }

        [EntitySystem]
        private static void Destroy(this ClientPathfinding2Component self)
        {
            self.NavMeshAgent = null;
        }

        public static void Find(this ClientPathfinding2Component self, float3 target, List<float3> result)
        {
            NavMeshPath path = new NavMeshPath();

            if (self.NavMeshAgent.CalculatePath(target, path))
            {
                for (int i = 0; i < path.corners.Length; i++)
                {
                    result.Add(path.corners[i]);
                }
            }
        }
    }
}