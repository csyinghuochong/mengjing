using System;
using System.Collections.Generic;
using DotRecast.Core.Numerics;
using DotRecast.Detour;
using Unity.Mathematics;

namespace ET
{
    [EntitySystemOf(typeof(PathfindingComponent))]
    [FriendOf(typeof(PathfindingComponent))]
    public static partial class PathfindingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PathfindingComponent self, int name)
        {
            self.Name = name;
            self.navMesh = NavmeshComponent.Instance.GetMesh(name.ToString());
            self.filter = new DtQueryDefaultFilter();
            self.query = new DtNavMeshQuery(self.navMesh);
        }

        [EntitySystem]
        private static void Destroy(this PathfindingComponent self)
        {
            self.Name = 0;
            self.query = null;
            self.filter = null;
            self.navMesh = null;
        }

        public static void Find(this PathfindingComponent self, float3 start, float3 target, List<float3> result)
        {
            if (self.navMesh == null)
            {
                Log.Debug("寻路| Find 失败 pathfinding ptr is zero");
                throw new Exception($"pathfinding ptr is zero: {self.Scene().Name}");
            }

            Find(self.query, self.extents, self.filter, ref self.polys, start, target, result);
        }

        public static void Find(DtNavMeshQuery query, RcVec3f extents, IDtQueryFilter filter, ref long[] polys,
            float3 start, float3 target, List<float3> result)
        {
            RcVec3f startPos = new(-start.x, start.y, start.z);
            RcVec3f endPos = new(-target.x, target.y, target.z);
            query.FindNearestPoly(startPos, extents, filter, out long startRef, out RcVec3f startPt, out _);
            query.FindNearestPoly(endPos, extents, filter, out long endRef, out RcVec3f endPt, out _);
            if (startRef == 0 || endRef == 0)
            {
                return;
            }

            DtStatus status = query.FindPath(startRef, endRef, startPt, endPt, filter, polys, out int polyCount, polys.Length);
            while (status.Has(DtStatus.DT_BUFFER_TOO_SMALL))
            {
                polys = new long[polys.Length * 2];
                status = query.FindPath(startRef, endRef, startPt, endPt, filter, polys, out polyCount, polys.Length);
            }
            if (status.Failed() || polyCount == 0)
            {
                return;
            }

            // 部分路径的终点落在最后一个可到达的多边形上。
            long lastPoly = polys[polyCount - 1];
            if (lastPoly != endRef && query.ClosestPointOnPoly(lastPoly, endPt, out RcVec3f closest, out _).Succeeded())
            {
                endPt = closest;
            }

            Span<DtStraightPath> straightPath = stackalloc DtStraightPath[PathfindingComponent.MAX_POLYS];
            query.FindStraightPath(startPt, endPt, polys, polyCount, straightPath, out int straightCount, straightPath.Length,
                DtStraightPathOptions.DT_STRAIGHTPATH_ALL_CROSSINGS);
            for (int i = 0; i < straightCount; ++i)
            {
                RcVec3f pos = straightPath[i].pos;
                result.Add(new float3(-pos.X, pos.Y, pos.Z));
            }
        }

        public static float3 GetCanChongJiPath(this PathfindingComponent self, float3 start, float3 target, float distance = 1f)
        {
            using var list = ListComponent<float3>.Create();
            float3 dir = (target - start).normalize();
            float3 tmm = start;

            int max = 0;
            while (max < 10)
            {
                float3 next = tmm + (distance * dir);
                self.Find(start, next, list);
                if (list.Count == 0 || list.Count == 1)
                {
                    break;
                }

                if (math.abs(list[^1].x - next.x) > 0.1f || math.abs(list[^1].z - next.z) > 0.1f)
                {
                    break;
                }

                if (math.distance(next, target) <= distance)
                {
                    break;
                }

                tmm = next;

                max++;
            }

            return tmm;
        }
    }
}
