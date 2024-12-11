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

        public static void ReleaseHandler(this ResourcesLoaderComponent self, OperationHandleBase handleBase)
        {
            switch (handleBase)
            {
                case AssetOperationHandle handle:
                    handle.Release();
                    break;
                case AllAssetsOperationHandle handle:
                    handle.Release();
                    break;
                case SubAssetsOperationHandle handle:
                    handle.Release();
                    break;
                case RawFileOperationHandle handle:
                    handle.Release();
                    break;
                case SceneOperationHandle handle:
                    if (!handle.IsMainScene())
                    {
                        handle.UnloadAsync();
                    }
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

            self.Package.UnloadUnusedAssets();
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

            using (zstring.Block())
            {
                Log.Debug(zstring.Format("目前数量：{0}     定时清理数量：{1}", self.Handlers.Count, keysToRemove.Count));
            }

            foreach (string s in keysToRemove)
            {
                self.UnLoadAsset(s);
            }

            self.Package.UnloadUnusedAssets();
        }

        public static T LoadAssetSync<T>(this ResourcesLoaderComponent self, string location, long liveTime = 30 * 1000) where T : UnityEngine.Object
        {
            OperationHandleBase handler;
            if (!self.Handlers.TryGetValue(location, out (OperationHandleBase handler, long destroyTime) selfHandler))
            {
                handler = self.Package.LoadAssetSync<T>(location);
                self.Handlers.Add(location, (handler, TimeInfo.Instance.ServerNow() + liveTime));
            }
            else
            {
                selfHandler.destroyTime = TimeInfo.Instance.ServerNow() + liveTime;
                handler = selfHandler.handler;
            }

            return (T)((AssetOperationHandle)handler).AssetObject;
        }

        public static async ETTask<T> LoadAssetAsync<T>(this ResourcesLoaderComponent self, string location)
                where T : UnityEngine.Object
        {
            using CoroutineLock coroutineLock = await self.Root().GetComponent<CoroutineLockComponent>()
                    .Wait(CoroutineLockType.ResourcesLoader, location.GetHashCode());
            
            long liveTime = TimeHelper.Hour;
            OperationHandleBase handler;
            if (!self.Handlers.TryGetValue(location, out (OperationHandleBase handler, long destroyTime) selfHandler))
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

            return (T)((AssetOperationHandle)handler).AssetObject;
        }

        public static async ETTask LoadSceneAsync(this ResourcesLoaderComponent self, string location, LoadSceneMode loadSceneMode)
        {
            using CoroutineLock coroutineLock = await self.Root().GetComponent<CoroutineLockComponent>()
                    .Wait(CoroutineLockType.ResourcesLoader, location.GetHashCode());

            OperationHandleBase handler;

            // YooAsset内部是这样处理的  调用LoadSceneAsync()，如果加载的是主场景，则自动卸载所有缓存的场景
            // 该项目都是单独场景，所以暂时屏蔽 self.handlers.Add

            // if (self.handlers.TryGetValue(location, out handler))
            // {
            //     return;
            // }

            handler = self.Package.LoadSceneAsync(location);

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
        public Dictionary<string, (OperationHandleBase handler, long destroyTime)> Handlers = new();
    }
}