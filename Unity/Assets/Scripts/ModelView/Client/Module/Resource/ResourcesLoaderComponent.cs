using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;

namespace ET.Client
{

    [EntitySystemOf(typeof(ResourcesLoaderComponent))]
    [FriendOf(typeof(ResourcesLoaderComponent))]
    public static partial class ResourcesLoaderComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ResourcesLoaderComponent self)
        {
            self.Package = YooAssets.GetPackage("DefaultPackage");

            GameObjectPoolHelper.LoadAssetEventHandle = (string a, long b) =>
            {
               return self.LoadAssetSync<GameObject>(a,b);
            };
        }
        
        [EntitySystem]
        private static void Destroy(this ResourcesLoaderComponent self)
        {
            UnityEngine.Debug.Log("ResourcesLoaderComponent.Destroy");
            self.UnLoadAllAsset();
        }

        public static void ReleaseHandler(this ResourcesLoaderComponent self, HandleBase handleBase)
        {
            switch (handleBase)
            {
                case AssetHandle handle:
                    handle.Release();
                    break;
                case AllAssetsHandle handle:
                    handle.Release();
                    break;
                case SubAssetsHandle handle:
                    handle.Release();
                    break;
                case RawFileHandle handle:
                    handle.Release();
                    break;
                case SceneHandle handle:
                    handle.UnloadAsync();
                    break;
            }
        }

        public static void UnLoadAsset(this ResourcesLoaderComponent self, string location)
        {
            if (self.Handlers.TryGetValue(location, out var entry))
            {
                self.ReleaseHandler(entry.handler);
                self.Handlers.Remove(location);
                //UnityEngine.Debug.LogError($"UnLoadAsset True： {location}");
            }
            else
            {
                //UnityEngine.Debug.LogError($"UnLoadAsset False： {location}");
            }
        }

        public static void UnLoadAllAsset(this ResourcesLoaderComponent self)
        {
            // foreach (var kv in self.Handlers)
            // {
            //     self.ReleaseHandler(kv.Value.handler);
            // }
            //
            // self.Handlers.Clear();

            self.Package.UnloadUnusedAssetsAsync();
        }

        public static void UnloadUnusedAssets(this ResourcesLoaderComponent self)
        {
            
            List<string> keysToRemove = new List<string>();
            long now = TimeInfo.Instance.ServerNow();
            foreach (var kv in self.Handlers)
            {
                if (now >= kv.Value.destroyTime)
                {
                    keysToRemove.Add(kv.Key);
                }
            }

            Log.Debug($"目前数量：{self.Handlers.Count}     定时清理数量：{keysToRemove.Count}");

            foreach (string s in keysToRemove)
            {
                self.UnLoadAsset(s);
            }

            self.Package.UnloadUnusedAssetsAsync();
        }

        // 小游戏不支持同步加载，除非提前加载好
        public static T LoadAssetSync<T>(this ResourcesLoaderComponent self, string location, long liveTime = 30 * 1000) where T : UnityEngine.Object
        {
            HandleBase handler;
            if (!self.Handlers.TryGetValue(location, out (HandleBase handler, long destroyTime) selfHandler))
            {
                handler = self.Package.LoadAssetSync<T>(location);
                self.Handlers.Add(location, (handler, TimeInfo.Instance.ServerNow() + liveTime));
            }
            else
            {
                selfHandler.destroyTime = TimeInfo.Instance.ServerNow() + liveTime;
                handler = selfHandler.handler;
            }

            return (T)((AssetHandle)handler).AssetObject;
        }

        public static async ETTask<T> LoadAssetAsync<T>(this ResourcesLoaderComponent self, string location) where T : UnityEngine.Object
        {
            using CoroutineLock coroutineLock = await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.ResourcesLoader, location.GetHashCode());
            
            long liveTime = TimeHelper.Hour;
            HandleBase handler;
            if (!self.Handlers.TryGetValue(location, out (HandleBase handler, long destroyTime) selfHandler))
            {
                handler = self.Package.LoadAssetAsync<T>(location);
                await handler.Task;
                self.Handlers.Add(location, (handler, TimeInfo.Instance.ServerNow() + liveTime));
            }
            else
            {
                selfHandler.destroyTime = TimeInfo.Instance.ServerNow() + liveTime;
                handler = selfHandler.handler;
            }

            return (T)((AssetHandle)handler).AssetObject;
        }

        public static async ETTask LoadSceneAsync(this ResourcesLoaderComponent self, string location, LoadSceneMode loadSceneMode)
        {
            using CoroutineLock coroutineLock = await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.ResourcesLoader, location.GetHashCode());

            HandleBase handler;

            // YooAsset内部是这样处理的  调用LoadSceneAsync()，如果加载的是主场景，则自动卸载所有缓存的场景
            // 该项目都是单独场景，所以暂时屏蔽 self.handlers.Add

            // if (self.handlers.TryGetValue(location, out handler))
            // {
            //     return;
            // }

            handler = self.Package.LoadSceneAsync(location, loadSceneMode);

            await handler.Task;
            // self.handlers.Add(location, handler);
        }
    }

    /// <summary>
    /// 用来管理资源，生命周期跟随Parent，比如CurrentScene用到的资源应该用CurrentScene的ResourcesLoaderComponent来加载
    /// 这样CurrentScene释放后，它用到的所有资源都释放了
    /// </summary>
    [ComponentOf]
    public class ResourcesLoaderComponent : Entity, IAwake, IDestroy
    {
        public ResourcePackage Package;
        public Dictionary<string, (HandleBase handler, long destroyTime)> Handlers = new();
    }
}