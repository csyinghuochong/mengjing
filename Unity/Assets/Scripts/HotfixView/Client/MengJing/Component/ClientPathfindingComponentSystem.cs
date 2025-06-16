using System;
using System.Collections.Generic;
using System.IO;
using DotRecast.Core;
using DotRecast.Detour;
using DotRecast.Detour.Io;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ClientPathfindingComponent))]
    [FriendOf(typeof(ClientPathfindingComponent))]
    public static partial class ClientPathfindingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientPathfindingComponent self, int name)
        {
            self.Name = name;

            // 文件类型以.bytes结尾
            TextAsset textAsset = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<TextAsset>(ABPathHelper.GetRecastPath(name));
            if(textAsset == null)
            {
                using (zstring.Block())
                {
                    // FlyTipComponent.Instance.ShowFlyTip(zstring.Format("加载寻路数据失败： {0}", name));
                    Log.Error(zstring.Format("加载寻路数据失败： {0}", name));
                }
                return;
            }
            
            byte[] buffer = textAsset.bytes;

            DtMeshSetReader reader = new();
            using MemoryStream ms = new(buffer);
            using BinaryReader br = new(ms);
            self.navMesh = reader.Read32Bit(br, 6); // cpp recast导出来的要用Read32Bit读取，DotRecast导出来的还没试过

            if (self.navMesh == null)
            {
                Log.Error($"nav load fail: {name}");
                return;
            }

            self.filter = new DtQueryDefaultFilter();
            self.query = new DtNavMeshQuery(self.navMesh);
        }

        [EntitySystem]
        private static void Destroy(this ClientPathfindingComponent self)
        {
            self.Name = 0;
            self.navMesh = null;
        }

        public static void Find(this ClientPathfindingComponent self, float3 start, float3 target, List<float3> result)
        {
            if (self.navMesh == null)
            {
                Log.Error("寻路| Find 失败 pathfinding ptr is zero");
                return;
            }

            RcVec3f startPos = new(-start.x, start.y, start.z);
            RcVec3f endPos = new(-target.x, target.y, target.z);

            long startRef;
            long endRef;
            RcVec3f startPt;
            RcVec3f endPt;

            self.query.FindNearestPoly(startPos, self.extents, self.filter, out startRef, out startPt, out _);
            self.query.FindNearestPoly(endPos, self.extents, self.filter, out endRef, out endPt, out _);

            self.query.FindPath(startRef, endRef, startPt, endPt, self.filter, ref self.polys, new DtFindPathOption(0, float.MaxValue));

            if (0 >= self.polys.Count)
            {
                return;
            }

            // In case of partial path, make sure the end point is clamped to the last polygon.
            RcVec3f epos = RcVec3f.Of(endPt.x, endPt.y, endPt.z);
            if (self.polys[^1] != endRef)
            {
                DtStatus dtStatus = self.query.ClosestPointOnPoly(self.polys[^1], endPt, out RcVec3f closest, out bool _);
                if (dtStatus.Succeeded())
                {
                    epos = closest;
                }
            }

            self.query.FindStraightPath(startPt, epos, self.polys, ref self.straightPath, PathfindingComponent.MAX_POLYS,
                DtNavMeshQuery.DT_STRAIGHTPATH_ALL_CROSSINGS);

            for (int i = 0; i < self.straightPath.Count; ++i)
            {
                RcVec3f pos = self.straightPath[i].pos;
                result.Add(new float3(-pos.x, pos.y, pos.z));
            }
        }
    }
}