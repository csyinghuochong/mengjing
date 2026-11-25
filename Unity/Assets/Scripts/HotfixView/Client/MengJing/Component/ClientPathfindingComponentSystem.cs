using System.Collections.Generic;
using System.IO;
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
                // FlyTipComponent.Instance.ShowFlyTip(zstring.Format("加载寻路数据失败： {0}", name));
                Log.Error(string.Format("加载寻路数据失败： {0}", name));
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
            self.query = null;
            self.filter = null;
            self.navMesh = null;
        }

        public static void Find(this ClientPathfindingComponent self, float3 start, float3 target, List<float3> result)
        {
            if (self.navMesh == null)
            {
                Log.Error("寻路| Find 失败 pathfinding ptr is zero");
                return;
            }

            PathfindingComponentSystem.Find(self.query, self.extents, self.filter, ref self.polys, start, target, result);
        }
    }
}
